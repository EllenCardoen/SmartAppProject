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
	public partial class AlbumPage : ContentPage
	{
		public AlbumPage ()
		{
			InitializeComponent ();


            BindingContext = App.Locator.AlbumPageViewModel;

            NavigationPage.SetHasNavigationBar(this, false);
        }
	}
}