using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Linq;
using Newtonsoft.Json;
using SplinterTools.Helpers;

namespace SplinterTools
{
    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {


        public TestWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
        }

        List<ListViewItem> ITEMS = new List<ListViewItem>();

        public class Device
        {
            public string IP { get; set; }
            public string Ping { get; set; }
            public string DNS { get; set; }
            public string MAC { get; set; }
            public string Manufacturer { get; set; }
        }




        private void ChangeRowColor()
        {
            ITEMS[4].Background = Brushes.Green;
            listView.Items.Refresh();
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
  
        {
            for (int i = 1; i < 20; i++)
            {
                ListViewItem OneItem = new ListViewItem();
                OneItem.Background = Brushes.LightGray;
                OneItem.Content = new Device() { IP = "1.1.1.1", Ping = "30ms", DNS = "XYZ", MAC = "2F:3C:5F:41:F9", Manufacturer = "Intel" };
                ITEMS.Add(OneItem);
                listView.ItemsSource = ITEMS;
            }
            listView.Items.Refresh();
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ChangeRowColor();
        }
    }
}
