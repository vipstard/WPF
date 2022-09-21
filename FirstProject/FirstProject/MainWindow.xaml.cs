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
using FirstProject.Models;
using FirstProject.ViewModels;

namespace FirstProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
         MainViewModel mainViewModel;
        public MainWindow()
        {
            InitializeComponent();
            mainViewModel = new MainViewModel();
            DataContext = mainViewModel;

            MessageBox.Show("알림 띄우기");
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            //labelTest1.Content = "내용 변경완료.";
          
            //List<User> myList1 = new List<User>();

            //User userA = new User();
            //userA.UserImg = @"C:\Users\Yoon DongIl\Desktop\윤동일\GIT\WPF\FirstProject\FirstProject\Resources\dd.jpg";
            //userA.Name = "Noah";
            //userA.UserAge = 14;


            //User userB = new User();
            //userB.UserImg = @"C:\Users\Yoon DongIl\Desktop\윤동일\GIT\WPF\FirstProject\FirstProject\Resources\dd.jpg";
            //userB.Name = "Liam";
            //userB.UserAge = 20;

            //myList1.Add(userA);
            //myList1.Add(userB);

            //ListView1.ItemsSource = myList1;
            mainViewModel.ProgressValue = 100;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
