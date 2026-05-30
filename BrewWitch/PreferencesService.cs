using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewWitch
{
    public class PreferencesService
    {
        public static readonly string PreviousSearchKey = "cityPrevSearch";

        public static string PreviousSearchValue
        {

            get
            {
                return Preferences.Get(PreviousSearchKey, "Perth");
            }

            set
            {
                Preferences.Set(PreviousSearchKey, value);
            }
        }

        public static readonly string AbvMinKey = "abvMin";

        public static double AbvMin
        {
            get => Preferences.Get(AbvMinKey, 0.0);
            set => Preferences.Set(AbvMinKey, value);
        }

        public static readonly string AbvMaxKey = "abvMax";

        public static double AbvMax
        {
            get => Preferences.Get(AbvMaxKey, 20.0);
            set => Preferences.Set(AbvMaxKey, value);
        }

        public static readonly string BeerTypeKey = "beerType";

        public static string BeerTypeValue
        {
            get => Preferences.Get(BeerTypeKey, "Larger");
            set => Preferences.Set(BeerTypeKey, value);
        }

        public static readonly string CountryKey = "Country";
        
        public static string CountryValue
        {
            get => Preferences.Get(CountryKey, "Australia");
            set => Preferences.Set(CountryKey, value);
        }

        public static readonly string DarkModeKey= "darkMode";

        public static bool DarkMode
        {
            get => Preferences.Get(DarkModeKey, false);
            set => Preferences.Set(DarkModeKey, value);
        }
    }
}
