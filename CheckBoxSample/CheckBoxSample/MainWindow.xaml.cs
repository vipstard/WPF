using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace CheckBoxSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CbAllFeatures_OnChecked(object sender, RoutedEventArgs e)
        {
            //전체체크를 누르면 개별 체크가 다 체크된다.
                bool newVal = (cbAllFeatures.IsChecked == true);    
                cbFeatureAbc.IsChecked = newVal;
                cbFeatureXYz.IsChecked = newVal;
                cbFeatureWww.IsChecked = newVal;
        }

        private void CbFeatures_OnChecked(object sender, RoutedEventArgs e)
        {
            cbAllFeatures.IsChecked = null;
            
            if((cbFeatureAbc.IsChecked == true) && (cbFeatureXYz.IsChecked == true) && (cbFeatureWww.IsChecked==true))
                cbAllFeatures.IsChecked=true;

            if ((cbFeatureAbc.IsChecked == false) && (cbFeatureXYz.IsChecked == false) && (cbFeatureWww.IsChecked == false))
                cbAllFeatures.IsChecked = false;

        }
    }
}
