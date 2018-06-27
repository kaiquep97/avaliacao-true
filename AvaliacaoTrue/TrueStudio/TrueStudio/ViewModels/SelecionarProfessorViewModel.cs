using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using TrueStudio.DAO;
using TrueStudio.Models;
using Xamarin.Forms;

namespace TrueStudio.ViewModels
{
    public class SelecionarProfessorViewModel:BaseViewModel
    {
        public ObservableCollection<Professor> Professores { get; set; }

        public ICommand SelecionarCommand { get; set; }

        private bool isVisible;

        public bool IsVisible
        {
            get { return isVisible; }
            set
            {
                isVisible = value;
                OnPropertyChanged();
            }
        }


        public SelecionarProfessorViewModel(Avaliacao avaliacao)
        {
            IsVisible = true;
            Professores = new ObservableCollection<Professor>();
            using (var dao = new ProfessorDAO())
            {
                var profs = dao.GetAtivos();

                if (profs != null)
                    Professores = new ObservableCollection<Professor>(profs);
            }

            SelecionarCommand = new Command(() => {
                IsVisible = false;
                var selected = Professores?.Where(x => x.Selected).ToList();

                if (selected.Count < 1)
                {
                    App.Current.MainPage?.DisplayAlert("Selecione o professor", "Nenhum professor selecionado.", "Fechar");
                    IsVisible = true;
                    return;
                }
                var pages = new Views.AvaliarProfessorPage(avaliacao, selected);
                App.Current.MainPage?.Navigation.PushAsync(pages);
                IsVisible = true;
            });

        }
    }
}
