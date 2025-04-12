using ProjetoTCCMiauDote.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTCCMiauDote.Helpers
{
    public class HelpersRegistros
    {
        readonly SQLiteAsyncConnection _conn;

        public HelpersRegistros(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Registros>().Wait();
        }

        public Task<int> InsertRegistros(Registros r)
        {
            return _conn.InsertAsync(r);
        }

        public Task<List<Registros>> GetAllRegistros()
        {
            return _conn.Table<Registros>().ToListAsync();
        }
    }
}
