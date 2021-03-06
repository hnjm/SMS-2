﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace SMSServer.OpenPlatform
{
    /// <summary>
    /// 亿美接口实现
    /// </summary>
    public class YMService : BaseService
    {
        //调用dll方法
        [DllImport("EUCPComm.dll", EntryPoint = "SendSMS")]  //即时发送
        public static extern int SendSMS(string sn, string mn, string ct, string priority);

        [DllImport("EUCPComm.dll", EntryPoint = "SendSMSEx")]  //即时发送(扩展)
        public static extern int SendSMSEx(string sn, string mn, string ct, string addi, string priority);

        [DllImport("EUCPComm.dll", EntryPoint = "SendScheSMS")]  // 定时发送
        public static extern int SendScheSMS(string sn, string mn, string ct, string ti, string priority);

        [DllImport("EUCPComm.dll", EntryPoint = "SendScheSMSEx")]  // 定时发送(扩展)
        public static extern int SendScheSMSEx(string sn, string mn, string ct, string ti, string addi, string priority);

        [DllImport("EUCPComm.dll", EntryPoint = "ReceiveSMS")]  // 接收短信
        public static extern int ReceiveSMS(string sn, deleSQF mySmsContent);

        [DllImport("EUCPComm.dll", EntryPoint = "ReceiveSMSEx")]  // 接收短信
        public static extern int ReceiveSMSEx(string sn, deleSQF mySmsContent);


        [DllImport("EUCPComm.dll", EntryPoint = "Register")]   // 注册 
        public static extern int Register(string sn, string pwd, string EntName, string LinkMan, string Phone, string Mobile, string Email, string Fax, string sAddress, string Postcode);

        [DllImport("EUCPComm.dll", EntryPoint = "GetBalance", CallingConvention = CallingConvention.Winapi)] // 余额 
        public static extern int GetBalance(string m, System.Text.StringBuilder balance);


        [DllImport("EUCPComm.dll", EntryPoint = "ChargeUp")]  // 存值
        public static extern int ChargeUp(string sn, string acco, string pass);

        [DllImport("EUCPComm.dll", EntryPoint = "GetPrice")]  // 价格
        public static extern int GetPrice(string m, System.Text.StringBuilder balance);

        [DllImport("EUCPComm.dll", EntryPoint = "RegistryTransfer")]  //申请转接
        public static extern int RegistryTransfer(string sn, string mn);

        [DllImport("EUCPComm.dll", EntryPoint = "CancelTransfer")]  // 注销转接
        public static extern int CancelTransfer(string sn);

        [DllImport("EUCPComm.dll", EntryPoint = "UnRegister")]  // 注销
        public static extern int UnRegister(string sn);

        [DllImport("EUCPComm.dll", EntryPoint = "SetProxy")]  // 设置代理服务器 
        public static extern int SetProxy(string IP, string Port, string UserName, string PWD);

        [DllImport("EUCPComm.dll", EntryPoint = "RegistryPwdUpd")]  // 修改序列号密码
        public static extern int RegistryPwdUpd(string sn, string oldPWD, string newPWD);

        private static List<MoInfo> mos=new List<MoInfo>();
        static void getSMSContent(string mobile, string senderaddi, string recvaddi, string ct, string sd, ref int flag)
        {
            if (flag == 1)
            {
                MoInfo moInfo = new MoInfo();
                moInfo.Content = ct;
                if (sd.Length == 14)
                {
                    int year = int.Parse(sd.Substring(0, 4).TrimStart('0'));
                    int month = int.Parse(sd.Substring(4, 2).TrimStart('0'));
                    int day = int.Parse(sd.Substring(6, 2).TrimStart('0'));
                    int hour = int.Parse(sd.Substring(8, 2).TrimStart('0'));
                    int minite = int.Parse(sd.Substring(10, 2).TrimStart('0'));
                    int second = int.Parse(sd.Substring(12, 2).TrimStart('0'));
                    moInfo.MoTime = new DateTime(year, month, day, hour, minite, second);
                }

                moInfo.Phone = mobile;
                moInfo.ExtraNub = senderaddi;
                mos.Add(moInfo);
            }

        }

        //声明委托，对回调函数进行封装。
        public delegate void deleSQF(string mobile, string senderaddi, string recvaddi, string ct, string sd, ref int flag);
        deleSQF mySmsContent = new deleSQF(getSMSContent);

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="us"></param>
        /// <returns></returns>
        public override int SendSMS(SMSSDKMassInfo smsInfos, string extendNub)
        {
            SendUser us = this.SendUser;
            //即时发送      这里是软件序列号    手机号       短信内容     优先级
            int result = 0;
            if (!string.IsNullOrEmpty(extendNub))
                result = SendSMSEx(us.serialNumber, smsInfos.Phones.ToArray().ToString(), smsInfos.Content, extendNub, us.priority);
            else
            {
                result = SendSMS(us.serialNumber, smsInfos.Phones.ToArray().ToString(), smsInfos.Content, us.priority);

            }
            if (result == 1)
                return 1;
            else if (result == 101)
                return 10;
            else if (result == 102)
                return 8;
            else if (result == 0)
                return 0;
            else if (result == 100)
                return 7;
            else if (result == 107)
                return 6;
            else if (result == 108)
                return 7;
            else if (result == 109)
                return 1;
            else if (result == 110)
                return 9;
            else if (result == 201)
                return 3;
            else
                return 8;
            //if (result == 1)
            //    return "发送成功";
            //else if (result == 101)
            //    return "网络故障";
            //else if (result == 102)
            //    return "其它故障";
            //else if (result == 0)
            //    return "失败";
            //else if (result == 100)
            //    return "序列号码为空或无效";
            //else if (result == 107)
            //    return "手机号码为空或者超过1000个";
            //else if (result == 108)
            //    return "手机号码分割符号不正确";
            //else if (result == 109)
            //    return "部分手机号码不正确，已删除，其余手机号码被发送";
            //else if (result == 110)
            //    return "短信内容为空或超长（70个汉字）";
            //else if (result == 201)
            //    return "计费失败，请充值";
            //else
            ////    return "其他故障值：" + result.ToString();
        }

        public override string GetStatusreport()
        {
            SendUser us = this.SendUser;
            return "亿美没有提供该接口";
        }
        /// <summary>
        /// 获取余额
        /// </summary>
        /// <param name="us"></param>
        /// <returns></returns>
        public override string Getbalance()
        {
            SendUser us = this.SendUser;
            StringBuilder balance = new StringBuilder(0, 20);
            //得到余额            注册号         余额
            int result = GetBalance(us.serialNumber, balance);
            string mybalance = balance.ToString(0, balance.Length - 1);
            if (result == 1)
                return mybalance + " 元";
            else if (result == 101)
                return "网络故障";
            else if (result == 102)
                return "其它故障";
            else if (result == 100)
                return "序列号码为空或无效";
            else if (result == 105)
                return "参数balance指针为空";
            else if (result == 0)
                return "失败:";
            else
                return "其他故障值:" + result.ToString();
        }
        /// <summary>
        /// 上行
        /// </summary>
        /// <param name="us"></param>
        /// <returns></returns>
        public override string Getascending()
        {
            SendUser us = this.SendUser;
            deleSQF mySmsContent = new deleSQF(getSMSContent);
            //接收短信                序列号       函数指针
            int result = 2;
            string resultString = string.Empty;
            while (result == 2)  //当result = 2 时，说明还有下一批短信等待接收，这时需重新再调用一次ReceiveSMS方法
            {
                result = ReceiveSMS(us.serialNumber, mySmsContent);
                if (result == 1)
                    resultString = "接收短信成功";
                else if (result == 101)
                    resultString = "网络故障";
                else if (result == 102)
                    resultString = "其它故障";
                else if (result == 105)
                    resultString = "参数指针为空";
                else if (result == 0)
                    resultString = "失败";
                else
                    resultString = "其他故障值：" + result.ToString();
            }
            return resultString;
        }



        public override int GetSignNum()
        {
            return 10001;
        }

        public override List<MoInfo> GetMo()
        {
            mos = new List<MoInfo>();
            SendUser us = this.SendUser;
            deleSQF mySmsContent = new deleSQF(getSMSContent);
            //接收短信(扩展)             序列号     函数指针
            int result = 2;
            while (result == 2) //当result = 2 时，说明还有下一批短信等待接收，这时需重新再调用一次ReceiveSMSEx方法
            {
                result = ReceiveSMSEx(us.serialNumber, mySmsContent); 
            }
            return mos;
        }

        public override int MassCount()
        {
            return 50;
        }

        public override int GroupCount()
        {
            return 1;
        }

        public override int SendSMS(List<SDKGroupInfo> smsInfos, string extendNub)
        {
            SendUser us = this.SendUser;
            int result = 0;
            foreach (SDKGroupInfo sdkGroupInfo in smsInfos)
            {
                if (!string.IsNullOrEmpty(extendNub))
                    result = SendSMSEx(us.serialNumber, sdkGroupInfo.Phone, sdkGroupInfo.Content, extendNub, us.priority);
                else
                {
                    result = SendSMS(us.serialNumber, sdkGroupInfo.Phone, sdkGroupInfo.Content, us.priority);
                }
            }

            if (result == 1)
                return 1;
            else if (result == 101)
                return 10;
            else if (result == 102)
                return 8;
            else if (result == 0)
                return 0;
            else if (result == 100)
                return 7;
            else if (result == 107)
                return 6;
            else if (result == 108)
                return 7;
            else if (result == 109)
                return 1;
            else if (result == 110)
                return 9;
            else if (result == 201)
                return 3;
            else
                return 8;
        }

        public override SendUser SendUser { get; set; }
    }
}
