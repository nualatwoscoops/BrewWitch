using System.Collections.ObjectModel;

namespace BrewWitch;

public partial class MainPage : ContentPage
{
    //APIDatasource aPIDatasource = new();
    public ObservableCollection<Beer> BeerList { get; set; } = new ObservableCollection<Beer>();

    public MainPage()
    {
        InitializeComponent();
        BeerCollectionView.ItemsSource = BeerList;
        LoadBeers();
    }

    // load list of beer recipes 
    private async void LoadBeers()
    {
        BeerList.Clear();
        var beers = await App.DatabaseService.Browse();
        foreach (var beer in beers)
        {
            BeerList.Add(beer);
        }
    }

    //Runs when add beer button is tapped
    private async void ButtonAddBeer_Clicked(object sentence, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(EntryName.Text))
        {
            await DisplayAlert("Oops", "Please enter a beer name!", "OK");
            return;
        }

        var newBeer = new Beer
        {
            Name = EntryName.Text,
            Style = EntryStyle.Text,
            Abv = double.TryParse(EntryAbv.Text, out double abv) ? abv : null
        };

        await App.DatabaseService.Add(newBeer);

        // Clear the fields
        EntryName.Text = string.Empty;
        EntryStyle.Text = string.Empty;
        EntryAbv.Text = string.Empty;

        // Reload the list
        LoadBeers();
    }
}