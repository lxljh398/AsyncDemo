using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndAwait
{
    class AsyncDemo
    {
        public async void Step1()
        {
            try
            {
                //await进行等待后，新线程的异常可以被主线程捕捉，这是正常的,下面的代码不会被执行
                await Task.Run(() =>
                {
                    Console.WriteLine("Step1 Current ThreadID" + Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(3000);
                });

                await Task.Run(() =>
                {
                    Console.WriteLine("Step1 Current ThreadID" + Thread.CurrentThread.ManagedThreadId);
                    Console.WriteLine("ThreadTest.Test Runing");
                });
            }
            catch (Exception ex)
            {

                Console.WriteLine("ThreadTest" + ex.Message);
            }
        }

        public void Step2()
        {
            Console.WriteLine("Step2 Current ThreadID" + Thread.CurrentThread.ManagedThreadId);
        }
    }
}
