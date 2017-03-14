using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace ProcesKiller
{
    class Program
    {
        static void Main(string[] args)
        {

            string killproc = Console.ReadLine();
            var proc = Process.GetProcesses();
            
            Console.WriteLine(proc.Length);
            object o = proc;
            Timer timer = new Timer(DoCountProcesses, o, 500, 500);
            //ThreadPool.QueueUserWorkItem(o=>DoCountProcesses());
            //var task =  queue
            
            for (int i = 0; i < proc.Length; i++) {
            
            //Проверяем имя процесса
                if (proc[i].ProcessName == killproc)
                    proc[i].Kill();
            }

            var collect = from c in proc
                          orderby c.ProcessName ascending
                          select c;
            foreach (var clo in collect)
            {
                Console.WriteLine("Name:" + clo.ProcessName + Environment.NewLine);
            }
            
            Console.ReadLine();


            
            //Console.WriteLine(proc.Container.ToString());
            
        }

        private static void DoCountProcesses(object proc)
        {
            var t = proc as Process[];
            Console.WriteLine(t.Length);
            
        }
    }
}
