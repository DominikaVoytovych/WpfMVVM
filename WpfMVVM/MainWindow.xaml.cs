using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfMVVM.Models;

namespace WpfMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<UserVM> users = new();
        public MainWindow()
        {
            InitializeComponent();
            dgvUsers.ItemsSource = users;
        }

        public void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            UserVM newUser = UserVM.CreateRandom(users.Count + 1); // створюємо випадкового користувача через метод у моделі
            users.Add(newUser); // додаємо користувача у список 
        }
    }

   
}