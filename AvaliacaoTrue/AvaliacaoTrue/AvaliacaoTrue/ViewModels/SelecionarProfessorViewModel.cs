using AvaliacaoTrue.DAO;
using AvaliacaoTrue.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AvaliacaoTrue.ViewModels
{
    public class SelecionarProfessorViewModel
    {
        public ObservableCollection<Professor> Professores { get; set; }


        public SelecionarProfessorViewModel()
        {
            Professores = new ObservableCollection<Professor>();
            using(var dao = new ProfessorDAO())
            {
                var profs = dao.GetAtivos();

                if (profs != null)
                    Professores = new ObservableCollection<Professor>(profs);
            }
        }

        public IList<Professor> GetSelecionados()
        {
            return Professores?.Where(x => x.Selected).ToList();
        }
    }
}
