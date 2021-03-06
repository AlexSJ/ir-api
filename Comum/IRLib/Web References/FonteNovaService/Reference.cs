﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.34014.
// 
#pragma warning disable 1591

namespace IRLib.FonteNovaService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="WSBaseBinding", Namespace="http://imply.com")]
    public partial class WSBase : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback bloquearOperationCompleted;
        
        private System.Threading.SendOrPostCallback efetuarLoginOperationCompleted;
        
        private System.Threading.SendOrPostCallback efetuarLogoutOperationCompleted;
        
        private System.Threading.SendOrPostCallback inserirOperationCompleted;
        
        private System.Threading.SendOrPostCallback liberarOperationCompleted;
        
        private System.Threading.SendOrPostCallback listarTiposOperationCompleted;
        
        private System.Threading.SendOrPostCallback verificarCodigoAcessouOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public WSBase() {
            this.Url = global::IRLib.Properties.Settings.Default.IRLib_FonteNovaService_WSBase;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event bloquearCompletedEventHandler bloquearCompleted;
        
        /// <remarks/>
        public event efetuarLoginCompletedEventHandler efetuarLoginCompleted;
        
        /// <remarks/>
        public event efetuarLogoutCompletedEventHandler efetuarLogoutCompleted;
        
        /// <remarks/>
        public event inserirCompletedEventHandler inserirCompleted;
        
        /// <remarks/>
        public event liberarCompletedEventHandler liberarCompleted;
        
        /// <remarks/>
        public event listarTiposCompletedEventHandler listarTiposCompleted;
        
        /// <remarks/>
        public event verificarCodigoAcessouCompletedEventHandler verificarCodigoAcessouCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://10.72.6.8/Circus/ws.php?class=WSBase&method=bloquear", RequestNamespace="http://imply.com", ResponseNamespace="http://imply.com")]
        [return: System.Xml.Serialization.SoapElementAttribute("bloquearReturn")]
        public bool bloquear(string AChave, string aIdEvento, string aCodigo, string aMsgDisplay1Linha1, string aMsgDisplay1Linha2, string aMsgDisplay2Linha1, string aMsgDisplay2Linha2) {
            object[] results = this.Invoke("bloquear", new object[] {
                        AChave,
                        aIdEvento,
                        aCodigo,
                        aMsgDisplay1Linha1,
                        aMsgDisplay1Linha2,
                        aMsgDisplay2Linha1,
                        aMsgDisplay2Linha2});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void bloquearAsync(string AChave, string aIdEvento, string aCodigo, string aMsgDisplay1Linha1, string aMsgDisplay1Linha2, string aMsgDisplay2Linha1, string aMsgDisplay2Linha2) {
            this.bloquearAsync(AChave, aIdEvento, aCodigo, aMsgDisplay1Linha1, aMsgDisplay1Linha2, aMsgDisplay2Linha1, aMsgDisplay2Linha2, null);
        }
        
        /// <remarks/>
        public void bloquearAsync(string AChave, string aIdEvento, string aCodigo, string aMsgDisplay1Linha1, string aMsgDisplay1Linha2, string aMsgDisplay2Linha1, string aMsgDisplay2Linha2, object userState) {
            if ((this.bloquearOperationCompleted == null)) {
                this.bloquearOperationCompleted = new System.Threading.SendOrPostCallback(this.OnbloquearOperationCompleted);
            }
            this.InvokeAsync("bloquear", new object[] {
                        AChave,
                        aIdEvento,
                        aCodigo,
                        aMsgDisplay1Linha1,
                        aMsgDisplay1Linha2,
                        aMsgDisplay2Linha1,
                        aMsgDisplay2Linha2}, this.bloquearOperationCompleted, userState);
        }
        
        private void OnbloquearOperationCompleted(object arg) {
            if ((this.bloquearCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.bloquearCompleted(this, new bloquearCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://10.72.6.8/Circus/ws.php?class=WSBase&method=efetuarLogin", RequestNamespace="http://imply.com", ResponseNamespace="http://imply.com")]
        [return: System.Xml.Serialization.SoapElementAttribute("efetuarLoginReturn")]
        public string efetuarLogin(string AUsuario, string ASenha) {
            object[] results = this.Invoke("efetuarLogin", new object[] {
                        AUsuario,
                        ASenha});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void efetuarLoginAsync(string AUsuario, string ASenha) {
            this.efetuarLoginAsync(AUsuario, ASenha, null);
        }
        
        /// <remarks/>
        public void efetuarLoginAsync(string AUsuario, string ASenha, object userState) {
            if ((this.efetuarLoginOperationCompleted == null)) {
                this.efetuarLoginOperationCompleted = new System.Threading.SendOrPostCallback(this.OnefetuarLoginOperationCompleted);
            }
            this.InvokeAsync("efetuarLogin", new object[] {
                        AUsuario,
                        ASenha}, this.efetuarLoginOperationCompleted, userState);
        }
        
        private void OnefetuarLoginOperationCompleted(object arg) {
            if ((this.efetuarLoginCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.efetuarLoginCompleted(this, new efetuarLoginCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://10.72.6.8/Circus/ws.php?class=WSBase&method=efetuarLogout", RequestNamespace="http://imply.com", ResponseNamespace="http://imply.com")]
        [return: System.Xml.Serialization.SoapElementAttribute("efetuarLogoutReturn")]
        public bool efetuarLogout(string AChave) {
            object[] results = this.Invoke("efetuarLogout", new object[] {
                        AChave});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void efetuarLogoutAsync(string AChave) {
            this.efetuarLogoutAsync(AChave, null);
        }
        
        /// <remarks/>
        public void efetuarLogoutAsync(string AChave, object userState) {
            if ((this.efetuarLogoutOperationCompleted == null)) {
                this.efetuarLogoutOperationCompleted = new System.Threading.SendOrPostCallback(this.OnefetuarLogoutOperationCompleted);
            }
            this.InvokeAsync("efetuarLogout", new object[] {
                        AChave}, this.efetuarLogoutOperationCompleted, userState);
        }
        
        private void OnefetuarLogoutOperationCompleted(object arg) {
            if ((this.efetuarLogoutCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.efetuarLogoutCompleted(this, new efetuarLogoutCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://10.72.6.8/Circus/ws.php?class=WSBase&method=inserir", RequestNamespace="http://imply.com", ResponseNamespace="http://imply.com")]
        [return: System.Xml.Serialization.SoapElementAttribute("inserirReturn")]
        public string inserir(string AChave, string ACodigoAcessoTipo, string ACodigoAcesso, string AExtra) {
            object[] results = this.Invoke("inserir", new object[] {
                        AChave,
                        ACodigoAcessoTipo,
                        ACodigoAcesso,
                        AExtra});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void inserirAsync(string AChave, string ACodigoAcessoTipo, string ACodigoAcesso, string AExtra) {
            this.inserirAsync(AChave, ACodigoAcessoTipo, ACodigoAcesso, AExtra, null);
        }
        
        /// <remarks/>
        public void inserirAsync(string AChave, string ACodigoAcessoTipo, string ACodigoAcesso, string AExtra, object userState) {
            if ((this.inserirOperationCompleted == null)) {
                this.inserirOperationCompleted = new System.Threading.SendOrPostCallback(this.OninserirOperationCompleted);
            }
            this.InvokeAsync("inserir", new object[] {
                        AChave,
                        ACodigoAcessoTipo,
                        ACodigoAcesso,
                        AExtra}, this.inserirOperationCompleted, userState);
        }
        
        private void OninserirOperationCompleted(object arg) {
            if ((this.inserirCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.inserirCompleted(this, new inserirCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://10.72.6.8/Circus/ws.php?class=WSBase&method=liberar", RequestNamespace="http://imply.com", ResponseNamespace="http://imply.com")]
        [return: System.Xml.Serialization.SoapElementAttribute("liberarReturn")]
        public bool liberar(string AChave, string aIdEvento, string aCodigo) {
            object[] results = this.Invoke("liberar", new object[] {
                        AChave,
                        aIdEvento,
                        aCodigo});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void liberarAsync(string AChave, string aIdEvento, string aCodigo) {
            this.liberarAsync(AChave, aIdEvento, aCodigo, null);
        }
        
        /// <remarks/>
        public void liberarAsync(string AChave, string aIdEvento, string aCodigo, object userState) {
            if ((this.liberarOperationCompleted == null)) {
                this.liberarOperationCompleted = new System.Threading.SendOrPostCallback(this.OnliberarOperationCompleted);
            }
            this.InvokeAsync("liberar", new object[] {
                        AChave,
                        aIdEvento,
                        aCodigo}, this.liberarOperationCompleted, userState);
        }
        
        private void OnliberarOperationCompleted(object arg) {
            if ((this.liberarCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.liberarCompleted(this, new liberarCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://10.72.6.8/Circus/ws.php?class=WSBase&method=listarTipos", RequestNamespace="http://imply.com", ResponseNamespace="http://imply.com")]
        [return: System.Xml.Serialization.SoapElementAttribute("listarTiposReturn")]
        public string listarTipos(string AChave) {
            object[] results = this.Invoke("listarTipos", new object[] {
                        AChave});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void listarTiposAsync(string AChave) {
            this.listarTiposAsync(AChave, null);
        }
        
        /// <remarks/>
        public void listarTiposAsync(string AChave, object userState) {
            if ((this.listarTiposOperationCompleted == null)) {
                this.listarTiposOperationCompleted = new System.Threading.SendOrPostCallback(this.OnlistarTiposOperationCompleted);
            }
            this.InvokeAsync("listarTipos", new object[] {
                        AChave}, this.listarTiposOperationCompleted, userState);
        }
        
        private void OnlistarTiposOperationCompleted(object arg) {
            if ((this.listarTiposCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.listarTiposCompleted(this, new listarTiposCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://10.72.6.8/Circus/ws.php?class=WSBase&method=verificarCodigoAcessou", RequestNamespace="http://imply.com", ResponseNamespace="http://imply.com")]
        [return: System.Xml.Serialization.SoapElementAttribute("verificarCodigoAcessouReturn")]
        public string verificarCodigoAcessou(string AChave, string aCodigo) {
            object[] results = this.Invoke("verificarCodigoAcessou", new object[] {
                        AChave,
                        aCodigo});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void verificarCodigoAcessouAsync(string AChave, string aCodigo) {
            this.verificarCodigoAcessouAsync(AChave, aCodigo, null);
        }
        
        /// <remarks/>
        public void verificarCodigoAcessouAsync(string AChave, string aCodigo, object userState) {
            if ((this.verificarCodigoAcessouOperationCompleted == null)) {
                this.verificarCodigoAcessouOperationCompleted = new System.Threading.SendOrPostCallback(this.OnverificarCodigoAcessouOperationCompleted);
            }
            this.InvokeAsync("verificarCodigoAcessou", new object[] {
                        AChave,
                        aCodigo}, this.verificarCodigoAcessouOperationCompleted, userState);
        }
        
        private void OnverificarCodigoAcessouOperationCompleted(object arg) {
            if ((this.verificarCodigoAcessouCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.verificarCodigoAcessouCompleted(this, new verificarCodigoAcessouCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void bloquearCompletedEventHandler(object sender, bloquearCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class bloquearCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal bloquearCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void efetuarLoginCompletedEventHandler(object sender, efetuarLoginCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class efetuarLoginCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal efetuarLoginCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void efetuarLogoutCompletedEventHandler(object sender, efetuarLogoutCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class efetuarLogoutCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal efetuarLogoutCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void inserirCompletedEventHandler(object sender, inserirCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class inserirCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal inserirCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void liberarCompletedEventHandler(object sender, liberarCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class liberarCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal liberarCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void listarTiposCompletedEventHandler(object sender, listarTiposCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class listarTiposCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal listarTiposCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void verificarCodigoAcessouCompletedEventHandler(object sender, verificarCodigoAcessouCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class verificarCodigoAcessouCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal verificarCodigoAcessouCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591
