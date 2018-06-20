using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrueStudio.Models;
using Xamarin.Forms;

namespace TrueStudio.DAO
{
    public class ProfessorDAO : ICRUD<Professor>
    {
        private SQLiteConnection connection;

        public ProfessorDAO()
        {
            this.connection = DependencyService.Get<Interfaces.ISQLite>().GetConnection();
            this.connection.CreateTable<Professor>();
        }

        public IList<Professor> GetAtivos()
        {
            return connection.Table<Professor>()
                .Where(x => x.Ativo).ToList();
        }

        public void Delete(Professor item)
        {
            connection.Delete<Professor>(item);
        }

        public void Dispose()
        {
            connection.Dispose();
        }

        public Professor Get(int id)
        {
            return connection.Table<Professor>()
                .Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public IList<Professor> GetAll()
        {
            return connection.Table<Professor>().ToList();
        }

        public void Insert(Professor item)
        {
            connection.Insert(item);
        }

        public void Update(Professor item)
        {
            connection.Update(item);
        }
    }
}
