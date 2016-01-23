 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XG.Temp.Iservices;

namespace XG.Temp.Services
{
	public partial class AdminActionServices : BaseServices<Model.AdminAction>,IAdminActionServices
    {
		public override void SetDAL()
		{
			idal = DBSession.IAdminActionRespositry;
		}
    }

	public partial class AdminLoginLogServices : BaseServices<Model.AdminLoginLog>,IAdminLoginLogServices
    {
		public override void SetDAL()
		{
			idal = DBSession.IAdminLoginLogRespositry;
		}
    }

	public partial class AdminPageServices : BaseServices<Model.AdminPage>,IAdminPageServices
    {
		public override void SetDAL()
		{
			idal = DBSession.IAdminPageRespositry;
		}
    }

	public partial class AdminPageAuthServices : BaseServices<Model.AdminPageAuth>,IAdminPageAuthServices
    {
		public override void SetDAL()
		{
			idal = DBSession.IAdminPageAuthRespositry;
		}
    }

	public partial class AdminRoleServices : BaseServices<Model.AdminRole>,IAdminRoleServices
    {
		public override void SetDAL()
		{
			idal = DBSession.IAdminRoleRespositry;
		}
    }

	public partial class AdminRoleAuthServices : BaseServices<Model.AdminRoleAuth>,IAdminRoleAuthServices
    {
		public override void SetDAL()
		{
			idal = DBSession.IAdminRoleAuthRespositry;
		}
    }

	public partial class AdminUserServices : BaseServices<Model.AdminUser>,IAdminUserServices
    {
		public override void SetDAL()
		{
			idal = DBSession.IAdminUserRespositry;
		}
    }

	public partial class AdminUserAuthServices : BaseServices<Model.AdminUserAuth>,IAdminUserAuthServices
    {
		public override void SetDAL()
		{
			idal = DBSession.IAdminUserAuthRespositry;
		}
    }

	public partial class AdminUserDetailServices : BaseServices<Model.AdminUserDetail>,IAdminUserDetailServices
    {
		public override void SetDAL()
		{
			idal = DBSession.IAdminUserDetailRespositry;
		}
    }

	public partial class AgentServices : BaseServices<Model.Agent>,IAgentServices
    {
		public override void SetDAL()
		{
			idal = DBSession.IAgentRespositry;
		}
    }

	public partial class AgentCustDetailServices : BaseServices<Model.AgentCustDetail>,IAgentCustDetailServices
    {
		public override void SetDAL()
		{
			idal = DBSession.IAgentCustDetailRespositry;
		}
    }

	public partial class AgentCustTypeServices : BaseServices<Model.AgentCustType>,IAgentCustTypeServices
    {
		public override void SetDAL()
		{
			idal = DBSession.IAgentCustTypeRespositry;
		}
    }

	public partial class AgentDetailServices : BaseServices<Model.AgentDetail>,IAgentDetailServices
    {
		public override void SetDAL()
		{
			idal = DBSession.IAgentDetailRespositry;
		}
    }

	public partial class AgentTypeServices : BaseServices<Model.AgentType>,IAgentTypeServices
    {
		public override void SetDAL()
		{
			idal = DBSession.IAgentTypeRespositry;
		}
    }

	public partial class AreaServices : BaseServices<Model.Area>,IAreaServices
    {
		public override void SetDAL()
		{
			idal = DBSession.IAreaRespositry;
		}
    }

	public partial class AttachFileServices : BaseServices<Model.AttachFile>,IAttachFileServices
    {
		public override void SetDAL()
		{
			idal = DBSession.IAttachFileRespositry;
		}
    }

	public partial class BulletinServices : BaseServices<Model.Bulletin>,IBulletinServices
    {
		public override void SetDAL()
		{
			idal = DBSession.IBulletinRespositry;
		}
    }

	public partial class CityServices : BaseServices<Model.City>,ICityServices
    {
		public override void SetDAL()
		{
			idal = DBSession.ICityRespositry;
		}
    }

	public partial class CompanyServices : BaseServices<Model.Company>,ICompanyServices
    {
		public override void SetDAL()
		{
			idal = DBSession.ICompanyRespositry;
		}
    }

	public partial class DataDictionaryServices : BaseServices<Model.DataDictionary>,IDataDictionaryServices
    {
		public override void SetDAL()
		{
			idal = DBSession.IDataDictionaryRespositry;
		}
    }

	public partial class DepartmentServices : BaseServices<Model.Department>,IDepartmentServices
    {
		public override void SetDAL()
		{
			idal = DBSession.IDepartmentRespositry;
		}
    }

	public partial class DictionaryGroupServices : BaseServices<Model.DictionaryGroup>,IDictionaryGroupServices
    {
		public override void SetDAL()
		{
			idal = DBSession.IDictionaryGroupRespositry;
		}
    }

	public partial class EmailHistoryServices : BaseServices<Model.EmailHistory>,IEmailHistoryServices
    {
		public override void SetDAL()
		{
			idal = DBSession.IEmailHistoryRespositry;
		}
    }

	public partial class GouConfigServices : BaseServices<Model.GouConfig>,IGouConfigServices
    {
		public override void SetDAL()
		{
			idal = DBSession.IGouConfigRespositry;
		}
    }

	public partial class GroupClientServices : BaseServices<Model.GroupClient>,IGroupClientServices
    {
		public override void SetDAL()
		{
			idal = DBSession.IGroupClientRespositry;
		}
    }

	public partial class Log4Services : BaseServices<Model.Log4>,ILog4Services
    {
		public override void SetDAL()
		{
			idal = DBSession.ILog4Respositry;
		}
    }

	public partial class ProvinceServices : BaseServices<Model.Province>,IProvinceServices
    {
		public override void SetDAL()
		{
			idal = DBSession.IProvinceRespositry;
		}
    }

	public partial class SEMTempServices : BaseServices<Model.SEMTemp>,ISEMTempServices
    {
		public override void SetDAL()
		{
			idal = DBSession.ISEMTempRespositry;
		}
    }

	public partial class SendEmailQueueServices : BaseServices<Model.SendEmailQueue>,ISendEmailQueueServices
    {
		public override void SetDAL()
		{
			idal = DBSession.ISendEmailQueueRespositry;
		}
    }

	public partial class SMSHistoryServices : BaseServices<Model.SMSHistory>,ISMSHistoryServices
    {
		public override void SetDAL()
		{
			idal = DBSession.ISMSHistoryRespositry;
		}
    }

	public partial class WeiXinHisServices : BaseServices<Model.WeiXinHis>,IWeiXinHisServices
    {
		public override void SetDAL()
		{
			idal = DBSession.IWeiXinHisRespositry;
		}
    }

	public partial class WeiXinRecServices : BaseServices<Model.WeiXinRec>,IWeiXinRecServices
    {
		public override void SetDAL()
		{
			idal = DBSession.IWeiXinRecRespositry;
		}
    }

}