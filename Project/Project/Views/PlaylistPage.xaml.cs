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
	public partial class PlaylistPage : ContentPage
	{
		public PlaylistPage ()
		{
			InitializeComponent ();

            BindingContext = App.Locator.PlaylistPageViewModel;

            NavigationPage.SetHasNavigationBar(this, false);
        }
	}
}