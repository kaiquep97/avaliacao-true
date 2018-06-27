using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueStudio.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrueStudio.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListaProfessorPage : ContentPage
	{
		public ListaProfessorPage (Avaliacao avaliacao)
		{
			InitializeComponent ();
            BindingContext = new ViewModels.SelecionarProfessorViewModel(avaliacao);
		}

        private void Lista_Selected(object sender, SelectedItemChangedEventArgs args)
        {
            ((ListView)sender).SelectedItem = null;
        }
	}
}