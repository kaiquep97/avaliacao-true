using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrueStudio.Interfaces
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
