using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace DataGridColumCollection
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        public ObservableCollection<wwww> qw { get; set; } = new ObservableCollection<wwww>();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (zz.Columns[0].Visibility== Visibility.Collapsed)
            {
                zz.Columns[0].Visibility = Visibility.Visible;
            }
            else
            {
                zz.Columns[0].Visibility = Visibility.Collapsed;
            }
            

            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs("qw"));
        }
    }

    public class wwww
    {
        public int id { get; set; }
    }
}
