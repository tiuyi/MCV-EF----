//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace XG.Temp.Model.SEModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class SEAgentDetail : SEBaseModel
    {
        public int? AgentDetailID { get; set; }
        public int? ADAgentID { get; set; }
        public string AgentAddress { get; set; }
        public string AgentMailAddress { get; set; }
        public string AgentLinkMan { get; set; }
        public string AgentTelPhone { get; set; }
        public string AgentEmail { get; set; }
        public string AgentPhone { get; set; }
        public string AgentFax { get; set; }
        public string AgentPostCode { get; set; }
        public string AgentUserName { get; set; }
        public Nullable<System.DateTime> AgentUpdateTime { get; set; }public Nullable<System.DateTime> FromAgentUpdateTime { get; set; }public Nullable<System.DateTime> ToAgentUpdateTime { get; set; }
        public string AgentIDCard { get; set; }
        public string AgentRemark { get; set; }
        public Nullable<System.DateTime> AgentEndTime { get; set; }public Nullable<System.DateTime> FromAgentEndTime { get; set; }public Nullable<System.DateTime> ToAgentEndTime { get; set; }
        public string AgentEndName { get; set; }
        public string AgentAddName { get; set; }
        public System.DateTime? AgentAddTime { get; set; }public System.DateTime? FromAgentAddTime { get; set; }public System.DateTime? ToAgentAddTime { get; set; }
        public Nullable<System.DateTime> AgentVerifyTime { get; set; }public Nullable<System.DateTime> FromAgentVerifyTime { get; set; }public Nullable<System.DateTime> ToAgentVerifyTime { get; set; }
        public string AgentVerifyName { get; set; }
        public string AgentVerifyNote { get; set; }
        public Nullable<bool> AgentIsAutoSend { get; set; }
        public Nullable<System.DateTime> AgentSendTime { get; set; }public Nullable<System.DateTime> FromAgentSendTime { get; set; }public Nullable<System.DateTime> ToAgentSendTime { get; set; }
    
        public virtual Agent Agent { get; set; }
    }
}
