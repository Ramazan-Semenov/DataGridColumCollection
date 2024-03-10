using System;
using System.Collections.Generic;
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

namespace ColumnCollection
{
    public class DataGridColumnBase : DataGridTextColumn,INotifyPropertyChanged
    {
        public int x { get; set; } = 0;
        public DataGridColumnBase()
        {
            Generic generic = new Generic();
            //create the data template
            DataTemplate cardLayout = new DataTemplate();
            //set up the stack panel
            FrameworkElementFactory spFactory = new FrameworkElementFactory(typeof(Grid));
            FrameworkElementFactory col1 = new FrameworkElementFactory(typeof(ColumnDefinition));
            FrameworkElementFactory col2 = new FrameworkElementFactory(typeof(ColumnDefinition));
            col1.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Auto));
            col2.SetValue(ColumnDefinition.WidthProperty, new GridLength(1, GridUnitType.Star));


            spFactory.AppendChild(col1);
            spFactory.AppendChild(col2);
            //set up the card holder textblock
            FrameworkElementFactory cardHolder = new FrameworkElementFactory(typeof(ContentControl));
            cardHolder.SetBinding(ContentControl.ContentProperty,new Binding(""));
            cardHolder.SetValue(Grid.ColumnProperty,0);
            spFactory.AppendChild(cardHolder);


            var qw = new Binding("x") { Source = this };

            FrameworkElementFactory but = new FrameworkElementFactory(typeof(Button));
       
            but.SetValue(Button.HeightProperty, 40.0);
            but.SetValue(Grid.ColumnProperty, 1);
            but.SetBinding(Button.ContentProperty, qw);
            but.AddHandler(Button.ClickEvent,new RoutedEventHandler(Button_Click));
            spFactory.AppendChild(but);
          
            //set the visual tree of the data template
            cardLayout.VisualTree = spFactory;
          
            this.HeaderTemplate = cardLayout;// generic["DataGridColumnBase"] as DataTemplate;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            x++;
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs("x"));
        }

        static DataGridColumnBase()
        {
           
            //DefaultStyleKeyProperty.OverrideMetadata(typeof(DataGridColumnBase), new FrameworkPropertyMetadata(typeof(DataGridColumnBase)));
        }
    }
    public partial class Generic
    {
        public Generic()
        {
            InitializeComponent();
        }
    }
}
