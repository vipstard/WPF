using System;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using System.Windows;

namespace Pracitce
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int processCount = 0;
        private Thread ProcessThread; //프로세스 보여주기 위한 쓰레드
        Thread checkThread = null;    //실시간 시스템 정보 체크하기 위한 쓰레드

        private delegate void UpdateProcessDelegate(); //프로세스 현재 상태를 업데이트 하기 위한 델리게이트 생성
        private UpdateProcessDelegate updateProcess = null;

        private delegate void UpdateTotalDelegate(int m, int n); //status Bar에 성능 표시
        private UpdateTotalDelegate updateTotal = null;

        private PerformanceCounter oCpu = new PerformanceCounter("Processor", "% Processor Time", "_Total"); //시스템 CPU성능 카운터
        /*PerformanceCounter 사용법 
         * 첫번째 인자 Performance Object (IP,Processor,WMI,Memory
         * 두번째 인자 해당 Object의 카운터(Processor 인 경우 % Processor Time,% User Time, Thread Count)
         * (Memory 인 경우 Available MByte,Available KByte
         * 세번째 인자 프로세스의 이름
         * cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total"); //new PerformanceCounter("Processor", "% Processor Time", appName);
         * ramCounter = new PerformanceCounter("Memory", "Available MBytes");
         */
        private PerformanceCounter oMem =
            new PerformanceCounter("Memory", "% Committed Bytes In Use"); //시스템 Mem 성능 카운터
        private PerformanceCounter pCPU =
            new PerformanceCounter();

        bool bExit = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ProcessView()
        {
            try
            {
                this.ProcessUsageList.Items.Clear();
                processCount = 0;
                foreach (var proc in Process.GetProcesses()) //모든 프로세스의 목록을 가져 오자
                {
                    string[] str;
                    try
                    {
                        str = proc.UserProcessorTime.ToString().Split(new Char[] { '.' });
                        //str = proc.TotalProcessorTime.ToString().Split(new Char[] { '.' }); //프로세스의 총시간
                    }
                    catch { str = new string[] { "" }; }

                    var strArray = new string[] { proc.ProcessName.ToString(), proc.Id.ToString(), //프로세스이름, 아이디
                        str[0], NumFormat(proc.WorkingSet64) }; //프로세스  수행시간,메모리 점유율

                    this.ProcessUsageList.Items.Add(strArray);
                    processCount++;
                }
            }
            catch { }
            this.tssProcess.Text = "프로세스 : " + processCount.ToString() + "개";
        }

        private string NumFormat(long MemNum)
        {
            MemNum = MemNum / 1024;
            return String.Format("{0:N}", MemNum) + " KB"; //N은 숫자 서식 지정자 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ProcessView(); //프로세스 출력
            updateProcess = new UpdateProcessDelegate(ProcessView); //ProcessView 델리게이트
            updateTotal = new UpdateTotalDelegate(TotalView);
            ProcessThread = new Thread(ProcessUpdate); //스레드 대리자에 구동 메서드 입력
            ProcessThread.Start(); //스레드 시작
            checkThread = new Thread(getCPU_Info);
            checkThread.Start();
        }

        private void getCPU_Info()
        {
            try
            {
                while (!bExit)
                {
                    int iCPU = (int)oCpu.NextValue();
                    int iMem = (int)oMem.NextValue();
                    Invoke(updateTotal, iCPU, iMem);
                    Thread.Sleep(1000);
                }
            }
            catch { }
        }

        private void ProcessUpdate()
        {
            try
            {
                while (true)
                {
                    //Invoke(updateProcess);
                    // Thread.Sleep(1000);
                    // continue;
                    var oldlist = new ArrayList();
                    foreach (var oldproc in Process.GetProcesses())
                    {
                        oldlist.Add(oldproc.Id.ToString());
                    }
                    Thread.Sleep(1000);
                    var newproc = Process.GetProcesses();
                    if (oldlist.Count != newproc.Length)
                    {
                        Invoke(updateProcess);
                        continue;
                    }
                    int i = 0;
                    foreach (var rewproc in Process.GetProcesses())
                    {
                        if (oldlist[i++].ToString() != rewproc.Id.ToString())
                        {
                            Invoke(updateProcess);
                            break;
                        }
                    }
                }
            }
            catch { }
        }

        private void TotalView(int m, int n)
        {
            try
            {
                this.tssCpu.Text = "CPU 사용: " + m.ToString() + " %";
                this.tssMemory.Text = "실제 메모리 : " + n.ToString() + " %";
            }
            catch { }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            bExit = true;
            if (!(ProcessThread == null))
                ProcessThread.Abort(); //스레드 종료
            if (!(checkThread == null))
                checkThread.Abort(); //스레드 종료
        }
    }
}
