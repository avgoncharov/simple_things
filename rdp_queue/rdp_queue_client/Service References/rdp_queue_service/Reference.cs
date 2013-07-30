﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18213
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace rdp_queue_client.rdp_queue_service {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RdpState", Namespace="http://schemas.datacontract.org/2004/07/rdp_queue_service")]
    [System.SerializableAttribute()]
    public partial class RdpState : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CurrentLockerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool FreeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.Queue<string> QueueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CurrentLocker {
            get {
                return this.CurrentLockerField;
            }
            set {
                if ((object.ReferenceEquals(this.CurrentLockerField, value) != true)) {
                    this.CurrentLockerField = value;
                    this.RaisePropertyChanged("CurrentLocker");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Free {
            get {
                return this.FreeField;
            }
            set {
                if ((this.FreeField.Equals(value) != true)) {
                    this.FreeField = value;
                    this.RaisePropertyChanged("Free");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.Queue<string> Queue {
            get {
                return this.QueueField;
            }
            set {
                if ((object.ReferenceEquals(this.QueueField, value) != true)) {
                    this.QueueField = value;
                    this.RaisePropertyChanged("Queue");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="rdp_queue_service.IRdpQueueService")]
    public interface IRdpQueueService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRdpQueueService/GetRdpState", ReplyAction="http://tempuri.org/IRdpQueueService/GetRdpStateResponse")]
        rdp_queue_client.rdp_queue_service.RdpState GetRdpState();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRdpQueueService/Enqueue", ReplyAction="http://tempuri.org/IRdpQueueService/EnqueueResponse")]
        void Enqueue(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRdpQueueService/LockRdp", ReplyAction="http://tempuri.org/IRdpQueueService/LockRdpResponse")]
        void LockRdp();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRdpQueueService/FreeRdp", ReplyAction="http://tempuri.org/IRdpQueueService/FreeRdpResponse")]
        void FreeRdp();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRdpQueueService/DeleteFromQueue", ReplyAction="http://tempuri.org/IRdpQueueService/DeleteFromQueueResponse")]
        void DeleteFromQueue(string email);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRdpQueueServiceChannel : rdp_queue_client.rdp_queue_service.IRdpQueueService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RdpQueueServiceClient : System.ServiceModel.ClientBase<rdp_queue_client.rdp_queue_service.IRdpQueueService>, rdp_queue_client.rdp_queue_service.IRdpQueueService {
        
        public RdpQueueServiceClient() {
        }
        
        public RdpQueueServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RdpQueueServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RdpQueueServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RdpQueueServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public rdp_queue_client.rdp_queue_service.RdpState GetRdpState() {
            return base.Channel.GetRdpState();
        }
        
        public void Enqueue(string email) {
            base.Channel.Enqueue(email);
        }
        
        public void LockRdp() {
            base.Channel.LockRdp();
        }
        
        public void FreeRdp() {
            base.Channel.FreeRdp();
        }
        
        public void DeleteFromQueue(string email) {
            base.Channel.DeleteFromQueue(email);
        }
    }
}
