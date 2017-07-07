using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndAwait
{
    class TaskParallel
    {
        public void Mathod()
        {
            Console.WriteLine("顺序开始：" + DateTime.Now);
            Thread.Sleep(1000);
            Thread.Sleep(2000);
            Console.WriteLine("顺序结束：" + DateTime.Now);
        }
        public void TaskMathod()
        {
            #region 并行Task
            Console.WriteLine("Task并行完成" + DateTime.Now);
            var task = Task.WhenAll(Task.Run(() => { Thread.Sleep(1000); }), Task.Run(() => { Thread.Sleep(2000); }));//多个task并行执行，不阻塞
            task.ContinueWith((ctw) =>//当task完成后，执行这个回调
            {
                Console.WriteLine("Task并行完成" + DateTime.Now);
            });
            Console.WriteLine("Task并行结束" + DateTime.Now);
            #endregion
        }

        public void ParallelMathod()
        {
            #region 并行Parallel
            Console.WriteLine("Parallel并行完成" + DateTime.Now);
            Parallel.Invoke(() =>
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(1000);
            }, () =>
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(2000);
            });
            Console.WriteLine("Parallel并行结束" + DateTime.Now);
            #endregion
        }
    }
}
