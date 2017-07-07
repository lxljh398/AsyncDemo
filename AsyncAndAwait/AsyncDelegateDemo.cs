using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndAwait
{

    delegate void AsyncFoo(int i);
    class AsyncDelegateDemo
    {
        /// ﹤summary﹥  
        /// 输出当前线程的信息  
        /// ﹤/summary﹥     
        /// ﹤param name="name"﹥方法名称﹤/param﹥   
        public static void PrintCurrThreadInfo(string name)
        {
            Console.WriteLine("Thread Id of " + name + " is: " + Thread.CurrentThread.ManagedThreadId + ", current thread is "
                + (Thread.CurrentThread.IsThreadPoolThread ? "" : "not ") + "thread pool thread.");
        }


        /// ﹤summary﹥  
        /// 测试方法，Sleep一定时间  
        /// ﹤/summary﹥  
        /// ﹤param name="i"﹥Sleep的时间﹤/param﹥  
        public static void Foo(int i)
        {
            PrintCurrThreadInfo("Foo()");
            Thread.Sleep(i);
        }


        /// ﹤summary﹥  
        /// 投递一个异步调用  
        /// ﹤/summary﹥  
        public static void PostAsync()
        {
            AsyncFoo caller = new AsyncFoo(Foo);
            caller.BeginInvoke(1000, new AsyncCallback(FooCallBack), caller);

        }


        public static void FooCallBack(IAsyncResult ar)
        {
            PrintCurrThreadInfo("FooCallBack()");
            AsyncFoo caller = (AsyncFoo)ar.AsyncState;
            caller.EndInvoke(ar);
        }
    }
}
