﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.8009
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.CompactFramework.Design.Data, Version 2.0.50727.8009.
// 
namespace HTN.BITS.SCN.LOCKDOWN.ServiceRef {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="Service_CenterSoap", Namespace="http://tempuri.org/")]
    public partial class Service_Center : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public Service_Center() {
            this.Url = "http://10.211.101.7/FGTrackService/Service_Center.asmx";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/LatestVersionScanner", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string LatestVersionScanner(string currentV) {
            object[] results = this.Invoke("LatestVersionScanner", new object[] {
                        currentV});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginLatestVersionScanner(string currentV, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("LatestVersionScanner", new object[] {
                        currentV}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndLatestVersionScanner(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/DownloadFile", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] DownloadFile(string fileName) {
            object[] results = this.Invoke("DownloadFile", new object[] {
                        fileName});
            return ((byte[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginDownloadFile(string fileName, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("DownloadFile", new object[] {
                        fileName}, callback, asyncState);
        }
        
        /// <remarks/>
        public byte[] EndDownloadFile(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((byte[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/UploadFile", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string UploadFile([System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")] byte[] fs, string fileName) {
            object[] results = this.Invoke("UploadFile", new object[] {
                        fs,
                        fileName});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginUploadFile(byte[] fs, string fileName, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("UploadFile", new object[] {
                        fs,
                        fileName}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndUploadFile(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
    }
}
