using System.Collections.ObjectModel;
using System.Threading.Tasks;


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
    //to do buttons etc
    private async void OnCounterClicked(object sender, EventArgs e)
    {
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
}