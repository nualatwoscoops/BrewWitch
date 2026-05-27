using BrewWitch.Views;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Threading.Tasks;
using BrewWitch;

namespace BrewWitch;

public partial class MainPage : ContentPage
{
   public MainPage()
    {
        InitializeComponent();
        string? prevSearchValue = PreferencesService.PreviousSearchValue;
        SearchEntry.Text = prevSearchValue;
    }

   private async void OnCounterClicked(object sender, EventArgs e)
    {
        PreferencesService.PreviousSearchValue = SearchEntry.Text;
        
        BreweryService service = new BreweryService();

        string city = string.IsNullOrWhiteSpace(SearchEntry.Text) ? "perth" : SearchEntry.Text;

        try
        {
            List<Brewery> breweries = await service.GetBreweriesAsync(city);
            if (breweries != null && breweries.Count > 0)
            {
                BreweryList.ItemsSource = breweries;

                Console.WriteLine($"Loaded {breweries.Count} breweries.");
            }
            else
            {
                await DisplayAlert($"No breweries listed in {city}.", "Try a different city!", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("API Error", ex.Message, "OK");
        }
        //foreach (var brewery in breweries)
        //{
        //    Console.WriteLine($"Found Brewery: {brewery.Name}");
        //}
    }

    //private async void OnCounterClicked(object? sender, EventArgs e)
    //{
    //    //await Shell.Current.GoToAsync("settings");
    //    Navigation.PushModalAsync(new ItemPage());
    //}
}