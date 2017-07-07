using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndAwait
{
    class Choke
    {
        public Choke()
        {
            DisplayValue0();
            Console.WriteLine("同步方法 End.");
            DisplayValue(); //这里不会阻塞  
            Console.WriteLine("MyClass() End.");
        }
        public Task<double> GetValueAsync(double num1, double num2)
        {
            return Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    num1 = num1 / num2;
                }
                return num1;
            });
        }
        /// <summary>
        /// 同步方法
        /// </summary>
        public void DisplayValue0()
        {
            double result = 0;
            for (int i = 0; i < 1000000; i++)
            {
                result = 1234.5 / 1.01;
            }
            Console.WriteLine("Value is : " + result);
        }

        /// <summary>
        /// 异步等待
        /// </summary>
        public async void DisplayValue()
        {
            double result = await GetValueAsync(1234.5, 1.01);//此处会开新线程处理GetValueAsync任务，然后方法马上返回  
                                                              //这之后的所有代码都会被封装成委托，在GetValueAsync任务完成时调用  
            Console.WriteLine("睡眠开始...");
            Thread.Sleep(1000);
            Console.WriteLine("Value is : " + result);
        }

        public void DisplayValue1()
        {
            System.Runtime.CompilerServices.TaskAwaiter<double> awaiter = GetValueAsync(1234.5, 1.01).GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                double result = awaiter.GetResult();
                Console.WriteLine("Value is : " + result);
            });
        }
    }
}
