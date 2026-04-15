using BrewWitch;

namespace BrewWitch
{
    public partial class App : Application
    {
        private static BeerDatabase? databaseService;

        public static BeerDatabase DatabaseService
        {
            get 
            { 
                if(databaseService == null)
                {
                    databaseService = new BeerDatabase(Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData), "beer.db"));
                }
                return databaseService;
            } 
            set { databaseService= value; }
        }


        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}