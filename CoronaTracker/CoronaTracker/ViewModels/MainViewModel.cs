using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CoronaTracker.Models;
using CoronaTracker.Services;
using Xamarin.Forms;

namespace CoronaTracker.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            Countries = new ObservableCollection<CountryViewModel>();
            Service = DependencyService.Get<CountriesService>();
            UpdateCommand = new Command(async () => await UpdateAsync());
        }


        private CountriesService Service { get; }

        private ObservableCollection<CountryViewModel> countries;
        public ObservableCollection<CountryViewModel> Countries
        {
            get => countries;
            private set => SetProperty(ref countries, value);
        }

        private string errorMessage;

        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                SetProperty(ref errorMessage, value);
                HasError = !string.IsNullOrEmpty(value);
            }
        }

        private bool hasError;
        public bool HasError
        {
            get => hasError;
            set => SetProperty(ref hasError, value);
        }

        public Command UpdateCommand { get; }

        public async Task UpdateAsync()
        {
            try
            {
                IsBusy = true;
                ErrorMessage = string.Empty;
                var models = await Service.LoadAsync();
                var viewModels = models.Select(m => new CountryViewModel(m));
                Countries = new ObservableCollection<CountryViewModel>(viewModels);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                ErrorMessage = e.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
