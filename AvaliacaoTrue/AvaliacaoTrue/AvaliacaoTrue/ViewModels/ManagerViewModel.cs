using AvaliacaoTrue.DAO;
using AvaliacaoTrue.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AvaliacaoTrue.ViewModels
{
    public class ManagerViewModel
    {
        public ObservableCollection<Professor> Professores { get; set; }

        public ManagerViewModel()
        {
            Professores = new ObservableCollection<Professor>();

            using(var dao = new ProfessorDAO())
            {
                var profs = dao.GetAll();
                foreach (var item in profs)
                {
                    Professores.Add(item);
                }
            }
        }
    }
}
