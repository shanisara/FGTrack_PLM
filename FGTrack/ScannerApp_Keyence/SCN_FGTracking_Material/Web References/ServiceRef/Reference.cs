﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.9148
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.CompactFramework.Design.Data, Version 2.0.50727.9148.
// 
namespace HTN.BITS.FGTRACK.MATERIAL.ServiceRef {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="Service_MATSoap", Namespace="http://tempuri.org/")]
    public partial class Service_MAT : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public Service_MAT() {
            this.Url = "http://10.211.107.16/FGTrack_PM_Service/Service_MAT.asmx";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/HelloWorld", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string HelloWorld() {
            object[] results = this.Invoke("HelloWorld", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginHelloWorld(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("HelloWorld", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public string EndHelloWorld(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CheckValidationUser", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string CheckValidationUser(string userid) {
            object[] results = this.Invoke("CheckValidationUser", new object[] {
                        userid});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginCheckValidationUser(string userid, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("CheckValidationUser", new object[] {
                        userid}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndCheckValidationUser(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CheckExistLocation", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool CheckExistLocation(string location) {
            object[] results = this.Invoke("CheckExistLocation", new object[] {
                        location});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginCheckExistLocation(string location, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("CheckExistLocation", new object[] {
                        location}, callback, asyncState);
        }
        
        /// <remarks/>
        public bool EndCheckExistLocation(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ScanMatIn_Complete", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public MaterialCard ScanMatIn_Complete(string serialno, string location, string userid, out string resultMsg) {
            object[] results = this.Invoke("ScanMatIn_Complete", new object[] {
                        serialno,
                        location,
                        userid});
            resultMsg = ((string)(results[1]));
            return ((MaterialCard)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginScanMatIn_Complete(string serialno, string location, string userid, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("ScanMatIn_Complete", new object[] {
                        serialno,
                        location,
                        userid}, callback, asyncState);
        }
        
        /// <remarks/>
        public MaterialCard EndScanMatIn_Complete(System.IAsyncResult asyncResult, out string resultMsg) {
            object[] results = this.EndInvoke(asyncResult);
            resultMsg = ((string)(results[1]));
            return ((MaterialCard)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ScanMatOut_Complete", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public MaterialCard ScanMatOut_Complete(string serialno, string userid, out string resultMsg) {
            object[] results = this.Invoke("ScanMatOut_Complete", new object[] {
                        serialno,
                        userid});
            resultMsg = ((string)(results[1]));
            return ((MaterialCard)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginScanMatOut_Complete(string serialno, string userid, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("ScanMatOut_Complete", new object[] {
                        serialno,
                        userid}, callback, asyncState);
        }
        
        /// <remarks/>
        public MaterialCard EndScanMatOut_Complete(System.IAsyncResult asyncResult, out string resultMsg) {
            object[] results = this.EndInvoke(asyncResult);
            resultMsg = ((string)(results[1]));
            return ((MaterialCard)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ScanMat_Status", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public MaterialCard ScanMat_Status(string serialno, out string resultMsg) {
            object[] results = this.Invoke("ScanMat_Status", new object[] {
                        serialno});
            resultMsg = ((string)(results[1]));
            return ((MaterialCard)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginScanMat_Status(string serialno, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("ScanMat_Status", new object[] {
                        serialno}, callback, asyncState);
        }
        
        /// <remarks/>
        public MaterialCard EndScanMat_Status(System.IAsyncResult asyncResult, out string resultMsg) {
            object[] results = this.EndInvoke(asyncResult);
            resultMsg = ((string)(results[1]));
            return ((MaterialCard)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ScanMat_Stock", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public MaterialCard ScanMat_Stock(string serialno, out string resultMsg) {
            object[] results = this.Invoke("ScanMat_Stock", new object[] {
                        serialno});
            resultMsg = ((string)(results[1]));
            return ((MaterialCard)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginScanMat_Stock(string serialno, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("ScanMat_Stock", new object[] {
                        serialno}, callback, asyncState);
        }
        
        /// <remarks/>
        public MaterialCard EndScanMat_Stock(System.IAsyncResult asyncResult, out string resultMsg) {
            object[] results = this.EndInvoke(asyncResult);
            resultMsg = ((string)(results[1]));
            return ((MaterialCard)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ScanMat_ChangeLocation", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public MaterialCard ScanMat_ChangeLocation(string serialno, string location, string userid, out string resultMsg) {
            object[] results = this.Invoke("ScanMat_ChangeLocation", new object[] {
                        serialno,
                        location,
                        userid});
            resultMsg = ((string)(results[1]));
            return ((MaterialCard)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginScanMat_ChangeLocation(string serialno, string location, string userid, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("ScanMat_ChangeLocation", new object[] {
                        serialno,
                        location,
                        userid}, callback, asyncState);
        }
        
        /// <remarks/>
        public MaterialCard EndScanMat_ChangeLocation(System.IAsyncResult asyncResult, out string resultMsg) {
            object[] results = this.EndInvoke(asyncResult);
            resultMsg = ((string)(results[1]));
            return ((MaterialCard)(results[0]));
        }
    }
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class MaterialCard {
        
        private string sERIAL_NOField;
        
        private int rEC_NOField;
        
        private string wH_IDField;
        
        private string aRRIVAL_NOField;
        
        private int lINE_NOField;
        
        private System.Nullable<System.DateTime> lOT_DATEField;
        
        private string mTL_SEQ_NOField;
        
        private string mTL_CODEField;
        
        private string mTL_NAMEField;
        
        private string mTL_GRADEField;
        
        private string mTL_COLORField;
        
        private string uNIT_IDField;
        
        private decimal qTYField;
        
        private string cARGO_STATUSField;
        
        private string pIC_STOCK_INField;
        
        private System.Nullable<System.DateTime> sTOCK_IN_DATEField;
        
        private string pIC_STOCK_OUTField;
        
        private System.Nullable<System.DateTime> sTOCK_OUT_DATEField;
        
        private string oRDER_CARD_NOField;
        
        private decimal oUT_QTYField;
        
        private int nO_OF_PRINTField;
        
        private string pIC_LAST_PRINTField;
        
        private System.Nullable<System.DateTime> pRINT_LAST_DATEField;
        
        private string rEMARKField;
        
        private string n_USER_IDField;
        
        private string u_USER_IDField;
        
        private string rEC_STATField;
        
        private string pARTY_IDField;
        
        private string pARTY_NAMEField;
        
        private string lOCATION_IDField;
        
        private string lOCATION_NAMEField;
        
        private string nO_OF_LABELField;
        
        private decimal rEC_QTYField;
        
        private decimal dOC_QTYField;
        
        private decimal mIN_QTYField;
        
        private decimal mAX_QTYField;
        
        /// <remarks/>
        public string SERIAL_NO {
            get {
                return this.sERIAL_NOField;
            }
            set {
                this.sERIAL_NOField = value;
            }
        }
        
        /// <remarks/>
        public int REC_NO {
            get {
                return this.rEC_NOField;
            }
            set {
                this.rEC_NOField = value;
            }
        }
        
        /// <remarks/>
        public string WH_ID {
            get {
                return this.wH_IDField;
            }
            set {
                this.wH_IDField = value;
            }
        }
        
        /// <remarks/>
        public string ARRIVAL_NO {
            get {
                return this.aRRIVAL_NOField;
            }
            set {
                this.aRRIVAL_NOField = value;
            }
        }
        
        /// <remarks/>
        public int LINE_NO {
            get {
                return this.lINE_NOField;
            }
            set {
                this.lINE_NOField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> LOT_DATE {
            get {
                return this.lOT_DATEField;
            }
            set {
                this.lOT_DATEField = value;
            }
        }
        
        /// <remarks/>
        public string MTL_SEQ_NO {
            get {
                return this.mTL_SEQ_NOField;
            }
            set {
                this.mTL_SEQ_NOField = value;
            }
        }
        
        /// <remarks/>
        public string MTL_CODE {
            get {
                return this.mTL_CODEField;
            }
            set {
                this.mTL_CODEField = value;
            }
        }
        
        /// <remarks/>
        public string MTL_NAME {
            get {
                return this.mTL_NAMEField;
            }
            set {
                this.mTL_NAMEField = value;
            }
        }
        
        /// <remarks/>
        public string MTL_GRADE {
            get {
                return this.mTL_GRADEField;
            }
            set {
                this.mTL_GRADEField = value;
            }
        }
        
        /// <remarks/>
        public string MTL_COLOR {
            get {
                return this.mTL_COLORField;
            }
            set {
                this.mTL_COLORField = value;
            }
        }
        
        /// <remarks/>
        public string UNIT_ID {
            get {
                return this.uNIT_IDField;
            }
            set {
                this.uNIT_IDField = value;
            }
        }
        
        /// <remarks/>
        public decimal QTY {
            get {
                return this.qTYField;
            }
            set {
                this.qTYField = value;
            }
        }
        
        /// <remarks/>
        public string CARGO_STATUS {
            get {
                return this.cARGO_STATUSField;
            }
            set {
                this.cARGO_STATUSField = value;
            }
        }
        
        /// <remarks/>
        public string PIC_STOCK_IN {
            get {
                return this.pIC_STOCK_INField;
            }
            set {
                this.pIC_STOCK_INField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> STOCK_IN_DATE {
            get {
                return this.sTOCK_IN_DATEField;
            }
            set {
                this.sTOCK_IN_DATEField = value;
            }
        }
        
        /// <remarks/>
        public string PIC_STOCK_OUT {
            get {
                return this.pIC_STOCK_OUTField;
            }
            set {
                this.pIC_STOCK_OUTField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> STOCK_OUT_DATE {
            get {
                return this.sTOCK_OUT_DATEField;
            }
            set {
                this.sTOCK_OUT_DATEField = value;
            }
        }
        
        /// <remarks/>
        public string ORDER_CARD_NO {
            get {
                return this.oRDER_CARD_NOField;
            }
            set {
                this.oRDER_CARD_NOField = value;
            }
        }
        
        /// <remarks/>
        public decimal OUT_QTY {
            get {
                return this.oUT_QTYField;
            }
            set {
                this.oUT_QTYField = value;
            }
        }
        
        /// <remarks/>
        public int NO_OF_PRINT {
            get {
                return this.nO_OF_PRINTField;
            }
            set {
                this.nO_OF_PRINTField = value;
            }
        }
        
        /// <remarks/>
        public string PIC_LAST_PRINT {
            get {
                return this.pIC_LAST_PRINTField;
            }
            set {
                this.pIC_LAST_PRINTField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> PRINT_LAST_DATE {
            get {
                return this.pRINT_LAST_DATEField;
            }
            set {
                this.pRINT_LAST_DATEField = value;
            }
        }
        
        /// <remarks/>
        public string REMARK {
            get {
                return this.rEMARKField;
            }
            set {
                this.rEMARKField = value;
            }
        }
        
        /// <remarks/>
        public string N_USER_ID {
            get {
                return this.n_USER_IDField;
            }
            set {
                this.n_USER_IDField = value;
            }
        }
        
        /// <remarks/>
        public string U_USER_ID {
            get {
                return this.u_USER_IDField;
            }
            set {
                this.u_USER_IDField = value;
            }
        }
        
        /// <remarks/>
        public string REC_STAT {
            get {
                return this.rEC_STATField;
            }
            set {
                this.rEC_STATField = value;
            }
        }
        
        /// <remarks/>
        public string PARTY_ID {
            get {
                return this.pARTY_IDField;
            }
            set {
                this.pARTY_IDField = value;
            }
        }
        
        /// <remarks/>
        public string PARTY_NAME {
            get {
                return this.pARTY_NAMEField;
            }
            set {
                this.pARTY_NAMEField = value;
            }
        }
        
        /// <remarks/>
        public string LOCATION_ID {
            get {
                return this.lOCATION_IDField;
            }
            set {
                this.lOCATION_IDField = value;
            }
        }
        
        /// <remarks/>
        public string LOCATION_NAME {
            get {
                return this.lOCATION_NAMEField;
            }
            set {
                this.lOCATION_NAMEField = value;
            }
        }
        
        /// <remarks/>
        public string NO_OF_LABEL {
            get {
                return this.nO_OF_LABELField;
            }
            set {
                this.nO_OF_LABELField = value;
            }
        }
        
        /// <remarks/>
        public decimal REC_QTY {
            get {
                return this.rEC_QTYField;
            }
            set {
                this.rEC_QTYField = value;
            }
        }
        
        /// <remarks/>
        public decimal DOC_QTY {
            get {
                return this.dOC_QTYField;
            }
            set {
                this.dOC_QTYField = value;
            }
        }
        
        /// <remarks/>
        public decimal MIN_QTY {
            get {
                return this.mIN_QTYField;
            }
            set {
                this.mIN_QTYField = value;
            }
        }
        
        /// <remarks/>
        public decimal MAX_QTY {
            get {
                return this.mAX_QTYField;
            }
            set {
                this.mAX_QTYField = value;
            }
        }
    }
}
