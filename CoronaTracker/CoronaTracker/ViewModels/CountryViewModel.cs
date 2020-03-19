using CoronaTracker.Models;

namespace CoronaTracker.ViewModels
{
    class CountryViewModel
    {
        public CountryViewModel(CountryModel model)
        {
            Country = model.Country;
            Cases = $"{model.Cases}C {FormatToday(model.TodayCases)}";
            Deaths = $"{model.Deaths} D {FormatToday(model.TodayDeaths)}";
            Recovered = $"{model.Recovered}R";
            Critical = $"{model.Critical}S";

            string FormatToday(int value) => value > 0 ? $"(+{value})" : string.Empty;
        }

        public string Country { get; set; }
        public string Cases { get; set; }
        public string Deaths { get; set; }
        public string Recovered { get; set; }
        public string Critical { get; set; }
    }
}
