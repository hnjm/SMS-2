/*
以下代码为python3.0自动生成的代码，请不要擅自修改
生成时间:2013-08-21 23:54:05
生成机器：wangjun
author：xiaose
*/
using System;
using System.Collections.Generic; 
using System.Text;
using HelloData.FrameWork.Data;
/// <summary>
///    
/// </summary>
[Serializable]
public partial class SmsBatchInfo: BaseEntity
{
    public SmsBatchInfo(){
         base.SetIni(this,"sms_batch","ID");
    }
    /// <summary>
    /// ??ID   
    /// </summary>
    [Column(IsKeyProperty = true,AutoIncrement=true)]
    public int ID {get; set;}

    /// <summary>
    /// ??ID   
    /// </summary>
    public int AccountID {get; set;}

    /// <summary>
    /// ????	0:??? 1:??? 2:???? 3:???? 4:????   
    /// </summary>
    public int? MessageState {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string BatchName {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public string Remark {get; set;}

    /// <summary>
    /// ????   
    /// </summary>
    public string SmsContent {get; set;}

    /// <summary>
    /// ????   
    /// </summary>
    public int? Msgcount {get; set;}

    /// <summary>
    /// ????	??: 1??: 2WAPPUSH: 3   
    /// </summary>
    public int? MsgType {get; set;}

    /// <summary>
    /// ???	1???5??   
    /// </summary>
    public int? Level {get; set;}

    /// <summary>
    /// ????????   
    /// </summary>
    public bool? StateReport {get; set;}

    /// <summary>
    /// ?????   
    /// </summary>
    public string CustomNum {get; set;}

    /// <summary>
    /// ????? ????   
    /// </summary>
    public DateTime? BeginTime {get; set;}

    /// <summary>
    /// ????? ????   
    /// </summary>
    public DateTime? EndTime {get; set;}

    /// <summary>
    /// ??????   
    /// </summary>
    public DateTime? CommitTime {get; set;}

    /// <summary>
    /// ????   
    /// </summary>
    public DateTime? PostTime {get; set;}

    /// <summary>
    /// 批次状态 0提交中  1:检核中  2:等待中 3发送中  4完成
    /// </summary>
    public int? BatchState {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int? MtCount {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public int? EnterPriseID {get; set;}

    /// <summary>
    ///    
    /// </summary>
    public DateTime? CreateTime {get; set;}

    public static class Columns 
    { 
        public const string ID = "ID";
        public const string AccountID = "AccountID";
        public const string MessageState = "MessageState";
        public const string BatchName = "BatchName";
        public const string Remark = "Remark";
        public const string SmsContent = "SmsContent";
        public const string Msgcount = "Msgcount";
        public const string MsgType = "Msg_type";
        public const string Level = "Level";
        public const string StateReport = "State_report";
        public const string CustomNum = "Custom_num";
        public const string BeginTime = "Begin_time";
        public const string EndTime = "End_time";
        public const string CommitTime = "Commit_time";
        public const string PostTime = "Post_time";
        public const string BatchState = "BatchState";
        public const string MtCount = "MtCount";
        public const string EnterPriseID = "EnterPriseID";
        public const string CreateTime = "Create_time";
    }
}
