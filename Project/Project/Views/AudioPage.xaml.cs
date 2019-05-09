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
	public partial class AudioPage : ContentPage
	{
        public AudioPage(Track selectedTrack)
        {
            InitializeComponent();

            App.Locator.AudioPageViewModel.SelectedTrack = selectedTrack;

            BindingContext = App.Locator.AudioPageViewModel;

        }
	}
}