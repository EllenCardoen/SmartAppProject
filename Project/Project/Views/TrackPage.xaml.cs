using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrackPage : ContentPage
    {
        public TrackPage()
        {
            InitializeComponent();

            BindingContext = App.Locator.TrackPageViewModel;

            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}