using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            //Async();
            //Console.WriteLine("aaa");

            //#region 多线程处理异步
            //Console.WriteLine("主线程测试开始..");
            //Thread th = new Thread(ThreadAsync.ThMethod);
            //th.Start();
            //Thread.Sleep(1000);
            //Console.WriteLine("主线程测试结束..");
            //Console.ReadLine();
            //#endregion


            //#region Async和Await
            //Console.WriteLine("主线程测试开始..");
            //AsyncAndAwait.AsyncMethod();
            //Thread.Sleep(1000);
            //Console.WriteLine("主线程测试结束..");
            //Console.ReadLine();
            //#endregion



            //Choke c = new Choke();




            //#region 异步和多线程的区别
            //AsyncDelegateDemo.PrintCurrThreadInfo("Main()");
            //AsyncDelegateDemo.PostAsync();
            ////for (int i = 0; i < 5; i++)
            ////{
            ////    AsyncDelegateDemo.PostAsync();
            ////}
            //Console.ReadLine();
            //#endregion


            //#region C#~异步编程再续~async异步方法与同步方法的并行
            //var test = new AsyncDemo();
            //test.Step1();//整个方法不阻塞，但方法内部有可能阻塞
            //test.Step2();
            //#endregion

            #region C#~异步编程再续~大叔所理解的并行编程(Task&Parallel)
            var test = new TaskParallel();
            test.Mathod();
            Console.WriteLine("-------------------------顺序完成");
            test.ParallelMathod();
            Console.WriteLine("-------------------------Parallel并行完成");
            test.TaskMathod();
            Console.WriteLine("-------------------------Task并行完成");            
            #endregion

            Console.ReadKey();
        }
        


        static async void Async()
        {
            await Task.Run(() => { Thread.Sleep(5000); Console.WriteLine("bbb"); });
            Console.WriteLine("ccc");
        }
    }
}
