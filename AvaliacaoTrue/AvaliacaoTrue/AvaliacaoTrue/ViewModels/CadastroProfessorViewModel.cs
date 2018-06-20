using AvaliacaoTrue.DAO;
using AvaliacaoTrue.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AvaliacaoTrue.ViewModels
{
    public class ProfessorViewModel
    {
        private Professor professor;

        public string Nome
        {
            get { return professor.Nome; }
            set { professor.Nome = value; }
        }

        public ICommand SalvarCommand { get; set; }

        public ProfessorViewModel()
        {
            professor = new Professor();

            SalvarCommand = new Command(()=> {
                using (var dao = new ProfessorDAO())
                {
                    dao.Insert(professor);
                }

                App.Current.MainPage?.DisplayAlert("Professor", "Professor adicionado com sucesso!", "OK");
                App.Current.MainPage?.Navigation.PopAsync();
                Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAllAsync();
            });
        }
    }
}
