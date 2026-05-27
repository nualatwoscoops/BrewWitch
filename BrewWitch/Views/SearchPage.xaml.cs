namespace BrewWitch.Views;
public partial class SearchPage : ContentPage
{
    public SearchPage()
    {
        InitializeComponent();
    }

    private async void OnSearchClicked(object sender, EventArgs e)
    {
        BreweryService service = new BreweryService();
        string city = string.IsNullOrWhiteSpace(SearchEntry.Text) ? "perth" : SearchEntry.Text;
        try
        {
            List<Brewery> breweries = await service.GetBreweriesAsync(city);
            if (breweries != null && breweries.Count > 0)
            {
                BreweryList.ItemsSource = breweries;
            }
            else
            {
                await DisplayAlert("No Results", $"No breweries listed in {city}.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("API Error", ex.Message, "OK");
        }
    }
}