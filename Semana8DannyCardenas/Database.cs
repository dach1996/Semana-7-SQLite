using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Semana8DannyCardenas
{
   public interface Database
    {
        SQLiteAsyncConnection GetConnection();
    }
}
