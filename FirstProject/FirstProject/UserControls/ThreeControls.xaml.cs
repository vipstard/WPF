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

namespace FirstProject.UserControls
{
    /// <summary>
    /// ThreeControls.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ThreeControls : UserControl
    {
        public ThreeControls()
        {
            InitializeComponent();
        }



        public string MyText
        {
            get { return (string)GetValue(MyTextProperty); }
            set { SetValue(MyTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyTextProperty =
            DependencyProperty.Register("MyText", typeof(string), typeof(ThreeControls), new PropertyMetadata(string.Empty));



        public ICommand MyCommand
        {
            get { return (ICommand)GetValue(MyCommandProperty); }
            set { SetValue(MyCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyCommandProperty =
            DependencyProperty.Register("MyCommand", typeof(ICommand), typeof(ThreeControls));


    }
}
