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

namespace WPF_JSON_RickAndMorty
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //https://rickandmortyapi.com/api/character

            using (var client = new HttpClient())
            {
                string jsonData = client.GetStringAsync("https://rickandmortyapi.com/api/character").Result;

                RickandMortyAPI api = JsonConvert.DeserializeObject<RickandMortyAPI>(jsonData);

                foreach (var character in api.results)
                {
                    lstCharacters.Items.Add(character);
                }
            }
        }

        private void lstCharacters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCharacter = (Character)lstCharacters.SelectedItem;
            ImageWindow imgwnd = new ImageWindow();
            imgwnd.imgCharacter.Source = new BitmapImage(new Uri(selectedCharacter.image));
            imgwnd.Show();
           
        }
    }
}
