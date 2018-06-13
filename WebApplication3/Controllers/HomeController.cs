using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication3.Models;
using WebCommon;
using System.Net;
using System.Text;
using System.Data.Entity;
using System.Data.SqlClient;
using Inter.Service;
using System.Threading.Tasks;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public Itb_user tb_user { get; set; }

        public async Task<ActionResult> Index()
        {
            //var dst = tb_user.g();

            DataContext dc = new DataContext();
            var U = dc.Users.ToArray();

            var Uo = await dc.Users.ToListAsync();
            //var aa = Uo.SingleOrDefault();
            var str = from u in U
                      select new { u.ID, u.Name };

            var strs = from u in dc.Users
                       select new { u.ID, u.Name };
            var strss = from u in dc.Users
                        select u;
            UserEntity pp = new UserEntity();
            var a = str.OrderByDescending(i => i.ID).Select(i => new User_1 { ID = i.ID, Name = i.Name }).ToArray();

            var aw = str.OrderByDescending(i => i.ID).Select(i => new UserEntity { ID = i.ID, Name = i.Name }).ToArray();
            aw.Count();
            dc.Users.Add(aw[0]);

            //var b = str.SingleOrDefault().ID;

            List<UserEntity> l = new List<UserEntity>();

            UsersDTOList list = new UsersDTOList();
            //list.UsersList = U.OrderByDescending(i => i.ID).Select(i => new UsersDTO { ID = i.ID, Name = i.Name }).ToArray();
            //list.UsersList = str.Select(i => new UsersDTO { ID = i.ID, Name = i.Name }).ToArray();
            List<UsersDTO> users = new List<Models.UsersDTO>();
            //foreach(var s in str)
            //{
            //    UsersDTO user = new UsersDTO();
            //    user.ID = s.ID;
            //    user.Name = s.Name;
            //    users.Add(user);
            //} 
            list.UsersList = users.Select(i => new UsersDTO { ID = i.ID, Name = i.Name }).ToArray();
            SqlParameter[] Params = new SqlParameter[] {

            };






            //list.UsersList = users.ToArray();
            return View(list);
        }
      
        public ActionResult gg1()
        {
            //var mac = GetMacAddress();
            return Json(new AjaxResult { Msg = "成功" });
        }
        [HttpPost]
        public ActionResult gg(int page)
        {
            DataContext dc = new DataContext();
            UsersDTOList list = new UsersDTOList();
            int Number = 2;
            list.UsersList = dc.Users.OrderByDescending(p => p.ID).ToList().Skip((page - 1) * Number).Take(Number).ToList().Select(p => new UsersDTO { ID = p.ID, Name = p.Name }).ToArray();
            list.PageSize = (int)Math.Ceiling((dc.Users.Count())/2.0);

            return Json(new AjaxResult { Data= list });
        }


        public PartialViewResult Member_Page(int pageNumber = 1, int PageSize = 1)
        {
            DataContext dc = new DataContext();
            UsersDTOList model = new UsersDTOList();
            //MemberSearch.MemberList = User.OrderByDescending(p => p.ID).ToList().Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList().Select(p => ToDTO(p)).ToArray();
            model.UsersList = dc.Users.OrderByDescending(p => p.ID).ToList().Skip((pageNumber - 1) * 1).Take(PageSize).ToList().Select(p => new UsersDTO { ID = p.ID, Name = p.Name }).ToArray();
            string Table = "_PartialPageWidget";
            Pagination pager = new Pagination(pageNumber, 1, dc.Users.Count());
            //pager.PageIndex = pageNumber;
            //pager.PageSize = 1;
            //pager.TotalCount = dc.Users.Count();

            if (pager.TotalCount <= PageSize)
            {
                model.Page = "";
            }
            else
            {
                model.Page = pager.GetPagerHtml();
            }
            return PartialView(Table, model);
        }


        public UsersDTOList L(UsersDTOList a, int pageSize = 1, int pageNumber = 1)
        {
            UsersDTOList s = new UsersDTOList();
            s.UsersList = a.UsersList.Skip(pageSize * pageNumber).Take(pageNumber).ToArray();
            return s;
        }


        public ActionResult About(string name)
        {
            DataContext dc = new DataContext();
            UserEntity u = new UserEntity();
            u.Name = name;
            dc.Users.Add(u);
            dc.SaveChanges();
            return Json(u.ID);
        }

        public class User_1
        {
            public long ID { get; set; }
            public string Name { get; set; }

        }
        public class User_2
        {
            public long ID { get; set; }
            public string Name { get; set; }
        }

        public User_2 DTO(UserEntity u)
        {
            User_2 U = new User_2();
            U.ID = u.ID;
            U.Name = u.Name;
            return U;
        }
        public UsersDTO UsersDTO(UserEntity u)
        {
            UsersDTO U = new UsersDTO();
            U.ID = u.ID;
            U.Name = u.Name;
            return U;
        }
      //public  string GetMacAddress()
      //  {
      //      try
      //      {
      //          string mac = "";
      //          ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
      //          ManagementObjectCollection moc = mc.GetInstances();
      //          foreach (ManagementObject mo in moc)
      //          {
      //              if ((bool)mo["IPEnabled"] == true)
      //              {
      //                  mac = mo["MacAddress"].ToString();
      //                  break;
      //              }
      //          }
      //          moc = null;
      //          mc = null;
      //          return mac;
      //      }
      //      catch
      //      {
      //          return "unknow";
      //      }
      //  }
        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {
            DataContext dc = new DataContext();
            UsersDTOList list = new UsersDTOList();
            UserEntity U = new UserEntity();
            string name = fc["text"];
            RoleEntity R = new RoleEntity();
            var ee = dc.Roles.Where(p => p.ID == 4).ToList();

            var sd = LanChange(name);
            sd = ChangeLan(sd);

            string s = "这里是测试字符串";
            string utf8_string = Encoding.UTF8.GetString(Encoding.Default.GetBytes(s));

            //var ds= U.Roles.Select(p => new RoleEntity { ID = 234});
            //R.Users.Add(U);
            //dc.Roles.Add(R); 
            U.Name = name;
            U.Roles = ee;
            dc.Users.Add(U);
            dc.SaveChanges();

            //list.UsersList = dc.Users.Select(p=>new UsersDTO { ID=p.ID, Name = p.Name }).ToArray();
            return RedirectToAction("Index");
            //return View(list);
        }
        public string LanChange(string str)
        {
            Encoding utf8;
            Encoding gb2312;
            utf8 = Encoding.GetEncoding("UTF-8");
            gb2312 = Encoding.GetEncoding("GB2312");
            byte[] gb = gb2312.GetBytes(str);
            gb = Encoding.Convert(gb2312, utf8, gb);
            return utf8.GetString(gb);
        }
        public string ChangeLan(string text)
        {
            byte[] bs = Encoding.GetEncoding("UTF-8").GetBytes(text);
            bs = Encoding.Convert(Encoding.GetEncoding("UTF-8"), Encoding.GetEncoding("GB2312"), bs);
            return Encoding.GetEncoding("GB2312").GetString(bs);
        }

        public ActionResult Index1(int[] ids)
        {
            //int ID = id;
            //DataContext dc = new DataContext();
            //UsersDTOList list = new UsersDTOList();
            //UsersDTO DTO = new Models.UsersDTO();
            UserEntity E = new UserEntity();
            //var d = dc.Users.Where(p => p.ID == id).Select(p=>new UsersDTO {ID=p.ID,Name=p.Name }).ToArray();
            //var c = list.UsersList.Select(p => new UserEntity {  ID=p.ID, Name = p.Name }).ToArray()[0];

            //var model= dc.Users.FirstOrDefault(p => p.ID == id); 
            //dc.Users.Remove(model);
            DataContext dc = new DataContext();
            foreach (var id in ids)
            {
                var user = dc.Users.FirstOrDefault(u => u.ID == id);
                dc.Users.Remove(user);
            }
            dc.SaveChanges();

            //return RedirectToAction("Index");
            return Json(new AjaxResult { Msg = "删除成功！", Status = "/home/Index" });
            //return Json(new AjaxResult { Msg = ID.ToString() });
        }

        public ActionResult AddRoles()
        {
            ViewBag.name = 11;
            long[] ids = { 2, 3, 4 };
            DataContext dc = new DataContext();
            var user = dc.Users.FirstOrDefault(u => u.ID == 1);
            //foreach(var id in ids)
            //{
            //    var role = dc.Roles.SingleOrDefault(r => r.ID == id);
            //    user.Roles.Add(role);
            //}
            var roles = user.Roles;
            ViewData["dd"] = "dw";
            //dc.SaveChanges();
            return Json(new AjaxResult { Msg = "删除成功！", Status = "/home/Index" });
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public void gs()
        {
            MyList<Person> p = new MyList<Person>();

        }

        public ActionResult Time()
        {
            //var mac = GetMacAddress();
            return View();
        }
        //public async Task<ActionResult> per1()
        //{
        //    Uri uri = new Uri("http://1212.ip138.com/ic.asp");
        //    string url = "http://1212.ip138.com/ic.asp";//设置你要访问的网址。

        //    WebClient wc = new WebClient();//创建WebClient对象
        //   var a = await wc.DownloadStringTaskAsync(url);
        //    wc.DownloadStringAsync(uri);
        //    //wc.DownloadStringTaskAsync(url);//访问网址并用一个流对象来接受返回的流
        //    return View();
        //    //HttpClient 
        //}
    }
    




}