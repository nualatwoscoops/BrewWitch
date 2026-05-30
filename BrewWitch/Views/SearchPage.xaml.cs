using System.Collections.ObjectModel;
using System.Linq;
namespace BrewWitch.Views;
public partial class SearchPage : ContentPage
{
    
    public ObservableCollection<Beer> FilteredBeers { get; set; } = new ObservableCollection<Beer>();
    
    //On startup all beers are loaded and page initalised
    public SearchPage()
    {
        InitializeComponent();
        BeerResultsList.ItemsSource = FilteredBeers;
        LoadBeers();
    }
    //loads all beers from user database to a list
    private async void LoadBeers()
    {
        FilteredBeers.Clear();
        var beers = await App.DatabaseService.Browse();
        foreach (var beer in beers)
        {
            FilteredBeers.Add(beer);
        }
    }

    //filters beers by selected type and ABV range
    private async void LoadFilteredBeers()
    {
        FilteredBeers.Clear();
        var allBeers = await App.DatabaseService.Browse();
        var filtered = allBeers.Where(beer => 
            (BeerTypePicker.SelectedItem == null || beer.Style == 
            BeerTypePicker.SelectedItem.ToString()) &&
            (beer.Abv >= ABVMinSlider.Value && beer.Abv <=ABVMaxSlider.Value)
        );
        foreach (var beer in filtered)
        {
            FilteredBeers.Add(beer);
        }
    }

    //saves preferences  and filters list of beers
    private void SavePreferences_Clicked(object sender, EventArgs e)
    {
        PreferencesService.BeerTypeValue = BeerTypePicker.SelectedItem?.ToString() ?? "";
        PreferencesService.AbvMin = ABVMinSlider.Value;
        PreferencesService.AbvMax = ABVMaxSlider.Value;
        DisplayAlert("Saved!", "Your preferences have been saved.", "OK");
        LoadFilteredBeers();
    }

    //updates min ABV values as slider moves
    private void ABVMinSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            ABVMinSliderLabel.Text = $"Min ABV: {ABVMinSlider.Value:F1}";
        }
    //updates max ABV values as slider moves
    private void ABVMaxSlider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        ABVMaxSliderLabel.Text = $"Max ABV: {ABVMaxSlider.Value:F1}";
    }

    //resets list to show all beers in user database
    private void LoadAllBeers_Clicked(object sender, EventArgs e)
    {
        LoadBeers();
    }

}