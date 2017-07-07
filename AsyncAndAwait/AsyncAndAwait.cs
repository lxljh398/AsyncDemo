using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndAwait
{
    class AsyncAndAwait
    {
        public static async void AsyncMethod()
        {
            Console.WriteLine("开始异步代码");
            var result = await MyMethodInt();
            //Thread.Sleep(1000);
            Console.WriteLine("异步代码执行完毕");



            //Task t1 = new Task(SetMethod);
            //t1.Start();
        }

        static async void SetMethod()
        {
            for (int i = 0; i < 5; i++)
            {
                await Task.Delay(1000);
                Console.WriteLine($"begin：{i}");
            }

        }

        static async Task<int> MyMethodInt()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("异步执行" + i.ToString() + "..");
                await Task.Delay(1000); //模拟耗时操作
            }
            return 0;
        }
        static async Task<List<Student>> MyMethodClass()
        {
            List<Student> list = new List<Student>();
            for (int i = 0; i < 5; i++)
            {
                Student stu = new Student()
                {
                    Id = i,
                    Name = $"名称{i}"
                };
                list.Add(stu);
            }
            await Task.Delay(1000);
            return list;
        }


        private class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; } = 25;
        }
    }
}
