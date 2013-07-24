﻿#region Version Info
/* ========================================================================
* 【本类功能概述】
* 
* 作者：王军 时间：2013/3/19 20:53:54
* 文件名：TestHandler
* 版本：V1.0.1
* 联系方式：511522329  
*
* 修改者： 时间： 
* 修改说明：
* ========================================================================
*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloData.AppHandlers;
using HelloData.FWCommon;


namespace HelloData.Web.AppHandlers
{
    public class TestHandler : BaseHandler
    {
        public override IAppHandler CreateInstance()
        {
            return new TestHandler();
        }

        public HandlerResponse Do()
        {
            return new HandlerResponse().GetDefaultResponse();
        }

        public override string HandlerName
        {
            get { return "demo"; }
        }
    }
}
