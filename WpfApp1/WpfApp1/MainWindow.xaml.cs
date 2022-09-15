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
       

        Thread t = null;

        public MainWindow()
        {
            InitializeComponent();
            progressBar1.Maximum = 100;
            progressBar2.Maximum = 100;
            t = new Thread(Work);

            t.Start();
        }

        private void Work()

        {
            // Do You Expensive Work Here!
            while(true){
                //This Sleep is Just For Some timepass 
                Thread.Sleep(1000);
                UpdateProgressBar((int)cpu.NextValue(), (int)ram.NextValue()-10);
            }

            //MessageBox.Show("Finish !");
        }

        private void UpdateProgressBar(int i, int j)
        {
            // Action is delegate (means a function pointer) which is Pointing towards "SetProgress" method
            Action action1 = () => { SetProgressBar1(i); };
            Action action2 = () => { SetProgressBar2(j); };

            // Here Dispacthers Invoke (is a Syncronus)/ BegineInvoke (Is Asyncornus) in Called 
            progressBar1.Dispatcher.BeginInvoke(action1);
            progressBar2.Dispatcher.BeginInvoke(action2);

        }

        private void SetProgressBar1(int i)
        {
            progressBar1.Value = i;
        }

        private void SetProgressBar2(int j)
        {
            progressBar2.Value = j;
        }

        
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (t.IsAlive)
                t.Abort();
        }

        //// Abort Thread Button Code
        //private void button2_Click(object sender, RoutedEventArgs e)
        //{
        //    // Aborti   ng Thread here !
        //    if (t.IsAlive)
        //    {
        //        t.Abort();
        //        progressBar1.Value = 0;

        //    }
        //}

    }
}
