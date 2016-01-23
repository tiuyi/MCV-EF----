
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XG.Temp.IRespositry
{
	public partial interface IDBSession
    {
		IAdminActionRespositry IAdminActionRespositry{get;set;}
		IAdminLoginLogRespositry IAdminLoginLogRespositry{get;set;}
		IAdminPageRespositry IAdminPageRespositry{get;set;}
		IAdminPageAuthRespositry IAdminPageAuthRespositry{get;set;}
		IAdminRoleRespositry IAdminRoleRespositry{get;set;}
		IAdminRoleAuthRespositry IAdminRoleAuthRespositry{get;set;}
		IAdminUserRespositry IAdminUserRespositry{get;set;}
		IAdminUserAuthRespositry IAdminUserAuthRespositry{get;set;}
		IAdminUserDetailRespositry IAdminUserDetailRespositry{get;set;}
		IAgentRespositry IAgentRespositry{get;set;}
		IAgentCustDetailRespositry IAgentCustDetailRespositry{get;set;}
		IAgentCustTypeRespositry IAgentCustTypeRespositry{get;set;}
		IAgentDetailRespositry IAgentDetailRespositry{get;set;}
		IAgentTypeRespositry IAgentTypeRespositry{get;set;}
		IAreaRespositry IAreaRespositry{get;set;}
		IAttachFileRespositry IAttachFileRespositry{get;set;}
		IBulletinRespositry IBulletinRespositry{get;set;}
		ICityRespositry ICityRespositry{get;set;}
		ICompanyRespositry ICompanyRespositry{get;set;}
		IDataDictionaryRespositry IDataDictionaryRespositry{get;set;}
		IDepartmentRespositry IDepartmentRespositry{get;set;}
		IDictionaryGroupRespositry IDictionaryGroupRespositry{get;set;}
		IEmailHistoryRespositry IEmailHistoryRespositry{get;set;}
		IGouConfigRespositry IGouConfigRespositry{get;set;}
		IGroupClientRespositry IGroupClientRespositry{get;set;}
		ILog4Respositry ILog4Respositry{get;set;}
		IProvinceRespositry IProvinceRespositry{get;set;}
		ISEMTempRespositry ISEMTempRespositry{get;set;}
		ISendEmailQueueRespositry ISendEmailQueueRespositry{get;set;}
		ISMSHistoryRespositry ISMSHistoryRespositry{get;set;}
		IWeiXinHisRespositry IWeiXinHisRespositry{get;set;}
		IWeiXinRecRespositry IWeiXinRecRespositry{get;set;}
    }

}