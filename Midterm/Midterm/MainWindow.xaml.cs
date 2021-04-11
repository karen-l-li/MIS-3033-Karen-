using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace Midterm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using (var client = new HttpClient())
            {
                string restaurantInfo = client.GetStringAsync("http://pcbstuou.w27.wh-2.com/webservices/3033/api/restaurants/names").Result;
                RestaurantsAPI api = JsonConvert.DeserializeObject<RestaurantsAPI>(restaurantInfo);

                foreach (var restaurant in api.restaurants)
                {
                    CboxRestNames.Items.Add(restaurant);
                }
            }

        }
        RestaurantAPI2 api2;
        private void CboxRestNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string baseurl = "http://pcbstuou.w27.wh-2.com/webservices/3033/api/restaurants?id=";
            string selectedUrl = baseurl + CboxRestNames.SelectedIndex.ToString();
            using (var client = new HttpClient())
            {
                string menuInfo = client.GetStringAsync(selectedUrl).Result;
                api2 = JsonConvert.DeserializeObject<RestaurantAPI2>(menuInfo);

                foreach (var item in api2.menu)
                {
                    lstBoxMenuItems.Items.Add(item);
                }
            }
        }
        private void lstBoxMenuItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Menu selectedItem = (Menu)lstBoxMenuItems.SelectedItems;

            using (var client = new HttpClient())
            {
                string itemData = client.GetStringAsync()
            }
        }
    }
}
