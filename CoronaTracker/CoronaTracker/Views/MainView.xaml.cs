using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoronaTracker.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoronaTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is MainViewModel viewModel)
            {
                viewModel.UpdateCommand.Execute(null);
            }
        }
    }
}