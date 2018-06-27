using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueStudio.Views;
using Xamarin.Forms;

namespace TrueStudio
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}
        private void Admin_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new SenhaPage());
        }

        private void Avaliar_Clicked(object sender, EventArgs e)
        {
            Navigation?.PushAsync(new AvaliarAtendimentoPage());
        }
    }
}
