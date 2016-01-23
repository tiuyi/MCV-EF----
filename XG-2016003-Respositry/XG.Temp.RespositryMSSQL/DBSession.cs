using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XG.Temp.RespositryMSSQL
{
    public partial class DBSession : IRespositry.IDBSession
    {
        public int SaveChange()
        {
            var db = new DBContextFactory().GetDbContext();
            return db.SaveChanges();
        }
    }
}
