using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TrueStudio.DAO;
using TrueStudio.Models;

namespace TrueStudio.ViewModels
{
    public class ManagerViewModel : BaseViewModel
    {
        public ObservableCollection<Professor> Professores { get; set; }

        public ManagerViewModel()
        {
            Professores = new ObservableCollection<Professor>();
            AtualizaProfessores();
        }

        private void AtualizaProfessores()
        {
            using (var dao = new ProfessorDAO())
            {
                var profs = dao.GetAll();
                Professores = new ObservableCollection<Professor>(profs);
            }
            OnPropertyChanged(nameof(Professores));
        }

        public void AtualizaProfessor(Professor professor)
        {
            professor.Ativo = !professor.Ativo;
            using (var dao = new ProfessorDAO())
            {
                dao.Update(professor);
            }

            AtualizaProfessores();
        }
    }
}
