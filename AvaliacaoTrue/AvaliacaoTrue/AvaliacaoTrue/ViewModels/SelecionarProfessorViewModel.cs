using AvaliacaoTrue.DAO;
using AvaliacaoTrue.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AvaliacaoTrue.ViewModels
{
    public class SelecionarProfessorViewModel
    {
        public ObservableCollection<Professor> Professores { get; set; }

        public ICommand SelecionarCommand { get; set; }

        public SelecionarProfessorViewModel(Avaliacao avaliacao)
        {
            Professores = new ObservableCollection<Professor>();
            using(var dao = new ProfessorDAO())
            {
                var profs = dao.GetAtivos();

                if (profs != null)
                    Professores = new ObservableCollection<Professor>(profs);
            }

            SelecionarCommand = new Command(() =>{

                var selected = Professores?.Where(x => x.Selected).ToList();

                if (selected.Count < 1)
                {
                    App.Current.MainPage?.DisplayAlert("Selecione o professor", "Nenhum professor selecionado.", "Fechar");
                    return;
                }

                App.Current.MainPage?.Navigation.PushAsync(new AvaliacaoTrue.Views.AvaliarProfessorPage(avaliacao, selected));
            });

        }
    }
}
