namespace Service
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class uEntity : DbContext
    {
        public uEntity()
            : base("name=uEntity")
        {
        }

        public virtual DbSet<tb_user> tb_user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public void gs()
        {
            MyList<Person> p = new MyList<Person>();
           
        }
    }
    public class MyList<T> where T : new()
    {
//...代码省略部分
    }
    public class Person
    {
        public string Name { get; set; }
       
    }
   
}
