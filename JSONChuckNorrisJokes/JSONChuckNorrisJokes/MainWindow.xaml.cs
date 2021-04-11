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

namespace JSONChuckNorrisJokes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Displays categories from the api and adds into combobox
            using (var client = new HttpClient())
            {
                string categoryData = client.GetStringAsync("https://api.chucknorris.io/jokes/categories").Result;
                List<string> categories = JsonConvert.DeserializeObject<List<string>>(categoryData);

                CboxCategories.Items.Add("All");
                foreach (string category in categories)
                {
                    CboxCategories.Items.Add(category);
                }
            }


        }
        private void btnGo_Click(object sender, RoutedEventArgs e)
        { 
            //Displays random joke if All is selected in combobox
            if (CboxCategories.SelectedValue == "All")
            {
                ChuckNorrisAPI2 chuckNorrisAPI2;
                using (var client = new HttpClient())
                {
                    string randomjokeData = client.GetStringAsync("https://api.chucknorris.io/jokes/random").Result;
                    chuckNorrisAPI2 = JsonConvert.DeserializeObject<ChuckNorrisAPI2>(randomjokeData);
                }
                
                txtBlockJoke.Text = chuckNorrisAPI2.value;
            }
            else
            {   //Displays selected category joke
                ChuckNorrisAPI1 chuckNorrisAPI1;
                string selectedcategory = CboxCategories.SelectedItem.ToString();
                using (var client = new HttpClient())
                {
                    string selectedjokeData = client.GetStringAsync($"https://api.chucknorris.io/jokes/random?category={selectedcategory}").Result;
                    chuckNorrisAPI1 = JsonConvert.DeserializeObject<ChuckNorrisAPI1>(selectedjokeData);
                }
                
                txtBlockJoke.Text = chuckNorrisAPI1.value;
            }

        }
    }
}
