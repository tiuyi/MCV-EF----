
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using XG.Temp.IRespositry;

namespace XG.Temp.RespositryMSSQL
{
	public partial class DBSession:IRespositry.IDBSession
    {
		#region 01 数据接口 IAdminActionRespositry
		IAdminActionRespositry iAdminActionRespositry;
		public IAdminActionRespositry IAdminActionRespositry
		{
			get
			{
				if(iAdminActionRespositry==null)
					iAdminActionRespositry= new AdminActionRespositry();
				return iAdminActionRespositry;
			}
			set
			{
				iAdminActionRespositry= value;
			}
		}
		#endregion

		#region 02 数据接口 IAdminLoginLogRespositry
		IAdminLoginLogRespositry iAdminLoginLogRespositry;
		public IAdminLoginLogRespositry IAdminLoginLogRespositry
		{
			get
			{
				if(iAdminLoginLogRespositry==null)
					iAdminLoginLogRespositry= new AdminLoginLogRespositry();
				return iAdminLoginLogRespositry;
			}
			set
			{
				iAdminLoginLogRespositry= value;
			}
		}
		#endregion

		#region 03 数据接口 IAdminPageRespositry
		IAdminPageRespositry iAdminPageRespositry;
		public IAdminPageRespositry IAdminPageRespositry
		{
			get
			{
				if(iAdminPageRespositry==null)
					iAdminPageRespositry= new AdminPageRespositry();
				return iAdminPageRespositry;
			}
			set
			{
				iAdminPageRespositry= value;
			}
		}
		#endregion

		#region 04 数据接口 IAdminPageAuthRespositry
		IAdminPageAuthRespositry iAdminPageAuthRespositry;
		public IAdminPageAuthRespositry IAdminPageAuthRespositry
		{
			get
			{
				if(iAdminPageAuthRespositry==null)
					iAdminPageAuthRespositry= new AdminPageAuthRespositry();
				return iAdminPageAuthRespositry;
			}
			set
			{
				iAdminPageAuthRespositry= value;
			}
		}
		#endregion

		#region 05 数据接口 IAdminRoleRespositry
		IAdminRoleRespositry iAdminRoleRespositry;
		public IAdminRoleRespositry IAdminRoleRespositry
		{
			get
			{
				if(iAdminRoleRespositry==null)
					iAdminRoleRespositry= new AdminRoleRespositry();
				return iAdminRoleRespositry;
			}
			set
			{
				iAdminRoleRespositry= value;
			}
		}
		#endregion

		#region 06 数据接口 IAdminRoleAuthRespositry
		IAdminRoleAuthRespositry iAdminRoleAuthRespositry;
		public IAdminRoleAuthRespositry IAdminRoleAuthRespositry
		{
			get
			{
				if(iAdminRoleAuthRespositry==null)
					iAdminRoleAuthRespositry= new AdminRoleAuthRespositry();
				return iAdminRoleAuthRespositry;
			}
			set
			{
				iAdminRoleAuthRespositry= value;
			}
		}
		#endregion

		#region 07 数据接口 IAdminUserRespositry
		IAdminUserRespositry iAdminUserRespositry;
		public IAdminUserRespositry IAdminUserRespositry
		{
			get
			{
				if(iAdminUserRespositry==null)
					iAdminUserRespositry= new AdminUserRespositry();
				return iAdminUserRespositry;
			}
			set
			{
				iAdminUserRespositry= value;
			}
		}
		#endregion

		#region 08 数据接口 IAdminUserAuthRespositry
		IAdminUserAuthRespositry iAdminUserAuthRespositry;
		public IAdminUserAuthRespositry IAdminUserAuthRespositry
		{
			get
			{
				if(iAdminUserAuthRespositry==null)
					iAdminUserAuthRespositry= new AdminUserAuthRespositry();
				return iAdminUserAuthRespositry;
			}
			set
			{
				iAdminUserAuthRespositry= value;
			}
		}
		#endregion

		#region 09 数据接口 IAdminUserDetailRespositry
		IAdminUserDetailRespositry iAdminUserDetailRespositry;
		public IAdminUserDetailRespositry IAdminUserDetailRespositry
		{
			get
			{
				if(iAdminUserDetailRespositry==null)
					iAdminUserDetailRespositry= new AdminUserDetailRespositry();
				return iAdminUserDetailRespositry;
			}
			set
			{
				iAdminUserDetailRespositry= value;
			}
		}
		#endregion

		#region 10 数据接口 IAgentRespositry
		IAgentRespositry iAgentRespositry;
		public IAgentRespositry IAgentRespositry
		{
			get
			{
				if(iAgentRespositry==null)
					iAgentRespositry= new AgentRespositry();
				return iAgentRespositry;
			}
			set
			{
				iAgentRespositry= value;
			}
		}
		#endregion

		#region 11 数据接口 IAgentCustDetailRespositry
		IAgentCustDetailRespositry iAgentCustDetailRespositry;
		public IAgentCustDetailRespositry IAgentCustDetailRespositry
		{
			get
			{
				if(iAgentCustDetailRespositry==null)
					iAgentCustDetailRespositry= new AgentCustDetailRespositry();
				return iAgentCustDetailRespositry;
			}
			set
			{
				iAgentCustDetailRespositry= value;
			}
		}
		#endregion

		#region 12 数据接口 IAgentCustTypeRespositry
		IAgentCustTypeRespositry iAgentCustTypeRespositry;
		public IAgentCustTypeRespositry IAgentCustTypeRespositry
		{
			get
			{
				if(iAgentCustTypeRespositry==null)
					iAgentCustTypeRespositry= new AgentCustTypeRespositry();
				return iAgentCustTypeRespositry;
			}
			set
			{
				iAgentCustTypeRespositry= value;
			}
		}
		#endregion

		#region 13 数据接口 IAgentDetailRespositry
		IAgentDetailRespositry iAgentDetailRespositry;
		public IAgentDetailRespositry IAgentDetailRespositry
		{
			get
			{
				if(iAgentDetailRespositry==null)
					iAgentDetailRespositry= new AgentDetailRespositry();
				return iAgentDetailRespositry;
			}
			set
			{
				iAgentDetailRespositry= value;
			}
		}
		#endregion

		#region 14 数据接口 IAgentTypeRespositry
		IAgentTypeRespositry iAgentTypeRespositry;
		public IAgentTypeRespositry IAgentTypeRespositry
		{
			get
			{
				if(iAgentTypeRespositry==null)
					iAgentTypeRespositry= new AgentTypeRespositry();
				return iAgentTypeRespositry;
			}
			set
			{
				iAgentTypeRespositry= value;
			}
		}
		#endregion

		#region 15 数据接口 IAreaRespositry
		IAreaRespositry iAreaRespositry;
		public IAreaRespositry IAreaRespositry
		{
			get
			{
				if(iAreaRespositry==null)
					iAreaRespositry= new AreaRespositry();
				return iAreaRespositry;
			}
			set
			{
				iAreaRespositry= value;
			}
		}
		#endregion

		#region 16 数据接口 IAttachFileRespositry
		IAttachFileRespositry iAttachFileRespositry;
		public IAttachFileRespositry IAttachFileRespositry
		{
			get
			{
				if(iAttachFileRespositry==null)
					iAttachFileRespositry= new AttachFileRespositry();
				return iAttachFileRespositry;
			}
			set
			{
				iAttachFileRespositry= value;
			}
		}
		#endregion

		#region 17 数据接口 IBulletinRespositry
		IBulletinRespositry iBulletinRespositry;
		public IBulletinRespositry IBulletinRespositry
		{
			get
			{
				if(iBulletinRespositry==null)
					iBulletinRespositry= new BulletinRespositry();
				return iBulletinRespositry;
			}
			set
			{
				iBulletinRespositry= value;
			}
		}
		#endregion

		#region 18 数据接口 ICityRespositry
		ICityRespositry iCityRespositry;
		public ICityRespositry ICityRespositry
		{
			get
			{
				if(iCityRespositry==null)
					iCityRespositry= new CityRespositry();
				return iCityRespositry;
			}
			set
			{
				iCityRespositry= value;
			}
		}
		#endregion

		#region 19 数据接口 ICompanyRespositry
		ICompanyRespositry iCompanyRespositry;
		public ICompanyRespositry ICompanyRespositry
		{
			get
			{
				if(iCompanyRespositry==null)
					iCompanyRespositry= new CompanyRespositry();
				return iCompanyRespositry;
			}
			set
			{
				iCompanyRespositry= value;
			}
		}
		#endregion

		#region 20 数据接口 IDataDictionaryRespositry
		IDataDictionaryRespositry iDataDictionaryRespositry;
		public IDataDictionaryRespositry IDataDictionaryRespositry
		{
			get
			{
				if(iDataDictionaryRespositry==null)
					iDataDictionaryRespositry= new DataDictionaryRespositry();
				return iDataDictionaryRespositry;
			}
			set
			{
				iDataDictionaryRespositry= value;
			}
		}
		#endregion

		#region 21 数据接口 IDepartmentRespositry
		IDepartmentRespositry iDepartmentRespositry;
		public IDepartmentRespositry IDepartmentRespositry
		{
			get
			{
				if(iDepartmentRespositry==null)
					iDepartmentRespositry= new DepartmentRespositry();
				return iDepartmentRespositry;
			}
			set
			{
				iDepartmentRespositry= value;
			}
		}
		#endregion

		#region 22 数据接口 IDictionaryGroupRespositry
		IDictionaryGroupRespositry iDictionaryGroupRespositry;
		public IDictionaryGroupRespositry IDictionaryGroupRespositry
		{
			get
			{
				if(iDictionaryGroupRespositry==null)
					iDictionaryGroupRespositry= new DictionaryGroupRespositry();
				return iDictionaryGroupRespositry;
			}
			set
			{
				iDictionaryGroupRespositry= value;
			}
		}
		#endregion

		#region 23 数据接口 IEmailHistoryRespositry
		IEmailHistoryRespositry iEmailHistoryRespositry;
		public IEmailHistoryRespositry IEmailHistoryRespositry
		{
			get
			{
				if(iEmailHistoryRespositry==null)
					iEmailHistoryRespositry= new EmailHistoryRespositry();
				return iEmailHistoryRespositry;
			}
			set
			{
				iEmailHistoryRespositry= value;
			}
		}
		#endregion

		#region 24 数据接口 IGouConfigRespositry
		IGouConfigRespositry iGouConfigRespositry;
		public IGouConfigRespositry IGouConfigRespositry
		{
			get
			{
				if(iGouConfigRespositry==null)
					iGouConfigRespositry= new GouConfigRespositry();
				return iGouConfigRespositry;
			}
			set
			{
				iGouConfigRespositry= value;
			}
		}
		#endregion

		#region 25 数据接口 IGroupClientRespositry
		IGroupClientRespositry iGroupClientRespositry;
		public IGroupClientRespositry IGroupClientRespositry
		{
			get
			{
				if(iGroupClientRespositry==null)
					iGroupClientRespositry= new GroupClientRespositry();
				return iGroupClientRespositry;
			}
			set
			{
				iGroupClientRespositry= value;
			}
		}
		#endregion

		#region 26 数据接口 ILog4Respositry
		ILog4Respositry iLog4Respositry;
		public ILog4Respositry ILog4Respositry
		{
			get
			{
				if(iLog4Respositry==null)
					iLog4Respositry= new Log4Respositry();
				return iLog4Respositry;
			}
			set
			{
				iLog4Respositry= value;
			}
		}
		#endregion

		#region 27 数据接口 IProvinceRespositry
		IProvinceRespositry iProvinceRespositry;
		public IProvinceRespositry IProvinceRespositry
		{
			get
			{
				if(iProvinceRespositry==null)
					iProvinceRespositry= new ProvinceRespositry();
				return iProvinceRespositry;
			}
			set
			{
				iProvinceRespositry= value;
			}
		}
		#endregion

		#region 28 数据接口 ISEMTempRespositry
		ISEMTempRespositry iSEMTempRespositry;
		public ISEMTempRespositry ISEMTempRespositry
		{
			get
			{
				if(iSEMTempRespositry==null)
					iSEMTempRespositry= new SEMTempRespositry();
				return iSEMTempRespositry;
			}
			set
			{
				iSEMTempRespositry= value;
			}
		}
		#endregion

		#region 29 数据接口 ISendEmailQueueRespositry
		ISendEmailQueueRespositry iSendEmailQueueRespositry;
		public ISendEmailQueueRespositry ISendEmailQueueRespositry
		{
			get
			{
				if(iSendEmailQueueRespositry==null)
					iSendEmailQueueRespositry= new SendEmailQueueRespositry();
				return iSendEmailQueueRespositry;
			}
			set
			{
				iSendEmailQueueRespositry= value;
			}
		}
		#endregion

		#region 30 数据接口 ISMSHistoryRespositry
		ISMSHistoryRespositry iSMSHistoryRespositry;
		public ISMSHistoryRespositry ISMSHistoryRespositry
		{
			get
			{
				if(iSMSHistoryRespositry==null)
					iSMSHistoryRespositry= new SMSHistoryRespositry();
				return iSMSHistoryRespositry;
			}
			set
			{
				iSMSHistoryRespositry= value;
			}
		}
		#endregion

		#region 31 数据接口 IWeiXinHisRespositry
		IWeiXinHisRespositry iWeiXinHisRespositry;
		public IWeiXinHisRespositry IWeiXinHisRespositry
		{
			get
			{
				if(iWeiXinHisRespositry==null)
					iWeiXinHisRespositry= new WeiXinHisRespositry();
				return iWeiXinHisRespositry;
			}
			set
			{
				iWeiXinHisRespositry= value;
			}
		}
		#endregion

		#region 32 数据接口 IWeiXinRecRespositry
		IWeiXinRecRespositry iWeiXinRecRespositry;
		public IWeiXinRecRespositry IWeiXinRecRespositry
		{
			get
			{
				if(iWeiXinRecRespositry==null)
					iWeiXinRecRespositry= new WeiXinRecRespositry();
				return iWeiXinRecRespositry;
			}
			set
			{
				iWeiXinRecRespositry= value;
			}
		}
		#endregion

    }

}