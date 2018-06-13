using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
  public  class Class1
    {
        public enum Language { English, Chinese }

        public void GreetPeople(string name)
        {
            // 做某些额外的事情，比如初始化之类，此处略 
            EnglishGreeting(name);
        }
        public void EnglishGreeting(string name)
        {
            Console.WriteLine("Morning, " + name);
        }
        public void ChineseGreeting(string name)
        {
            Console.WriteLine("早上好, " + name);
          
        }

        public enum Language1 { English, Chinese }
        public void GreetPeople(string name, Language1 lang)
        {
            //做某些额外的事情，比如初始化之类，此处略 
            switch (lang){ 
                case Language1.English:
                             EnglishGreeting(name);
                      break;
                case Language1.Chinese: 
                              ChineseGreeting(name);
                      break;
            }
        }
        public delegate void GreetingDelegate(string name);
        //class Program
        //{
        //    private static void EnglishGreeting(string name) { Console.WriteLine("Morning, " + name); }
        //    private static void ChineseGreeting(string name) { Console.WriteLine("早上好, " + name); }
        //    //注意此方法，它接受一个GreetingDelegate类型的方法作为参数
        //    private static void GreetPeople(string name, GreetingDelegate MakeGreeting)
        //    {
        //        MakeGreeting(name);
        //    } static void Main(string[] args)
        //    {
        //        GreetPeople("Jimmy Zhang", EnglishGreeting);
        //        GreetPeople("张子阳", ChineseGreeting);
        //        Console.ReadKey(); }
           
        //}
        class Program
        {
            private static void EnglishGreeting(string name) { Console.WriteLine("Morning, " + name); }
            private static void ChineseGreeting(string name) { Console.WriteLine("早上好, " + name); }
            private static void GreetPeople(string name, GreetingDelegate MakeGreeting)
            {
                MakeGreeting(name);
            }
            static void Main(string[] args)
         {
            
               
             GreetingDelegate delegate1, delegate2;

                delegate1 = EnglishGreeting;
                delegate2 = ChineseGreeting;
                GreetPeople("Jimmy Zhang", delegate1);
                GreetPeople("张子阳", delegate2);
                Console.ReadKey(); }
        }
        public delegate void sd(string name);
        private static void GreetPeople1(string name ,sd dd)
        {
            dd(name);
        }
        }

}
