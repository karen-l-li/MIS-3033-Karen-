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

namespace Problem2
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

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {   //Checks to see if user inputted text in textbox
            if (string.IsNullOrEmpty(txtboxBreed.Text) == true)
            {
                MessageBox.Show("Please enter a breed");
                return;
            }
            //Accepts user input from textbox and formats input for url compatibility
            string breed = txtboxBreed.Text.Trim().ToLower();
            if (breed.Contains(' ') == true)
            {
                string[] dogInfo = breed.Split(' ');
                string subBreed = dogInfo[0];
                string mainBreed = dogInfo[1];
                breed = $"{mainBreed}/{subBreed}";
            }

            string url = $"https://dog.ceo/api/breed/{breed}/images/random";
            DogAPI dogAPI;
            //Connects to web server and outputs image if success else returns an error message
            using(var client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string dogData = response.Content.ReadAsStringAsync().Result;
                    dogAPI = JsonConvert.DeserializeObject<DogAPI>(dogData);

                    imgDog.Source = new BitmapImage(new Uri(dogAPI.message));
                }
                else
                {
                    MessageBox.Show("Sorry, this breed does not exist.");
                    txtboxBreed.Clear();
                }

            }
        }
    }
}
