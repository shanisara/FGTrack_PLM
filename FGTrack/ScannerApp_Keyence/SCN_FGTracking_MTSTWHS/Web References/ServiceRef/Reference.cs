﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.8922
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.CompactFramework.Design.Data, Version 2.0.50727.8922.
// 
namespace HTN.BITS.FGTRACK.MTSTWHS.ServiceRef {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="Service_MtstVerticalSoap", Namespace="http://tempuri.org/")]
    public partial class Service_MtstVertical : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public Service_MtstVertical() {
            this.Url = "http://10.211.107.16/FGTrack_PM_Service/Service_MtstVertical.asmx";
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
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetDeliveryOrderInfo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public DeliveryOrderInfo GetDeliveryOrderInfo(string doNo, string userid, out string resultMsg) {
            object[] results = this.Invoke("GetDeliveryOrderInfo", new object[] {
                        doNo,
                        userid});
            resultMsg = ((string)(results[1]));
            return ((DeliveryOrderInfo)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetDeliveryOrderInfo(string doNo, string userid, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetDeliveryOrderInfo", new object[] {
                        doNo,
                        userid}, callback, asyncState);
        }
        
        /// <remarks/>
        public DeliveryOrderInfo EndGetDeliveryOrderInfo(System.IAsyncResult asyncResult, out string resultMsg) {
            object[] results = this.EndInvoke(asyncResult);
            resultMsg = ((string)(results[1]));
            return ((DeliveryOrderInfo)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetUpdatePC_MTST_In", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ProductCard GetUpdatePC_MTST_In(string doNo, string serialNo, string userid, out string resultMsg) {
            object[] results = this.Invoke("GetUpdatePC_MTST_In", new object[] {
                        doNo,
                        serialNo,
                        userid});
            resultMsg = ((string)(results[1]));
            return ((ProductCard)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetUpdatePC_MTST_In(string doNo, string serialNo, string userid, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetUpdatePC_MTST_In", new object[] {
                        doNo,
                        serialNo,
                        userid}, callback, asyncState);
        }
        
        /// <remarks/>
        public ProductCard EndGetUpdatePC_MTST_In(System.IAsyncResult asyncResult, out string resultMsg) {
            object[] results = this.EndInvoke(asyncResult);
            resultMsg = ((string)(results[1]));
            return ((ProductCard)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetUpdatePC_MTST_Out", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ProductCard GetUpdatePC_MTST_Out(string serialNo, string userid, out string resultMsg) {
            object[] results = this.Invoke("GetUpdatePC_MTST_Out", new object[] {
                        serialNo,
                        userid});
            resultMsg = ((string)(results[1]));
            return ((ProductCard)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetUpdatePC_MTST_Out(string serialNo, string userid, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetUpdatePC_MTST_Out", new object[] {
                        serialNo,
                        userid}, callback, asyncState);
        }
        
        /// <remarks/>
        public ProductCard EndGetUpdatePC_MTST_Out(System.IAsyncResult asyncResult, out string resultMsg) {
            object[] results = this.EndInvoke(asyncResult);
            resultMsg = ((string)(results[1]));
            return ((ProductCard)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetProductCardStatus", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ProductCard_Status GetProductCardStatus(string serialNo, string userid, out string resultMsg) {
            object[] results = this.Invoke("GetProductCardStatus", new object[] {
                        serialNo,
                        userid});
            resultMsg = ((string)(results[1]));
            return ((ProductCard_Status)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetProductCardStatus(string serialNo, string userid, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetProductCardStatus", new object[] {
                        serialNo,
                        userid}, callback, asyncState);
        }
        
        /// <remarks/>
        public ProductCard_Status EndGetProductCardStatus(System.IAsyncResult asyncResult, out string resultMsg) {
            object[] results = this.EndInvoke(asyncResult);
            resultMsg = ((string)(results[1]));
            return ((ProductCard_Status)(results[0]));
        }
    }
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class DeliveryOrderInfo {
        
        private string dO_NOField;
        
        /// <remarks/>
        public string DO_NO {
            get {
                return this.dO_NOField;
            }
            set {
                this.dO_NOField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ProductCard_Status))]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class ProductCard {
        
        private string oRI_LABELField;
        
        private string sERIAL_NOField;
        
        private string pROD_SEQ_NOField;
        
        private string pRODUCT_NOField;
        
        private string pRODUCT_NAMEField;
        
        private string mTL_TYPEField;
        
        private string jOB_NOField;
        
        private string jOB_LOTField;
        
        private string sHIFTField;
        
        private int lINE_NOField;
        
        private string mC_NOField;
        
        private int qTYField;
        
        private int bOX_QTYField;
        
        private int bOX_SCANNEDField;
        
        private int aSG_NGField;
        
        private int nG_QTYField;
        
        private string uNIT_IDField;
        
        /// <remarks/>
        public string ORI_LABEL {
            get {
                return this.oRI_LABELField;
            }
            set {
                this.oRI_LABELField = value;
            }
        }
        
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
        public string PROD_SEQ_NO {
            get {
                return this.pROD_SEQ_NOField;
            }
            set {
                this.pROD_SEQ_NOField = value;
            }
        }
        
        /// <remarks/>
        public string PRODUCT_NO {
            get {
                return this.pRODUCT_NOField;
            }
            set {
                this.pRODUCT_NOField = value;
            }
        }
        
        /// <remarks/>
        public string PRODUCT_NAME {
            get {
                return this.pRODUCT_NAMEField;
            }
            set {
                this.pRODUCT_NAMEField = value;
            }
        }
        
        /// <remarks/>
        public string MTL_TYPE {
            get {
                return this.mTL_TYPEField;
            }
            set {
                this.mTL_TYPEField = value;
            }
        }
        
        /// <remarks/>
        public string JOB_NO {
            get {
                return this.jOB_NOField;
            }
            set {
                this.jOB_NOField = value;
            }
        }
        
        /// <remarks/>
        public string JOB_LOT {
            get {
                return this.jOB_LOTField;
            }
            set {
                this.jOB_LOTField = value;
            }
        }
        
        /// <remarks/>
        public string SHIFT {
            get {
                return this.sHIFTField;
            }
            set {
                this.sHIFTField = value;
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
        public string MC_NO {
            get {
                return this.mC_NOField;
            }
            set {
                this.mC_NOField = value;
            }
        }
        
        /// <remarks/>
        public int QTY {
            get {
                return this.qTYField;
            }
            set {
                this.qTYField = value;
            }
        }
        
        /// <remarks/>
        public int BOX_QTY {
            get {
                return this.bOX_QTYField;
            }
            set {
                this.bOX_QTYField = value;
            }
        }
        
        /// <remarks/>
        public int BOX_SCANNED {
            get {
                return this.bOX_SCANNEDField;
            }
            set {
                this.bOX_SCANNEDField = value;
            }
        }
        
        /// <remarks/>
        public int ASG_NG {
            get {
                return this.aSG_NGField;
            }
            set {
                this.aSG_NGField = value;
            }
        }
        
        /// <remarks/>
        public int NG_QTY {
            get {
                return this.nG_QTYField;
            }
            set {
                this.nG_QTYField = value;
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
    }
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class ProductCard_Status : ProductCard {
        
        private string sTATUSField;
        
        private System.Nullable<System.DateTime> pROCESS_DATEField;
        
        private int rEP_QTYField;
        
        /// <remarks/>
        public string STATUS {
            get {
                return this.sTATUSField;
            }
            set {
                this.sTATUSField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> PROCESS_DATE {
            get {
                return this.pROCESS_DATEField;
            }
            set {
                this.pROCESS_DATEField = value;
            }
        }
        
        /// <remarks/>
        public int REP_QTY {
            get {
                return this.rEP_QTYField;
            }
            set {
                this.rEP_QTYField = value;
            }
        }
    }
}
