using System;
using System.Diagnostics;
using System.Threading;
using System.Management;

namespace ConsoleApp1
{

    class Program
    {
    
        static void Main(string[] args)
        {
            //PerformanceCounter PC;

            while (true)
            {



            //    Process[] allProcesses = Process.GetProcesses();
            //    PC = new PerformanceCounter("Process", "Working Set - Private", "DWConfig");
                 
            //    long memory1 = 0;

            //    foreach (Process p in allProcesses) memory1 += p.VirtualMemorySize64;

            //Console.WriteLine($"RAM : {memory1} ");

            ///* 현재 프로세스 메모리 사용량 가져오기*/
            // double memsize = Convert.ToDouble(PC.NextValue()) / (double)1024;
            // double memsize_MB =Math.Round(Convert.ToDouble(PC.NextValue()) / ((double)1024 * (double)1024), 1);
            // double memsize_GB = memsize_MB / (double)1024;

        
            // Console.WriteLine("DWConfig : {0:#,###} KB", memsize );
            // Console.WriteLine("DWConfig : {0:#,###} MB", memsize_MB);
            // Console.WriteLine("DWConfig : {0:0.000} GB", memsize_GB);

             GetTotalUsedMemory();


                   int milliseconds = 10000;
                Thread.Sleep(milliseconds);

            }
        }

        public static void GetTotalUsedMemory(/*double memsize_MB*/)
        {
            ManagementClass cls = new ManagementClass("Win32_OperatingSystem");
            ManagementObjectCollection instances = cls.GetInstances();

            foreach (ManagementObject info in instances)
            {
                double total_physical_memeory = double.Parse(info["TotalVisibleMemorySize"].ToString());
                double free_physical_memeory = double.Parse(info["FreePhysicalMemory"].ToString());
                double remain_physical_memory = total_physical_memeory - free_physical_memeory;

                Console.WriteLine("Memory Information ================================");
                Console.WriteLine("Total Physical Memory :{0:#.###} GB", total_physical_memeory/ (1024 * 1024));
                Console.WriteLine("Total Physical Memory :{0:#,###} MB", total_physical_memeory/1024);
                Console.WriteLine("Total Physical Memory :{0:#,###} KB", total_physical_memeory);

                Console.WriteLine("Free Physical Memory :{0:#,###} GB", free_physical_memeory/(1024 * 1024));
                Console.WriteLine("Free Physical Memory :{0:#,###} MB", free_physical_memeory/1024);
                Console.WriteLine("Free Physical Memory :{0:#,###} KB", free_physical_memeory);

                Console.WriteLine("Remain Physical Memory : {0:0.00} GB", remain_physical_memory / (1024 * 1024));
                Console.WriteLine("Remain Physical Memory : {0:#,###} MB", remain_physical_memory / 1024);
                Console.WriteLine("Remain Physical Memory : {0:#,###} KB", remain_physical_memory);

                Console.WriteLine("Memory Usage Percent = {0} %", 100 *(int) remain_physical_memory / (int)total_physical_memeory);

                //Console.WriteLine("DWConfig Usage Percent = {0:0.00} %", 100 * (memsize_MB / remain_physical_memory_MB) );
                
               
                Console.WriteLine();
            }

        }


    }

}
