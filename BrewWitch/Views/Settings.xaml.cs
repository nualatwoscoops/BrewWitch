namespace BrewWitch.Views;
public partial class Settings : ContentPage
{
    public Settings()
    {
        InitializeComponent();
        Application.Current.UserAppTheme = PreferencesService.DarkMode ? AppTheme.Dark : AppTheme.Light;
        DarkModeSwitch.IsToggled = PreferencesService.DarkMode;
    }

    private void DarkModeSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        if (e.Value)
            Application.Current.UserAppTheme = AppTheme.Dark;
        else
            Application.Current.UserAppTheme = AppTheme.Light;

        PreferencesService.DarkMode = e.Value;
    }
}