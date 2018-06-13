using Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using WebCommon;

namespace WebApplication3.Controllers
{
    public class HXController : Controller
    {
        static string sconn = System.Configuration.ConfigurationManager.AppSettings["DefaultConnection"];

        CommonToken J = new CommonToken();
        // GET: HX     丨 |丨
        public ActionResult HX()
        { 
            var a= J.jiami();
            J.jiemi(a);

            return View();
        }
        public ActionResult Index1()
        {
          
            List<Users> items = new List<Users>();
            Users u1 = new Users();
            u1.UserID = 1;
            u1.UserCode = "123";
            Users u2 = new Users();
            u2.UserID = 2;
            u2.UserCode = "12344";
            items.Add(u1);
            items.Add(u2);
            items.OrderByDescending(i => i.UserID).Select(i => new UserDTO { Id = i.UserID, Name = i.UserCode }).ToArray();
            

            return Json(new AjaxResult { Status = "1",Data= GetJSONString(Data()) });  
        }
        public class UserDTO
        {
            public long Id { get; set; }
            public string Name { get; set; }
        }
        public class Users
        {
            public long UserID { get; set; }
            public string UserCode { get; set; }
        }
        public DataTable Data()
        { 
            SqlConnection conn = new SqlConnection(sconn);
            conn.Open();
            string sql = "select top(10) UserID,UserCode  from tb_user ";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            //List<Users> items = new List<Users>(); 
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    Users u1 = new Users();
            //    u1.UserID = int.Parse(dt.Rows[i]["UserID"].ToString());
            //    u1.UserCode = dt.Rows[i]["UserCode"].ToString();
            //    items.Add(u1);
                
            //}
            
            return dt;
        }


        public static string GetJSONString(DataTable dt)
        {
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            foreach (DataRow dr in dt.Rows)
            {
                Dictionary<string, object> row = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    row.Add(dc.ColumnName, dr[dc]);
                }
                rows.Add(row);
            } 
            System.Web.Script.Serialization.JavaScriptSerializer ser = new System.Web.Script.Serialization.JavaScriptSerializer();
            return ser.Serialize(rows);
        }
        public ActionResult FWB()
        { 
            return View();
        }

        public ActionResult upload(HttpPostedFileBase file)
        {
            //var path= file.
            if (Directory.Exists(Server.MapPath("~/Upload/images")) == false)//如果不存在就创建file文件夹
            {
                Directory.CreateDirectory(Server.MapPath("~/Upload/images"));
            }
            string paths = Server.MapPath("~/Upload/images");
            string postaddpath = DateTime.Now.ToString("yyyyMMddhhmmss");
            string path = paths +"/"+ postaddpath + ".jpg";
            file.SaveAs(path);

            return Json(new { errno = "0", Data = path });
        }
    }
}