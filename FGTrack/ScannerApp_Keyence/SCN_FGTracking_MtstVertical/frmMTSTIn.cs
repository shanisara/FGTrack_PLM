﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HTN.BITS.FGTRACK.LIB;
using HTN.BITS.FGTRACK.MTSTVER.Components;
using System.Net;
using System.Globalization;
using Bt;
using HTN.BITS.FGTRACK.LIB.Scanner;
//using HTN.BITS.FGTRACK.MTSTVER.Components;

namespace HTN.BITS.FGTRACK.MTSTVER
{
    public partial class frmMTSTIn : BaseFormFullMode, IDisposable
    {
        public frmMTSTIn()
        {
            InitializeComponent();
            base.UpdateResourcesInForm(GlobalVariable.LanguageSelect);

            try
            {
                this.MsgWin = new MsgWindow();
                this.MsgWin.BarcodeRead += new Action(MsgWin_BarcodeRead);
 
                this.txtTO_NO.Text = string.Empty;
                this.txtSERIAL_NO.Text = string.Empty;

                this.ClearDataOnScreen();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            FullScreenHandle.StartFullScreen(this);
        }

        #region "Variable Member"


        private string _USER_ID;
        private TextBox tempTextBox;

        private int _Pcs_Scann;
        private int _Pcs_Total;

        private int _Box_Scann;
        private int _Box_Total;

        #endregion

        #region "Property Member"

        private MsgWindow MsgWin;
        public string USER_ID
        {
            get
            {
                return _USER_ID;
            }
            set
            {
                if (_USER_ID == value)
                    return;
                _USER_ID = value;
            }
        }

        private TextBox ActiveInputBox
        {
            get { return tempTextBox; }
            set { tempTextBox = value; }
        }
        #endregion

        #region "Method Member"

        void MsgWin_BarcodeRead()
        {
            Int32 ret = 0;
            String disp = "";
            Byte[] codedataGet;
            Int32 codeLen = 0;
            UInt16 symbolGet = 0;

            try
            {
                //-----------------------------------------------------------
                // Reading (batch)
                //-----------------------------------------------------------
                codeLen = Bt.ScanLib.Control.btScanGetStringSize();
                if (codeLen <= 0)
                {
                  //  disp = "btScanGetStringSize error ret[" + codeLen + "]";
                  //  MessageBox.Show(disp, "Error");
                }

                codedataGet = new Byte[codeLen];

                ret = Bt.ScanLib.Control.btScanGetString(codedataGet, ref symbolGet);
                if (ret != LibDef.BT_OK)
                {
                    disp = "btScanGetString error ret[" + ret + "]";
                    MessageBox.Show(disp, "Error");
                }

                ret = Bt.ScanLib.Control.btScanDisable();
                if (ret != LibDef.BT_OK)
                {
                    MessageBox.Show("btScanDisable error ret[" + ret + "]", "Error");
                }
                
                disp = System.Text.Encoding.GetEncoding(932).GetString(codedataGet, 0, codeLen);
               
                switch (this.ActiveInputBox.Name)
                {
                    case "txtTO_NO":
                        this.ClearDataOnScreen();
                        //do some method
                        this.txtTO_NO.Text = disp;
                        this.GetTOInfo(disp);

                        break;
                    case "txtSERIAL_NO":
                        this.txtSERIAL_NO.Text = disp;
                        this.GetUpdateProductCardDetail(this.txtTO_NO.Text, disp);
                        break;
                    default:
                        break;
                }

                ret = Bt.ScanLib.Control.btScanEnable();
                if (ret != LibDef.BT_OK)
                {
                    MessageBox.Show("btScanEnable error ret[" + ret + "]", "Error");
                }

            }
            catch (Exception e)
            {
              //  MessageBox.Show(e.ToString());
            }
        }



        private void GetTOInfo(string toNo)
        {
            string outMsg = string.Empty;
            ServiceRef.TransferOrderInfo toInfo = null;
            try
            {
                base.ShowWaitProcess();
                toInfo = ServiceProvider.Instance.Proxy.GetTOInfo(toNo, this.USER_ID, out outMsg);
                base.HideWaitProcess();

                if (toInfo != null)
                {
                    this.ClearDataOnScreen();

                    this.txtTO_NO.ReadOnly = true;
                    this.txtTO_NO.Text = toInfo.TO_NO;
                    this.txtSERIAL_NO.Text = string.Empty;
                    this.txtSERIAL_NO.Focus();

                }
                else
                {
                    base.ShowWarningBox(ResourceManager.Instance.GetString(outMsg), ResourceManager.Instance.GetString("TITLE_PLEASE_CHECK"));

                    this.txtTO_NO.Text = string.Empty;
                    this.txtTO_NO.Focus();

                }
            }
            catch (WebException wex)
            {
                base.HideWaitProcess();

                base.ShowErrorBox(wex.Message, "WebException");

                this.txtTO_NO.Text = string.Empty;
                this.txtTO_NO.Focus();
            }
            catch (Exception ex)
            {
                base.HideWaitProcess();

                base.ShowErrorBox(ex.Message, "Exception");

                this.txtTO_NO.Text = string.Empty;
                this.txtTO_NO.Focus();
            }
        }

        private void GetUpdateProductCardDetail(string toNo, string serialNo)
        {
            string outMsg = string.Empty;
            ServiceRef.ProductCard prdInfo = null;
            try
            {
                base.ShowWaitProcess();

                prdInfo = ServiceProvider.Instance.Proxy.GetUpdatePC_MTST_In(toNo, serialNo, this.USER_ID, out outMsg);

                base.HideWaitProcess();

                if (prdInfo != null)
                {
                    this.lblSERIAL_NO.Text = serialNo;
                    this.lblPRODUCT_NO.Text = prdInfo.PRODUCT_NO;
                    this.lblPRODUCT_NAME.Text = prdInfo.PRODUCT_NAME;
                    this.lblMTL_TYPE.Text = prdInfo.MTL_TYPE;
                    this.lblJOB_NO.Text = prdInfo.JOB_NO;
                    this.lblSHIFT.Text = prdInfo.JOB_LOT;
                    this.lblQty.Text = string.Format("{0:#,##0}", prdInfo.QTY);
                    this.lblUNIT_ID.Text = prdInfo.UNIT_ID;
                   //** Remark : NG_QTY = Scan Box , BOX_SCANNED for Total DO Box
                    this.lblNo_Box_Scaned.Text = string.Format("{0:#,##0} / {1:#,##0}", prdInfo.NG_QTY, prdInfo.BOX_SCANNED);
                     //   use for SCN_QTY ==  pcCard.ASG_NG 
                     //   use for SCN_BOX ==  pcCard.NG_QTY
                     //   use for DO_QTY == pcCard.BOX_QTY 
                     //   use for DO_BOX ==   pcCard.BOX_SCANNED 

                    if (prdInfo.BOX_QTY == prdInfo.ASG_NG)
                    {
                        //base.StartPlayTon_Complete();
                       
                        //this.txtTO_NO.Focus();
                        base.ShowCompletelyBox(ResourceManager.Instance.GetString("INF_FINISH_PROCESS"), ResourceManager.Instance.GetString("TITLE_INFO_COMPLETE"));
 this.ClearDataOnScreen();

                        this.txtSERIAL_NO.Text = string.Empty;
                        this.txtSERIAL_NO.Focus();

                        this.txtTO_NO.ReadOnly = false;
                        this.txtTO_NO.Text = string.Empty;
                        this.txtTO_NO.Focus();
                    }
                    else
                    {
                        this.txtSERIAL_NO.Text = string.Empty;
                        this.txtSERIAL_NO.Focus();
                    }
                    

                }
                else
                {
                    base.ShowWarningBox(ResourceManager.Instance.GetString(outMsg), ResourceManager.Instance.GetString("TITLE_PLEASE_CHECK"));

                    this.txtSERIAL_NO.Text = string.Empty;
                    this.txtSERIAL_NO.Focus();

                }
            }
            catch (WebException wex)
            {
                base.HideWaitProcess();
                this.ClearDataOnScreen();

                base.ShowErrorBox(wex.Message, "WebException");

                this.txtSERIAL_NO.Text = string.Empty;
                this.txtSERIAL_NO.Focus();
            }
            catch (Exception ex)
            {
                base.HideWaitProcess();
                this.ClearDataOnScreen();

                base.ShowErrorBox(ex.Message, "Exception");

                this.txtSERIAL_NO.Text = string.Empty;
                this.txtSERIAL_NO.Focus();
            }
        }

        private void ClearDataOnScreen()
        {
            this.lblSERIAL_NO.Text = string.Empty;
            this.lblPRODUCT_NO.Text = string.Empty;
            this.lblPRODUCT_NAME.Text = string.Empty;
            this.lblMTL_TYPE.Text = string.Empty;
            this.lblJOB_NO.Text = string.Empty;
            this.lblSHIFT.Text = string.Empty;
            this.lblQty.Text = string.Empty;
            this.lblUNIT_ID.Text = string.Empty;
            //this.txtNoOfBox.Text = string.Empty;
            //this.lblTotalPCS.Text = "0 / 0";
            this.lblNo_Box_Scaned.Text = "0 / 0";
        }

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            //remove event handle
            this.MsgWin.BarcodeRead -= new Action(MsgWin_BarcodeRead);

            GC.SuppressFinalize(this);
        }

        #endregion

        private void txtSERIAL_NO_GotFocus(object sender, EventArgs e)
        {
            Int32 ret = 0;

            try
            {
                this.ActiveInputBox = (TextBox)sender;
                ret = Bt.ScanLib.Control.btScanEnable();
                if (ret != LibDef.BT_OK)
                {
                    MessageBox.Show("btScanEnable error ret[" + ret + "]", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void txtSERIAL_NO_LostFocus(object sender, EventArgs e)
        {
            Int32 ret = 0;

            try
            {
                this.ActiveInputBox = null;
                ret = Bt.ScanLib.Control.btScanDisable();
                if (ret != LibDef.BT_OK)
                {
                    MessageBox.Show("btScanDisable error ret[" + ret + "]", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtSERIAL_NO_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox editor = (TextBox)sender;
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (string.IsNullOrEmpty(this.txtTO_NO.Text))
                        {
                            this.txtTO_NO.Focus();
                            return;
                        }
                        if (string.IsNullOrEmpty(editor.Text)) return;

                        this.GetUpdateProductCardDetail(this.txtTO_NO.Text, editor.Text);
                        break;
                    case Keys.F1:
                        //rollback
                        this.ClearDataOnScreen();

                        this.txtSERIAL_NO.Text = string.Empty;
                        this.txtTO_NO.ReadOnly = false;
                        this.txtTO_NO.Text = string.Empty;

                        this.txtTO_NO.Focus();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn01Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMTSTIn_Load(object sender, EventArgs e)
        {
            this.txtTO_NO.Focus();
        }

        private void txtTO_NO_GotFocus(object sender, EventArgs e)
        {
            Int32 ret = 0;

            try
            {
                this.ActiveInputBox = (TextBox)sender;
                ret = Bt.ScanLib.Control.btScanEnable();
                if (ret != LibDef.BT_OK)
                {
                    MessageBox.Show("btScanEnable error ret[" + ret + "]", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtTO_NO_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox editor = sender as TextBox;
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (string.IsNullOrEmpty(editor.Text)) return;

                        this.GetTOInfo(editor.Text);
                        //this.txtSERIAL_NO.Focus();
                        break;
                    case Keys.F1:
                        //rollback
                        this.btn01Cancel.Focus();
                        this.btn01Cancel_Click(this.btn01Cancel, new EventArgs());
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtTO_NO_LostFocus(object sender, EventArgs e)
        {
            Int32 ret = 0;

            try
            {
                this.ActiveInputBox = null;
                ret = Bt.ScanLib.Control.btScanDisable();
                if (ret != LibDef.BT_OK)
                {
                    MessageBox.Show("btScanDisable error ret[" + ret + "]", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        
        
    }
}