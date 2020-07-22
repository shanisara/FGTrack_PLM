﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HTN.BITS.UIL.PLASESS.Component;
using HTN.BITS.UIL.PLASESS.Component.GridViewControl;
using DevExpress.XtraGrid;
using HTN.BITS.BLL.PLASESS;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Card;
using DevExpress.XtraGrid.Columns;
using HTN.BITS.BEL.PLASESS;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using HTN.BITS.UIL.PLASESS.Query_Popup;
using System.Globalization;
using DevExpress.XtraGrid.Views.Base;

namespace HTN.BITS.UIL.PLASESS.Query
{
    public partial class frmStockAsOnDate_Mtl : BaseChildForm
    {
        public frmStockAsOnDate_Mtl()
        {
            InitializeComponent();

            this.CustomInitializeComponent();

            //base.LoadGridLayoutMultipleView(this.Name, this.grdQrySummary);
            base.LoadFormLayout();
            base.LoadGridLayout(this.grdQrySummary);

            //this.gridController = new GridExportController(this.grdQrySummary.Views[0]);
        }

        #region "Variable Member"

        private DataTable dtbStockAsOn;
        //private GridExportController gridController;

        #endregion

        #region "Property Member"

        public string FileName
        {
            get
            {
                return string.Format("StockAsOnDate_{0:yyyyMMddHHmmss}", DateTime.Now);
            }
        }

        #endregion

        #region "Mathod Member"

        private void InitializaLOVData()
        {
            try
            {
                //For Warehouse
                using (MaterialBLL mtlBll = new MaterialBLL())
                {
                    List<Location> lstLoc = mtlBll.GetLocationList();
                    if (lstLoc != null)
                    {
                        this.grvQrySummary_rps_lueLocation.DataSource = lstLoc;

                        lstLoc.Insert(0, new Location { SEQ_NO = string.Empty, NAME = "(All)" });
                        this.lueLocation.Properties.DataSource = lstLoc;
                        
                    }
                }

                //for party
                using (PartyBLL partyBll = new PartyBLL())
                {
                    List<Party> lstParty = partyBll.LovPratyList("V", string.Empty);
                    lstParty.Insert(0, new Party { PARTY_ID = string.Empty, PARTY_NAME = "(All)" });

                    this.lueCUSTOMER.Properties.DataSource = lstParty;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

        }

        private void CustomInitializeComponent()
        {
            this.btnRefresh.Image = base.Language.GetBitmap("ButtonRefresh");

            this.ddbExport.Image = base.Language.GetBitmap("ButtonExport");

            this.bbiExportXLS.Glyph = base.Language.GetBitmap("DropdownXLS");
            this.bbiExportXLSX.Glyph = base.Language.GetBitmap("DropdownXLSX");
            this.bbiExportPDF.Glyph = base.Language.GetBitmap("DropdownPDF");
            this.bbiExportRTF.Glyph = base.Language.GetBitmap("DropdownRTF");
            this.bbiExportText.Glyph = base.Language.GetBitmap("DropdownTXT");
            this.bbiExportHTML.Glyph = base.Language.GetBitmap("DropdownHTML");

            this.bbiPrintPreview.Glyph = base.Language.GetBitmap("DropdownPrint");
            this.bbiPrintPreview.Enabled = false;

            this.ddbView.Image = base.Language.GetBitmap("ButtonView");

            this.bbiGridView.Glyph = base.Language.GetBitmap("DropdownGridView");
            this.bbiCardView.Glyph = base.Language.GetBitmap("DropdownCardView");
            this.bbiBandView.Glyph = base.Language.GetBitmap("DropdownBandedView");
            this.bbiAdvView.Glyph = base.Language.GetBitmap("DropdownAdvView");

            this.bbiAdvView.Enabled = false;

        }

        private eViewType GetDefaultViewType(GridControl gridCtl)
        {
            eViewType result = eViewType.GridView;

            switch (gridCtl.Views[0].GetType().Name)
            {
                case "GridView":
                    result = eViewType.GridView;
                    break;
                case "CardView":
                    result = eViewType.CardView;
                    break;
                case "BandedGridView":
                    result = eViewType.BandedView;
                    break;
                case "AdvBandedGridView":
                    result = eViewType.AdvanceView;
                    break;
                default:
                    break;
            }

            return result;
        }

        private void Query_StockAsOn_Date(string location, string partyid, string material)
        {
            try
            {
                base.ExecutionStart();
                base.BeginProcessing("Begin Load data...", "Please Waiting for Loading Data");

                using (QueryBLL queryBll = new QueryBLL())
                {
                    this.dtbStockAsOn = queryBll.StockAsOnDate_Mtl(location, partyid, material);
                }

                /*
                string expressionPCS = string.Empty;
                string expressionBOX = string.Empty;

                switch (this.GetDefaultViewType(this.grdQrySummary))
                {
                    case eViewType.GridView:
                        GridView gView = (GridView)this.grdQrySummary.MainView;
                        foreach (GridColumn column in gView.VisibleColumns)
                        {
                            switch (column.FieldName)
                            {
                                case "ALLOC_QTY":
                                    expressionPCS += "ALLOC_QTY+";
                                    break;
                                case "FREE_QTY":
                                    expressionPCS += "FREE_QTY+";
                                    break;
                                case "ALLOC_BOX":
                                    expressionBOX += "ALLOC_BOX+";
                                    break;
                                case "FREE_BOX":
                                    expressionBOX += "FREE_BOX+";
                                    break;

                                default:
                                    break;
                            }
                        }
                        break;
                    case eViewType.CardView:
                        // CardView cView = (CardView)this.grdQrySummary.MainView;

                        break;
                    case eViewType.BandedView:
                        BandedGridView bView = (BandedGridView)this.grdQrySummary.MainView;
                        foreach (GridColumn column in bView.VisibleColumns)
                        {
                            switch (column.FieldName)
                            {
                                case "ALLOC_QTY":
                                    expressionPCS += "ALLOC_QTY+";
                                    break;
                                case "FREE_QTY":
                                    expressionPCS += "FREE_QTY+";
                                    break;
                                case "ALLOC_BOX":
                                    expressionBOX += "ALLOC_BOX+";
                                    break;
                                case "FREE_BOX":
                                    expressionBOX += "FREE_BOX+";
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case eViewType.AdvanceView:
                        //AdvBandedGridView aView = (AdvBandedGridView)this.grdQryMainMTL.MainView;
                        break;
                    default:
                        break;
                }

                if (!string.IsNullOrEmpty(expressionPCS))
                {
                    expressionPCS = expressionPCS.Substring(0, expressionPCS.LastIndexOf("+"));

                    if (this.dtbStockAsOn.Columns.IndexOf("TOTAL_QTY") == -1)
                    {
                        this.dtbStockAsOn.Columns.Add("TOTAL_QTY", typeof(int), expressionPCS);
                    }
                    else
                    {
                        this.dtbStockAsOn.Columns["TOTAL_QTY"].Expression = expressionPCS;
                    }
                }

                if (!string.IsNullOrEmpty(expressionBOX))
                {
                    expressionBOX = expressionBOX.Substring(0, expressionBOX.LastIndexOf("+"));

                    if (this.dtbStockAsOn.Columns.IndexOf("TOTAL_BOX") == -1)
                    {
                        this.dtbStockAsOn.Columns.Add("TOTAL_BOX", typeof(int), expressionBOX);
                    }
                    else
                    {
                        this.dtbStockAsOn.Columns["TOTAL_BOX"].Expression = expressionBOX;
                    }
                }
                 * */

                if (dtbStockAsOn != null)
                {
                    dtbStockAsOn.DefaultView.Sort = "MTL_CODE";
                }

                this.grdQrySummary.DataSource = this.dtbStockAsOn;
                this.dntQryStkAsOn.DataSource = this.dtbStockAsOn;

                base.ExecutionStop();
            }
            catch (Exception ex)
            {
                base.FinishedProcessing();

                this.grdQrySummary.DataSource = null;
                this.dntQryStkAsOn.DataSource = null;

                XtraMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                ((frmMainMenu)this.ParentForm).ExecuteTime.Caption = base.ExecuteTime;
                base.FinishedProcessing();
            }

        }

        private void Query_StockAsOn_Dtl(string mtlCode, string mtlName, string mtlType)
        {
            //TimeSpan executionTime = new TimeSpan();
            //try
            //{
            //    Cursor.Current = Cursors.WaitCursor;
            //    UiUtility.BeginProcessing("Please wait", this);

            //    DataTable dtbStkAsOnDtl = null;
            //    using (QueryBLL queryBll = new QueryBLL())
            //    {
            //        //dtbStkAsOnDtl = queryBll.StockAsOn_Detail(mtlCode, mtlName, mtlType);
            //        //executionTime = queryBll.ExecutionTime;
            //    }

            //    this.grdQryDetail.DataSource = dtbStkAsOnDtl;
            //}
            //catch (Exception ex)
            //{
            //    Cursor.Current = Cursors.Default;
            //    UiUtility.EndProcessing();

            //    this.grdQryDetail.DataSource = null;

            //    XtraMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            //}
            //finally
            //{
            //    Cursor.Current = Cursors.Default;
            //    UiUtility.EndProcessing();
            //    ((frmMainMenu)this.ParentForm).ExecuteTime.Caption = "Execute Time: " + UiUtility.TimeSpanInWords(executionTime);
            //    //GridView view = (GridView)this.grdQryDetail.Views[0];
            //    //UiUtility.RemoveActiveRow(view);
            //}

        }

        private void Query_AdvanceSearch()
        {
            //frmAdvQryStock fQryAdvSearch = new frmAdvQryStock();

            //DialogResult result = UiUtility.ShowPopupForm(fQryAdvSearch, this, true);

            //if (result == DialogResult.OK)
            //{
            //    this._MTL_CODE_SEARCH = fQryAdvSearch.MTL_CODE;
            //    this._MTL_NAME = fQryAdvSearch.MTL_NAME;
            //    this._MTL_TYPE = fQryAdvSearch.MTL_TYPE;

            //    try
            //    {
            //        if (this.IsTabSummarySelecting)
            //        {
            //            this.Query_StockAsOn(this._MTL_CODE_SEARCH, this._MTL_NAME, this._MTL_TYPE);
            //        }
            //        else
            //        {
            //            this.Query_StockAsOn_Dtl(this._MTL_CODE_SEARCH, this._MTL_NAME, this._MTL_TYPE);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        XtraMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            //    }
            //    finally
            //    {

            //    }
            //}
        }

        private void ShowStockAsOnDateDetail(string mtl_code)
        {
            try
            {
                using (frmQupStockAsOnDate_Mtl fDetail = new frmQupStockAsOnDate_Mtl())
                {
                    fDetail.MTL_CODE = mtl_code;

                    fDetail.ShowDialog(this);
                    //UiUtility.ShowPopupForm(fDetail, this, true);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        #endregion

        #region "Custom Event Handle"

        private void GridControl_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //BandedGridView bView = sender as BandedGridView;
                ColumnView columnView = sender as ColumnView;

                Point pt = columnView.GridControl.PointToClient(Control.MousePosition);

                GridHitInfo info = columnView.CalcHitInfo(pt) as GridHitInfo;
                if ((info.RowHandle >= 0) && (info.InRow || info.InRowCell))
                {
                    string mtl_code = columnView.GetRowCellValue(info.RowHandle, "MTL_CODE").ToString();

                    this.ShowStockAsOnDateDetail(mtl_code);

                }
            }
            catch (Exception ex)
            {
            }
        }

        private void GridControl_ColumnPositionChanged(object sender, EventArgs e)
        {
            try
            {
                ColumnView gView = this.grdQrySummary.MainView as ColumnView;

                /*
                string expressionPCS = string.Empty;
                string expressionBOX = string.Empty;

                //GridView gView = (GridView)this.grdQrySummary.MainView;

                foreach (GridColumn column in gView.VisibleColumns)
                {
                    switch (column.FieldName)
                    {
                        case "ALLOC_QTY":
                            expressionPCS += "ALLOC_QTY+";
                            break;
                        case "FREE_QTY":
                            expressionPCS += "FREE_QTY+";
                            break;
                        case "ALLOC_BOX":
                            expressionBOX += "ALLOC_BOX+";
                            break;
                        case "FREE_BOX":
                            expressionBOX += "FREE_BOX+";
                            break;
                        default:
                            break;
                    }
                }

                if (!string.IsNullOrEmpty(expressionPCS))
                {
                    expressionPCS = expressionPCS.Substring(0, expressionPCS.LastIndexOf("+"));

                    if (this.dtbStockAsOn.Columns.IndexOf("TOTAL_QTY") == -1)
                    {
                        this.dtbStockAsOn.Columns.Add("TOTAL_QTY", typeof(int), expressionPCS);
                    }
                    else
                    {
                        this.dtbStockAsOn.Columns["TOTAL_QTY"].Expression = expressionPCS;
                    }
                }

                if (!string.IsNullOrEmpty(expressionBOX))
                {
                    expressionBOX = expressionBOX.Substring(0, expressionBOX.LastIndexOf("+"));

                    if (this.dtbStockAsOn.Columns.IndexOf("TOTAL_BOX") == -1)
                    {
                        this.dtbStockAsOn.Columns.Add("TOTAL_BOX", typeof(int), expressionBOX);
                    }
                    else
                    {
                        this.dtbStockAsOn.Columns["TOTAL_BOX"].Expression = expressionBOX;
                    }
                }


                this.grdQrySummary.DataSource = this.dtbStockAsOn;
                 * */
                gView.RefreshData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void GridControl_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            if (e.RowHandle >= 0)
            {
                //Row Active
                if (e.RowHandle == view.FocusedRowHandle)
                {
                    //e.Info.DisplayText = string.Empty;
                    e.Info.ImageIndex = 0;
                }
            }
        }

        private void Respository_DoubleClick(object sender, EventArgs e)
        {
            this.GridControl_DoubleClick(this.grdQrySummary.MainView, e);
        }

        #endregion

        #region "Button Export Referance"

        private void bbiExportXLS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //gridController.ExportToXLS(this.FileName + ".xls", "Microsoft Excel Document", "Microsoft Excel|*.xls");
            base.ViewExportToExcel(this.grdQrySummary.Views[0], GridExportType.XLS, this.FileName + ".xls", null);
        }

        private void bbiExportXLSX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //gridController.ExportToXLSX(this.FileName + ".xlsx", "Microsoft Excel 2007 Document", "Microsoft Excel|*.xlsx");
            base.ViewExportToExcel(this.grdQrySummary.Views[0], GridExportType.XLSX, this.FileName + ".xlsx", null);
        }

        private void bbiExportPDF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //gridController.ExportToPDF(this.FileName + ".pdf", "PDF Document", "PDF Files|*.pdf");
            base.ViewExportToExcel(this.grdQrySummary.Views[0], GridExportType.PDF, this.FileName + ".pdf", null);
        }

        private void bbiExportRTF_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //gridController.ExportToRTF(this.FileName + ".rtf", "RTF Document", "RTF Files|*.rtf");
            base.ViewExportToExcel(this.grdQrySummary.Views[0], GridExportType.RTF, this.FileName + ".rtf", null);
        }

        private void bbiExportText_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //gridController.ExportToTEXT(this.FileName + ".txt", "Text Document", "Text Files|*.txt");
            base.ViewExportToExcel(this.grdQrySummary.Views[0], GridExportType.TEXT, this.FileName + ".txt", null);
        }

        private void bbiExportHTML_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //gridController.ExportToHTML(this.FileName + ".html", "HTML Document", "HTML Files|*.html");
            base.ViewExportToExcel(this.grdQrySummary.Views[0], GridExportType.HTML, this.FileName + ".html", null);
        }

        private void ddbExport_Click(object sender, EventArgs e)
        {
            DropDownButton ddb2 = (DropDownButton)sender;
            ddb2.ShowDropDown();
        }

        #endregion "Button Export Referance"

        #region "Button Change View Referance"

        private void bbiGridView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ChangeView(eViewType.GridView, this.grdQrySummary);
        }

        private void bbiCardView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ChangeView(eViewType.CardView, this.grdQrySummary);
        }

        private void bbiBandView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ChangeView(eViewType.BandedView, this.grdQrySummary);
        }

        private void bbiAdvView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ChangeView(eViewType.AdvanceView, this.grdQrySummary);
        }

        private void ddbView_Click(object sender, EventArgs e)
        {
            DropDownButton ddbV = (DropDownButton)sender;
            ddbV.ShowDropDown();
        }

        private void ChangeView(eViewType viewType, GridControl gridCtl)
        {
            switch (viewType)
            {
                case eViewType.GridView:
                    gridCtl.MainView = this.grvQrySummary;
                    this.grvQrySummary.ExpandAllGroups();

                    //GridView gView = (GridView)gridCtl.MainView;
                    //UiUtility.RemoveActiveRow(gView);

                    break;
                case eViewType.CardView:
                    //gridCtl.MainView = this.cdvQrySummary;
                    break;
                case eViewType.BandedView:
                    gridCtl.MainView = this.brvQrySummary;
                    this.brvQrySummary.ExpandAllGroups();

                    //BandedGridView bView = (BandedGridView)gridCtl.MainView;
                    //UiUtility.RemoveActiveRow(bView);



                    break;
                case eViewType.AdvanceView:
                    break;
                default:
                    break;
            }
        }

        #endregion "Button Change View Referance"

        private void frmStockAsOnDate_Load(object sender, EventArgs e)
        {
            //this.KeyPreview = true;
            //this.InitializaLOVData();
            //this.dtpDateSelect.EditValue = DateTime.Now;
            //this.btnRefresh.Focus();
        }

        private void frmStockAsOnDate_LoadCompleted()
        {
            this.KeyPreview = true;
            this.InitializaLOVData();
            this.btnRefresh.Focus();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string location, partyid;

            if (this.lueLocation.EditValue != null)
                location = (string)this.lueLocation.EditValue;
            else
                location = string.Empty;

            if (this.lueCUSTOMER.EditValue != null)
                partyid = (string)this.lueCUSTOMER.EditValue;
            else
                partyid = string.Empty;

            this.Query_StockAsOn_Date(location, partyid, this.txtProduct.Text);


            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmStockAsOnDate_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.F5:
                        this.btnRefresh.PerformClick();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void frmStockAsOnDate_FormClosed(object sender, FormClosedEventArgs e)
        {
            //base.SaveGridLayoutMultipleView(this.Name, this.grdQrySummary);
            this.Controls.Clear();
        }


        
    }
}