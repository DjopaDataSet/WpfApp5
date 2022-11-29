
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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


namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summar
   
    public partial class MainWindow : Window
    {
        AleshkaEntities context;
        public MainWindow()
        {
            InitializeComponent();
            context = new AleshkaEntities();
            Service.ItemsSource = context.Service.ToList();
        }

        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            Button reda = sender as Button;
            var reda1 = reda.DataContext as Service;
            OpenFileDialog das = new OpenFileDialog();
            das.Title = "Выбери фотку пж";
            das.Filter = "All supported graphics|*.jpeg;*.jpg;*.png|" + " JPEG(*.jpeg;*.jpg)|*.jpeg;*.jpg|" +
            "Portable Network Graphic (*.png)|*.png";
            if (das.ShowDialog() == true)
            {
                reda1.ServicePhoto = new ServicePhoto { PhotoPath = das.FileName };
            }
            var reda2 = new Dobav(context, reda1);
            reda2.ShowDialog();

        }

        private void vih_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void dob_Click(object sender, RoutedEventArgs e)
        {
            var NewDob = new Service();
            context.Service.Add(NewDob);
            OpenFileDialog das = new OpenFileDialog();
            das.Title = "Выбери фотку пж";
            das.Filter = "All supported graphics|*.jpeg;*.jpg;*.png|" + " JPEG(*.jpeg;*.jpg)|*.jpeg;*.jpg|" +
            "Portable Network Graphic (*.png)|*.png";
            if (das.ShowDialog() == true)
            {
                NewDob.ServicePhoto = new ServicePhoto { PhotoPath = das.FileName };
            }
            var NewDob1 = new Dobav(context, NewDob);
            NewDob1.ShowDialog();
        }
    }
}
