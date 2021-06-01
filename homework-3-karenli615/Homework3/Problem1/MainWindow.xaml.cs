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

namespace Problem1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   //List to store tvshows
        private List<TVShow> TVShows = new List<TVShow>();
        //Trims the double quotation and is used in PopulateLangugageFilter and PopulateCountryFilter methods
        private char[] CharactersToTrim = { '"', ' ' };
        public MainWindow()
        {
            InitializeComponent();
            //Reads all lines in TV Show Data.txt file
            var lines = File.ReadAllLines("TV Show Data.txt").Skip(1);
            //Foreach loop used to go thru all lines in file and adding each line in TVShows list
            foreach (var line in lines)
            {
                TVShows.Add(new TVShow(line));
            }

            PopulateListBox(TVShows);
            PopulateRatingFilter();
            PopulateCountryFilter();
            PopulateLanguageFilter();
        }
        //Method to populate listbox with selected language
        private void PopulateLanguageFilter()
        {
            CBoxLanguage.Items.Add("All");
            CBoxLanguage.SelectedIndex = 0;
            foreach (var show in TVShows)
            {
                var values = show.Language.Split(",");
                foreach (var val in values)
                {
                    if (string.IsNullOrWhiteSpace(val))
                    {
                        continue;
                    }
                    string cleanedValue = val.Trim(CharactersToTrim);
                    if (!CBoxLanguage.Items.Contains(cleanedValue))
                    {
                        CBoxLanguage.Items.Add(cleanedValue);
                    }
                }

            }
        }
        //Method to populate listbox with selected country
        private void PopulateCountryFilter()
        {
            CBoxCountry.Items.Add("All");
            CBoxCountry.SelectedIndex = 0;
            foreach (var show in TVShows)
            {
                var values = show.Country.Split(",");
                foreach (var val in values)
                {
                    if (string.IsNullOrWhiteSpace(val))
                    {
                        continue;
                    }
                    string cleanedValue = val.Trim(CharactersToTrim);
                    if (!CBoxCountry.Items.Contains(cleanedValue))
                    {
                        CBoxCountry.Items.Add(cleanedValue);
                    }
                }
               
            }
        }
        //Method to populate listbox with selected rating
        private void PopulateRatingFilter()
        {
            CboxRating.Items.Add("All");
            CboxRating.SelectedIndex = 0;
            foreach (var show in TVShows)
            {
                if (string.IsNullOrWhiteSpace(show.Rated))
                {
                    continue;
                }
                string cleanedValue = show.Rated.Trim();
                if (!CboxRating.Items.Contains(cleanedValue))
                {
                    CboxRating.Items.Add(cleanedValue);
                }
            }
        }

        //Method to populate all of the shows in the list tVshows
        private void PopulateListBox(List<TVShow> tVShows)
        {
            lstShows.Items.Clear();
            foreach(var show in tVShows)
            { 
                lstShows.Items.Add(show);
            }
        }
        //Steps into UpdateDataForFilters method when Rating ComboBox selection is changed
        private void CboxRating_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                UpdateDataForFilters();
        }
        //Steps into UpdateDataForFilters method when Country ComboBox selection is changed
        private void CBoxCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDataForFilters();
        }
        //Steps into UpdateDataForFilters method when Language ComboBox selection is changed
        private void CBoxLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDataForFilters();
        }
        //UpdateDataForFilters Method which populates listbox to show filtered shows
        private void UpdateDataForFilters()
        {
            
            if (CBoxCountry.SelectedValue is null || CBoxLanguage.SelectedValue is null || CboxRating.SelectedValue is null)
            {
                return;
            }
            

            List<TVShow> filteredShows;
            filteredShows = FilteredRatings(TVShows);
            filteredShows = FilteredCountry(filteredShows);
            filteredShows = FilteredLanguage(filteredShows);
            
            PopulateListBox(filteredShows);
            
        }
        //List for filtered countries
        private List<TVShow> FilteredCountry(List<TVShow> shows)
        {
            string country = CBoxCountry.SelectedValue.ToString();
            List<TVShow> filteredShows = new List<TVShow>();
            foreach (var show in shows)
            {
                if (country.ToLower() == "all")
                {
                    filteredShows.Add(show);
                }
                else if (show.Country.Contains(country))
                {
                    filteredShows.Add(show);
                }
            }
            return filteredShows;
        }
        //List for filtered languages
        private List<TVShow> FilteredLanguage(List<TVShow> shows)
        {
            string language = CBoxLanguage.SelectedValue.ToString();
            List<TVShow> filteredShows = new List<TVShow>();
            foreach (var show in shows)
            {
                if (language.ToLower() == "all")
                {
                    filteredShows.Add(show);
                }
                else if (show.Language.Contains(language))
                {
                    filteredShows.Add(show);
                }
            }
            return filteredShows;
        }
        //List for filtered ratings
        private List<TVShow> FilteredRatings(List<TVShow> shows)
        {
            string rating = CboxRating.SelectedValue.ToString();
            List<TVShow> filteredShows = new List<TVShow>();
            foreach (var show in shows)
            {
                if (rating.ToLower() == "all")
                {
                    filteredShows.Add(show);
                }
                else if (show.Rated.Contains(rating))
                {
                    filteredShows.Add(show);
                }
            }
            return filteredShows;
        }
        //ComboBoxes returns to All when reset button is clicked
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            CboxRating.SelectedIndex = 0;
            CBoxCountry.SelectedIndex = 0;
            CBoxLanguage.SelectedIndex = 0;
        }
        //Opens up a new window when lstShows selection is changed and steps into SetUptWindow method which outputs image and plot
        private void lstShows_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TVShow selectedShow = (TVShow)lstShows.SelectedItem;
            ShowDetailsWindow wnd = new ShowDetailsWindow();
            wnd.SetUpWindow(selectedShow);
            wnd.ShowDialog();

        }
    }
}
