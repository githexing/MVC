using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCommon
{
    class MyDbContext
    {
        static string sconn = ConfigurationManager.AppSettings["DefaultConnection"];

        protected SqlConnection conn; //创建连接对象  
       
        public MyDbContext() /*: base("name=connStr") *///“connStr”数据库连接字符串
        {
            //Database.SetInitializer<MyDbContext>(null);
            //this.Database.Log = sql => log.DebugFormat("EF执行SQL：{0}", sql);//用log4NET记录数据操作日志

        
        }
    }
}
