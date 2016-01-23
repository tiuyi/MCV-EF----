
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XG.Temp.Iservices
{
	public partial interface IBLLSession
    {
		IAdminActionServices IAdminActionServices{get;set;}
		IAdminLoginLogServices IAdminLoginLogServices{get;set;}
		IAdminPageServices IAdminPageServices{get;set;}
		IAdminPageAuthServices IAdminPageAuthServices{get;set;}
		IAdminRoleServices IAdminRoleServices{get;set;}
		IAdminRoleAuthServices IAdminRoleAuthServices{get;set;}
		IAdminUserServices IAdminUserServices{get;set;}
		IAdminUserAuthServices IAdminUserAuthServices{get;set;}
		IAdminUserDetailServices IAdminUserDetailServices{get;set;}
		IAgentServices IAgentServices{get;set;}
		IAgentCustDetailServices IAgentCustDetailServices{get;set;}
		IAgentCustTypeServices IAgentCustTypeServices{get;set;}
		IAgentDetailServices IAgentDetailServices{get;set;}
		IAgentTypeServices IAgentTypeServices{get;set;}
		IAreaServices IAreaServices{get;set;}
		IAttachFileServices IAttachFileServices{get;set;}
		IBulletinServices IBulletinServices{get;set;}
		ICityServices ICityServices{get;set;}
		ICompanyServices ICompanyServices{get;set;}
		IDataDictionaryServices IDataDictionaryServices{get;set;}
		IDepartmentServices IDepartmentServices{get;set;}
		IDictionaryGroupServices IDictionaryGroupServices{get;set;}
		IEmailHistoryServices IEmailHistoryServices{get;set;}
		IGouConfigServices IGouConfigServices{get;set;}
		IGroupClientServices IGroupClientServices{get;set;}
		ILog4Services ILog4Services{get;set;}
		IProvinceServices IProvinceServices{get;set;}
		ISEMTempServices ISEMTempServices{get;set;}
		ISendEmailQueueServices ISendEmailQueueServices{get;set;}
		ISMSHistoryServices ISMSHistoryServices{get;set;}
		IWeiXinHisServices IWeiXinHisServices{get;set;}
		IWeiXinRecServices IWeiXinRecServices{get;set;}
    }

}