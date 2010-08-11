﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Site.UserEventsServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EventInfo", Namespace="http://schemas.datacontract.org/2004/07/Server.Service")]
    [System.SerializableAttribute()]
    public partial struct EventInfo : System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime CreatedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int FileIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FileNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long FileSizeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PathField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Created {
            get {
                return this.CreatedField;
            }
            set {
                if ((this.CreatedField.Equals(value) != true)) {
                    this.CreatedField = value;
                    this.RaisePropertyChanged("Created");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int FileId {
            get {
                return this.FileIdField;
            }
            set {
                if ((this.FileIdField.Equals(value) != true)) {
                    this.FileIdField = value;
                    this.RaisePropertyChanged("FileId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FileName {
            get {
                return this.FileNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FileNameField, value) != true)) {
                    this.FileNameField = value;
                    this.RaisePropertyChanged("FileName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long FileSize {
            get {
                return this.FileSizeField;
            }
            set {
                if ((this.FileSizeField.Equals(value) != true)) {
                    this.FileSizeField = value;
                    this.RaisePropertyChanged("FileSize");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Path {
            get {
                return this.PathField;
            }
            set {
                if ((object.ReferenceEquals(this.PathField, value) != true)) {
                    this.PathField = value;
                    this.RaisePropertyChanged("Path");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserEventsServiceReference.IUserEvents")]
    public interface IUserEvents {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserEvents/GetEvents", ReplyAction="http://tempuri.org/IUserEvents/GetEventsResponse")]
        Site.UserEventsServiceReference.EventInfo[] GetEvents(string userEmail, string userPass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserEvents/TempFunction", ReplyAction="http://tempuri.org/IUserEvents/TempFunctionResponse")]
        int TempFunction(string userEmail, string userPass);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserEventsChannel : Site.UserEventsServiceReference.IUserEvents, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserEventsClient : System.ServiceModel.ClientBase<Site.UserEventsServiceReference.IUserEvents>, Site.UserEventsServiceReference.IUserEvents {
        
        public UserEventsClient() {
        }
        
        public UserEventsClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserEventsClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserEventsClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserEventsClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Site.UserEventsServiceReference.EventInfo[] GetEvents(string userEmail, string userPass) {
            return base.Channel.GetEvents(userEmail, userPass);
        }
        
        public int TempFunction(string userEmail, string userPass) {
            return base.Channel.TempFunction(userEmail, userPass);
        }
    }
}
