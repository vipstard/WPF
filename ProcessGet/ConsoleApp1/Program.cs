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
            PerformanceCounter ramCounter;
            ManagementClass cls = new ManagementClass("Win32_OperatingSystem");
            ManagementObjectCollection instances = cls.GetInstances();


            while (true)
            {


                Process[] allProcesses = Process.GetProcesses();
                Process pro = Process.GetCurrentProcess(); // 현재 프로세스 사용량
            ramCounter = new PerformanceCounter("Process", "Working Set", pro.ProcessName);
            

                long memory1 = 0;
            int memory3 =(int) ramCounter.NextValue();

            foreach (Process p in allProcesses) memory1 += p.VirtualMemorySize64;

            Console.WriteLine($"RAM : {memory1} ");
            Console.WriteLine($"{pro.ProcessName} : {memory3}");

             /* 현재 프로세스 메모리 사용량 가져오기*/
             PerformanceCounter PC = new PerformanceCounter();
             PC.CategoryName = "Process";
             PC.CounterName = "Working Set - Private";
             PC.InstanceName = "DWConfig";
             double memsize = Convert.ToDouble(PC.NextValue()) / (double)1024;
             double memsize2 =Math.Round(Convert.ToDouble(PC.NextValue()) / ((double)1024 * (double)1024), 1);
             double memsize2_GB = memsize2 / (double)1024;

        
             Console.WriteLine("DWConfig : {0:#,###} KB", memsize );
             Console.WriteLine("DWConfig : {0:#,###} MB", memsize2);
             Console.WriteLine("DWConfig : {0} GB", memsize2_GB);

             GetTotalUsedMemory(memsize2);


                int milliseconds = 10000;
             Thread.Sleep(milliseconds);

            }
        }

        public static void GetTotalUsedMemory(double memsize2)
        {
            ManagementClass cls = new ManagementClass("Win32_OperatingSystem");
            ManagementObjectCollection instances = cls.GetInstances();

            foreach (ManagementObject info in instances)
            {
                double total_physical_memeory = double.Parse(info["TotalVisibleMemorySize"].ToString());
                double total_physical_memeory_GB = total_physical_memeory / ((double)1024 * (double)1024);
                double free_physical_memeory = double.Parse(info["FreePhysicalMemory"].ToString());
                double remain_physical_memory = total_physical_memeory - free_physical_memeory;

                Console.WriteLine("Memory Information ================================");

                Console.WriteLine("Total Physical Memory :{0:#.###} GB", total_physical_memeory_GB);
                Console.WriteLine("Total Physical Memory :{0:#,###} MB", total_physical_memeory/1024);
                Console.WriteLine("Total Physical Memory :{0:#,###} KB", info["TotalVisibleMemorySize"]);

                Console.WriteLine("Free Physical Memory :{0:#,###} MB", free_physical_memeory/1024);
                Console.WriteLine("Free Physical Memory :{0:#,###} KB", info["FreePhysicalMemory"]);

                Console.WriteLine("Memory Usage Percent = {0} %", 100 *(int) remain_physical_memory / (int)total_physical_memeory);
                Console.WriteLine("Memory Usage Percent = {0} %", 100 * memsize2 / (total_physical_memeory / 1024));
                
                Console.WriteLine("Remain Physical Memory : {0:#,###} GB", remain_physical_memory / (1024* 1024));
                Console.WriteLine("Remain Physical Memory : {0:#,###} MB", remain_physical_memory / 1024);
                Console.WriteLine("Remain Physical Memory : {0:#,###} KB", remain_physical_memory);
                Console.WriteLine();
            }

        }

        public static long GetProcessMemorySize(string processName)
        {
            PerformanceCounter performanceCounter = new PerformanceCounter("Process", "Working Set - Private", processName);

            long memorySize = performanceCounter.RawValue;

            return memorySize;
        }

    }

}
