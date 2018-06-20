using AvaliacaoTrue.Interfaces;
using AvaliacaoTrue.Models;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace AvaliacaoTrue.DAO
{
    public class AvaliacaoDAO : ICRUD<Avaliacao>
    {
        private SQLiteConnection connection;

        public AvaliacaoDAO()
        {
            this.connection = DependencyService.Get<ISQLite>().GetConnection();
            connection.CreateTable<Avaliacao>();
            connection.CreateTable<AvaliacaoProfessor>();
        }
        public void Delete(Avaliacao item)
        {
            connection.Delete<Avaliacao>(item);
        }

        public void Dispose()
        {
            connection.Dispose();
        }

        public Avaliacao Get(int id)
        {
            return connection.GetWithChildren<Avaliacao>(id);
        }

        public IList<Avaliacao> GetAll()
        {
            return connection.GetAllWithChildren<Avaliacao>();
        }

        public void Insert(Avaliacao item)
        {
            //connection.InsertWithChildren(item);
            connection.InsertAll(item.AvaliacaoProfessores);
            connection.Insert(item);
        }

        public void Update(Avaliacao item)
        {
            connection.UpdateWithChildren(item);
        }
    }
}
