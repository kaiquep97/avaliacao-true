using AvaliacaoTrue.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AvaliacaoTrue.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AvaliarAtendimentoPage : ContentPage
	{
		public AvaliarAtendimentoPage ()
		{
			InitializeComponent ();
            BindingContext = new AvaliarAtendimentoViewModel();
		}

	}
}