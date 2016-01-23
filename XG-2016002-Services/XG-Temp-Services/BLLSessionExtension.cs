
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XG.Temp.Iservices;
 

namespace XG.Temp.Services
{
	public partial class BLLSession:IBLLSession
    {
		#region 01 业务接口 IAdminActionServices
		IAdminActionServices iAdminActionServices;
		public IAdminActionServices IAdminActionServices
		{
			get
			{
				if(iAdminActionServices==null)
					iAdminActionServices= new AdminActionServices();
				return iAdminActionServices;
			}
			set
			{
				iAdminActionServices= value;
			}
		}
		#endregion

		#region 02 业务接口 IAdminLoginLogServices
		IAdminLoginLogServices iAdminLoginLogServices;
		public IAdminLoginLogServices IAdminLoginLogServices
		{
			get
			{
				if(iAdminLoginLogServices==null)
					iAdminLoginLogServices= new AdminLoginLogServices();
				return iAdminLoginLogServices;
			}
			set
			{
				iAdminLoginLogServices= value;
			}
		}
		#endregion

		#region 03 业务接口 IAdminPageServices
		IAdminPageServices iAdminPageServices;
		public IAdminPageServices IAdminPageServices
		{
			get
			{
				if(iAdminPageServices==null)
					iAdminPageServices= new AdminPageServices();
				return iAdminPageServices;
			}
			set
			{
				iAdminPageServices= value;
			}
		}
		#endregion

		#region 04 业务接口 IAdminPageAuthServices
		IAdminPageAuthServices iAdminPageAuthServices;
		public IAdminPageAuthServices IAdminPageAuthServices
		{
			get
			{
				if(iAdminPageAuthServices==null)
					iAdminPageAuthServices= new AdminPageAuthServices();
				return iAdminPageAuthServices;
			}
			set
			{
				iAdminPageAuthServices= value;
			}
		}
		#endregion

		#region 05 业务接口 IAdminRoleServices
		IAdminRoleServices iAdminRoleServices;
		public IAdminRoleServices IAdminRoleServices
		{
			get
			{
				if(iAdminRoleServices==null)
					iAdminRoleServices= new AdminRoleServices();
				return iAdminRoleServices;
			}
			set
			{
				iAdminRoleServices= value;
			}
		}
		#endregion

		#region 06 业务接口 IAdminRoleAuthServices
		IAdminRoleAuthServices iAdminRoleAuthServices;
		public IAdminRoleAuthServices IAdminRoleAuthServices
		{
			get
			{
				if(iAdminRoleAuthServices==null)
					iAdminRoleAuthServices= new AdminRoleAuthServices();
				return iAdminRoleAuthServices;
			}
			set
			{
				iAdminRoleAuthServices= value;
			}
		}
		#endregion

		#region 07 业务接口 IAdminUserServices
		IAdminUserServices iAdminUserServices;
		public IAdminUserServices IAdminUserServices
		{
			get
			{
				if(iAdminUserServices==null)
					iAdminUserServices= new AdminUserServices();
				return iAdminUserServices;
			}
			set
			{
				iAdminUserServices= value;
			}
		}
		#endregion

		#region 08 业务接口 IAdminUserAuthServices
		IAdminUserAuthServices iAdminUserAuthServices;
		public IAdminUserAuthServices IAdminUserAuthServices
		{
			get
			{
				if(iAdminUserAuthServices==null)
					iAdminUserAuthServices= new AdminUserAuthServices();
				return iAdminUserAuthServices;
			}
			set
			{
				iAdminUserAuthServices= value;
			}
		}
		#endregion

		#region 09 业务接口 IAdminUserDetailServices
		IAdminUserDetailServices iAdminUserDetailServices;
		public IAdminUserDetailServices IAdminUserDetailServices
		{
			get
			{
				if(iAdminUserDetailServices==null)
					iAdminUserDetailServices= new AdminUserDetailServices();
				return iAdminUserDetailServices;
			}
			set
			{
				iAdminUserDetailServices= value;
			}
		}
		#endregion

		#region 10 业务接口 IAgentServices
		IAgentServices iAgentServices;
		public IAgentServices IAgentServices
		{
			get
			{
				if(iAgentServices==null)
					iAgentServices= new AgentServices();
				return iAgentServices;
			}
			set
			{
				iAgentServices= value;
			}
		}
		#endregion

		#region 11 业务接口 IAgentCustDetailServices
		IAgentCustDetailServices iAgentCustDetailServices;
		public IAgentCustDetailServices IAgentCustDetailServices
		{
			get
			{
				if(iAgentCustDetailServices==null)
					iAgentCustDetailServices= new AgentCustDetailServices();
				return iAgentCustDetailServices;
			}
			set
			{
				iAgentCustDetailServices= value;
			}
		}
		#endregion

		#region 12 业务接口 IAgentCustTypeServices
		IAgentCustTypeServices iAgentCustTypeServices;
		public IAgentCustTypeServices IAgentCustTypeServices
		{
			get
			{
				if(iAgentCustTypeServices==null)
					iAgentCustTypeServices= new AgentCustTypeServices();
				return iAgentCustTypeServices;
			}
			set
			{
				iAgentCustTypeServices= value;
			}
		}
		#endregion

		#region 13 业务接口 IAgentDetailServices
		IAgentDetailServices iAgentDetailServices;
		public IAgentDetailServices IAgentDetailServices
		{
			get
			{
				if(iAgentDetailServices==null)
					iAgentDetailServices= new AgentDetailServices();
				return iAgentDetailServices;
			}
			set
			{
				iAgentDetailServices= value;
			}
		}
		#endregion

		#region 14 业务接口 IAgentTypeServices
		IAgentTypeServices iAgentTypeServices;
		public IAgentTypeServices IAgentTypeServices
		{
			get
			{
				if(iAgentTypeServices==null)
					iAgentTypeServices= new AgentTypeServices();
				return iAgentTypeServices;
			}
			set
			{
				iAgentTypeServices= value;
			}
		}
		#endregion

		#region 15 业务接口 IAreaServices
		IAreaServices iAreaServices;
		public IAreaServices IAreaServices
		{
			get
			{
				if(iAreaServices==null)
					iAreaServices= new AreaServices();
				return iAreaServices;
			}
			set
			{
				iAreaServices= value;
			}
		}
		#endregion

		#region 16 业务接口 IAttachFileServices
		IAttachFileServices iAttachFileServices;
		public IAttachFileServices IAttachFileServices
		{
			get
			{
				if(iAttachFileServices==null)
					iAttachFileServices= new AttachFileServices();
				return iAttachFileServices;
			}
			set
			{
				iAttachFileServices= value;
			}
		}
		#endregion

		#region 17 业务接口 IBulletinServices
		IBulletinServices iBulletinServices;
		public IBulletinServices IBulletinServices
		{
			get
			{
				if(iBulletinServices==null)
					iBulletinServices= new BulletinServices();
				return iBulletinServices;
			}
			set
			{
				iBulletinServices= value;
			}
		}
		#endregion

		#region 18 业务接口 ICityServices
		ICityServices iCityServices;
		public ICityServices ICityServices
		{
			get
			{
				if(iCityServices==null)
					iCityServices= new CityServices();
				return iCityServices;
			}
			set
			{
				iCityServices= value;
			}
		}
		#endregion

		#region 19 业务接口 ICompanyServices
		ICompanyServices iCompanyServices;
		public ICompanyServices ICompanyServices
		{
			get
			{
				if(iCompanyServices==null)
					iCompanyServices= new CompanyServices();
				return iCompanyServices;
			}
			set
			{
				iCompanyServices= value;
			}
		}
		#endregion

		#region 20 业务接口 IDataDictionaryServices
		IDataDictionaryServices iDataDictionaryServices;
		public IDataDictionaryServices IDataDictionaryServices
		{
			get
			{
				if(iDataDictionaryServices==null)
					iDataDictionaryServices= new DataDictionaryServices();
				return iDataDictionaryServices;
			}
			set
			{
				iDataDictionaryServices= value;
			}
		}
		#endregion

		#region 21 业务接口 IDepartmentServices
		IDepartmentServices iDepartmentServices;
		public IDepartmentServices IDepartmentServices
		{
			get
			{
				if(iDepartmentServices==null)
					iDepartmentServices= new DepartmentServices();
				return iDepartmentServices;
			}
			set
			{
				iDepartmentServices= value;
			}
		}
		#endregion

		#region 22 业务接口 IDictionaryGroupServices
		IDictionaryGroupServices iDictionaryGroupServices;
		public IDictionaryGroupServices IDictionaryGroupServices
		{
			get
			{
				if(iDictionaryGroupServices==null)
					iDictionaryGroupServices= new DictionaryGroupServices();
				return iDictionaryGroupServices;
			}
			set
			{
				iDictionaryGroupServices= value;
			}
		}
		#endregion

		#region 23 业务接口 IEmailHistoryServices
		IEmailHistoryServices iEmailHistoryServices;
		public IEmailHistoryServices IEmailHistoryServices
		{
			get
			{
				if(iEmailHistoryServices==null)
					iEmailHistoryServices= new EmailHistoryServices();
				return iEmailHistoryServices;
			}
			set
			{
				iEmailHistoryServices= value;
			}
		}
		#endregion

		#region 24 业务接口 IGouConfigServices
		IGouConfigServices iGouConfigServices;
		public IGouConfigServices IGouConfigServices
		{
			get
			{
				if(iGouConfigServices==null)
					iGouConfigServices= new GouConfigServices();
				return iGouConfigServices;
			}
			set
			{
				iGouConfigServices= value;
			}
		}
		#endregion

		#region 25 业务接口 IGroupClientServices
		IGroupClientServices iGroupClientServices;
		public IGroupClientServices IGroupClientServices
		{
			get
			{
				if(iGroupClientServices==null)
					iGroupClientServices= new GroupClientServices();
				return iGroupClientServices;
			}
			set
			{
				iGroupClientServices= value;
			}
		}
		#endregion

		#region 26 业务接口 ILog4Services
		ILog4Services iLog4Services;
		public ILog4Services ILog4Services
		{
			get
			{
				if(iLog4Services==null)
					iLog4Services= new Log4Services();
				return iLog4Services;
			}
			set
			{
				iLog4Services= value;
			}
		}
		#endregion

		#region 27 业务接口 IProvinceServices
		IProvinceServices iProvinceServices;
		public IProvinceServices IProvinceServices
		{
			get
			{
				if(iProvinceServices==null)
					iProvinceServices= new ProvinceServices();
				return iProvinceServices;
			}
			set
			{
				iProvinceServices= value;
			}
		}
		#endregion

		#region 28 业务接口 ISEMTempServices
		ISEMTempServices iSEMTempServices;
		public ISEMTempServices ISEMTempServices
		{
			get
			{
				if(iSEMTempServices==null)
					iSEMTempServices= new SEMTempServices();
				return iSEMTempServices;
			}
			set
			{
				iSEMTempServices= value;
			}
		}
		#endregion

		#region 29 业务接口 ISendEmailQueueServices
		ISendEmailQueueServices iSendEmailQueueServices;
		public ISendEmailQueueServices ISendEmailQueueServices
		{
			get
			{
				if(iSendEmailQueueServices==null)
					iSendEmailQueueServices= new SendEmailQueueServices();
				return iSendEmailQueueServices;
			}
			set
			{
				iSendEmailQueueServices= value;
			}
		}
		#endregion

		#region 30 业务接口 ISMSHistoryServices
		ISMSHistoryServices iSMSHistoryServices;
		public ISMSHistoryServices ISMSHistoryServices
		{
			get
			{
				if(iSMSHistoryServices==null)
					iSMSHistoryServices= new SMSHistoryServices();
				return iSMSHistoryServices;
			}
			set
			{
				iSMSHistoryServices= value;
			}
		}
		#endregion

		#region 31 业务接口 IWeiXinHisServices
		IWeiXinHisServices iWeiXinHisServices;
		public IWeiXinHisServices IWeiXinHisServices
		{
			get
			{
				if(iWeiXinHisServices==null)
					iWeiXinHisServices= new WeiXinHisServices();
				return iWeiXinHisServices;
			}
			set
			{
				iWeiXinHisServices= value;
			}
		}
		#endregion

		#region 32 业务接口 IWeiXinRecServices
		IWeiXinRecServices iWeiXinRecServices;
		public IWeiXinRecServices IWeiXinRecServices
		{
			get
			{
				if(iWeiXinRecServices==null)
					iWeiXinRecServices= new WeiXinRecServices();
				return iWeiXinRecServices;
			}
			set
			{
				iWeiXinRecServices= value;
			}
		}
		#endregion

    }

}