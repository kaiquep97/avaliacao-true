using AvaliacaoTrue.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AvaliacaoTrue
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private void Avaliar_Clicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new AvaliarAtendimentoPage());
        }

        private void Admin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ManagerPage());
        }
	}
}
