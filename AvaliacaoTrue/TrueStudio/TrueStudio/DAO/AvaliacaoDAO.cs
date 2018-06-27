using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using TrueStudio.Interfaces;
using TrueStudio.Models;
using Xamarin.Forms;

namespace TrueStudio.DAO
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
            //var txt = connection.Table<Avaliacao>().ToList();

            //return txt;

            try
            {
                var teste = connection.GetAllWithChildren<AvaliacaoProfessor>();
                return connection.GetAllWithChildren<Avaliacao>(recursive:true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Insert(Avaliacao item)
        {
            //connection.InsertWithChildren(item);
            connection.Insert(item);
            connection.InsertAllWithChildren(item.AvaliacaoProfessores);
            connection.UpdateWithChildren(item);
        }

        public void Update(Avaliacao item)
        {
            connection.UpdateWithChildren(item);
        }
    }
}
