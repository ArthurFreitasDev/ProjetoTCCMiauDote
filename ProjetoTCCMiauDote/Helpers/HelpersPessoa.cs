using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoTCCMiauDote.Models;

namespace ProjetoTCCMiauDote.Helpers
{
    public class HelpersPessoa
    {
        readonly SQLiteAsyncConnection _conn;

        public HelpersPessoa(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Pessoa>().Wait();
        }

        public Task<int> InsertPessoa(Pessoa a)
        {
            return _conn.InsertAsync(a);
        }

        public Task<List<Pessoa>> GetAllPessoas()
        {
            return _conn.Table<Pessoa>().ToListAsync();
        }
    }
}
