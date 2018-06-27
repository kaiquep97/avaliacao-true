using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueStudio.Models;
using TrueStudio.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrueStudio.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AvaliarProfessorPage : ContentPage
	{
        public AvaliarProfessorPage(Avaliacao avaliacao, IList<Professor> professors)
        {
            InitializeComponent();
            BindingContext = new AvaliarProfessorViewModel(avaliacao, professors);
        }
    }
}