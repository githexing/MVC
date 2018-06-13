using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class UsersDTO
    {
        public long ID { get; set; }
        public string Name { get; set; } 
    }
    public class UsersDTOList
    {
       public UsersDTO[] UsersList { get; set; }
       public long TotalCount { get; set; }
       public string  Page { get; set; }
        public int PageSize { get; set; }
    }

}