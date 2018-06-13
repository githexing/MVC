using ConsoleApplication1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static WebApplication3.Controllers.HXController;

namespace ConsoleApplication1
{
    class Program
    {
        //创建计时器
        private static readonly Stopwatch Watch = new Stopwatch();
        public delegate int Expression(int a, int b);
        static void Main(string[] args)
        { 

            Calculate(GetAdd, 25, 10);
        }
        static int Add(int a, int b)
        {
            return a + b;
        }
        static int Divide(int a, int b)
        {
            return a / b;
        }
        static int subtract(int a, int b)
        {
            return a - b;
        }
        static int multiply(int a, int b)
        {
            return a * b;
        }
        static int GetAdd(int a, int b)
        {
           
            return a + b;
        }
        static void Calculate(Expression ex, int a, int b)
        {
            Console.WriteLine(ex(a, b) + "\n");
        }




        private static void Main2(string[] args)
        {
            //启动计时器
            Watch.Start();

            const string url1 = "http://www.cnblogs.com/";
            const string url2 = "http://www.cnblogs.com/liqingwen/";

            //两次调用 CountCharactersAsync 方法（异步下载某网站内容，并统计字符的个数）
            Task<int> t1 = CountCharactersAsync(1, url1);
            Task<int> t2 = CountCharactersAsync(2, url2);

            //三次调用 ExtraOperation 方法（主要是通过拼接字符串达到耗时操作）
            for (var i = 0; i < 3; i++)
            {
                ExtraOperation(i + 1);
            }
             var a =  Thread.CurrentThread; 
            
              
            //控制台输出
            Console.WriteLine($"{url1} 的字符个数：{t1.Result}");
            Console.WriteLine($"{url2} 的字符个数：{t2.Result}");

            Console.Read();
        }

        /// <summary>
        /// 统计字符个数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        private static async Task<int> CountCharactersAsync(int id, string address)
        {
            var wc = new WebClient();
            Console.WriteLine($"开始调用 id = {id}：{Watch.ElapsedMilliseconds} ms");

            var result = await wc.DownloadStringTaskAsync(address);
            Console.WriteLine($"调用完成 id = {id}：{Watch.ElapsedMilliseconds} ms");


            return result.Length;
             
        }


        /// <summary>
        /// 额外操作
        /// </summary>
        /// <param name="id"></param>
        private static void ExtraOperation(int id)
        {
            //这里是通过拼接字符串进行一些相对耗时的操作
            var s = "";

            for (var i = 0; i < 6000; i++)
            {
                s += i;
            }

            Console.WriteLine($"id = {id} 的 ExtraOperation 方法完成：{Watch.ElapsedMilliseconds} ms");
        }
    }

}