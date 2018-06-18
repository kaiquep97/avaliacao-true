using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaliacaoTrue.Interfaces
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
