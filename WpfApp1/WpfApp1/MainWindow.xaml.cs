using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{

    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        PerformanceCounter cpu = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        PerformanceCounter ram = new PerformanceCounter("Memory", "% Committed Bytes In Use");
        BackgroundWorker _worker = null;
        

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 프로그레스바 컨트롤 증가 버튼 이벤트 핸들러
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiBtn_Start_Click(object sender, RoutedEventArgs e)
        {
            _worker = new BackgroundWorker();
            _worker.WorkerReportsProgress = true;
            _worker.DoWork += _worker_DoWork;
            _worker.ProgressChanged += _worker_ProgressChanged;
            _worker.RunWorkerCompleted += _worker_RunWorkerCompleted;
            _worker.RunWorkerAsync();
        }

        /// <summary>
        /// DoWorker 스레드 이벤트 핸들러
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                
                _worker.ReportProgress((int)ram.NextValue()); //값을 ReportProgress 매개변수로 전달
                _worker.ReportProgress((int)cpu.NextValue()); //값을 ReportProgress 매개변수로 전달
                Thread.Sleep(1000); //0.1초
            }
        }

        private void _worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            uiPb_Main.Value = e.ProgressPercentage;
            uiPb_Main2.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// 프로그레스바 컨트롤 작업 끝났을 때
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            uiPb_Main.Value = uiPb_Main.Maximum;
            uiPb_Main2.Value = uiPb_Main2.Maximum;
        }
    }
}
