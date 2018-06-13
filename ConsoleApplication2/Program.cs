using ConsoleApplication2.ReflectionTest;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            string fullTypeName = typeof(Strawberry).AssemblyQualifiedName;
            AbsFruit absFruit2 = FruitFactory.CreateInstance<AbsFruit>(fullTypeName);
            absFruit2.Show();
            //C: \Users\Administrator\Documents\Visual Studio 2015\Projects\WebApplication3\ConsoleApplication2\DAL.dll

            System.Reflection.Assembly ass = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + "DAL.dll"); //加载DLL


            System.Type t = ass.GetType("lgk.DAL.tb_user");//获得类型
            Console.WriteLine("类型名：{0}", t.Name);
            Console.WriteLine("类全名：{0}", t.FullName);
            Console.WriteLine("命名空间：{0}", t.Namespace);
            Console.WriteLine("程序集名：{0}", t.Assembly);
            Console.WriteLine("模块名：{0}", t.Module);
            Console.WriteLine("基类名：{0}", t.BaseType);
            Console.WriteLine("是否类：{0}", t.IsClass);
            Console.WriteLine("类的公共成员：");
            Console.ReadKey();
            //MemberInfo[] members = t.GetMembers();
            //foreach (MemberInfo memberInfo in members)
            //{
            //    Console.WriteLine("{0}:{1}", memberInfo.MemberType, memberInfo);
            //}


            //string name = typeof(tt).AssemblyQualifiedName;
            //System.Type t1 = Type.GetType(name);
            ////System.Type t2 = typeof(MyClass);

            //object o = System.Activator.CreateInstance(t1);//创建实例
            //System.Reflection.MethodInfo mi = t1.GetMethod("gg1");//获得方法
            //mi.Invoke(o,new string[] {"test" });//调用方法

            
            // //System.Reflection.MethodInfo mi1 = t.GetMethod("Fun_2");
            // //mi1.Invoke(t, new object[] { , "alert('测试反射机制1')" });//调用方法







            // Type type = typeof(xx);
         
            //var a = type.GetMethods();
            //var b = type.GetProperties();
            //var c = type.GetCustomAttributes(true);
        }
    }

    [Serializable]
    public abstract class xx
    {
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        public abstract void gg();
        public abstract void gg1(string test);
    }
    public class tt :xx
    {
        public override void gg()
        {
            Console.WriteLine("11");
            Console.ReadKey();
        }
        public override void gg1(string test)
        {
            Console.WriteLine(test);
            Console.ReadKey();
        }

    }

    //namespace ReflectionTest
    //{
    //    class Program
    //    {
    //        static void Main(string[] args)
    //        {
    //            //方法一
    //            AbsFruit absFruit = FruitFactory.CreateInstance<AbsFruit>("ReflectionTest", "Strawberry");
    //            absFruit.Show();
    //            //方法二
    //            //string fullTypeName = typeof (Strawberry).FullName;
    //            string fullTypeName = typeof(Strawberry).AssemblyQualifiedName;
    //            AbsFruit absFruit2 = FruitFactory.CreateInstance<AbsFruit>(fullTypeName);
    //            absFruit2.Show();
    //        }
    //    }
    //}
    namespace ReflectionTest
    {
        public class FruitFactory
        {
            public static T CreateInstance<T>(string nameSpace, string className)
            {
                string fullClassName = nameSpace + "." + className;
                return (T)Assembly.Load(nameSpace).CreateInstance(fullClassName);
            }

            public static T CreateInstance<T>(string fullTypeName)
            {
                return (T)Activator.CreateInstance(Type.GetType(fullTypeName));
            }
        }
    }
    public abstract class AbsFruit
    {
        protected string Name { get; set; }
        public abstract void Show();
    }
    class Strawberry : AbsFruit
    {
        public Strawberry()
        {
            Name = "草莓";
        }
        public override void Show()
        {
            Console.WriteLine("水果类型：" + Name);
        }
    }

}
