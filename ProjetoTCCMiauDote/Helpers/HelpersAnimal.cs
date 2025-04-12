using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ProjetoTCCMiauDote.Models;

namespace ProjetoTCCMiauDote.Helpers
{
    public class HelpersAnimal
    {
        readonly SQLiteAsyncConnection _conn;

        public HelpersAnimal(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Animal>().Wait();
        }

        public Task<int> InsertAnimal(Animal a)
        {
            return _conn.InsertAsync(a);
        }

        public Task<List<Animal>> GetAllAnimal()
        {
            return _conn.Table<Animal>().ToListAsync();
        }

        public Task<List<Animal>> Busca(string a)
        {
            string sql = "select * from Animal where idAnimal = " + a;

            return _conn.QueryAsync<Animal>(sql);
        }

        public Task<List<Animal>> Delete(string a)
        {
            string sql = "delete from Animal where idAnimal = " + a;

            return _conn.QueryAsync<Animal>(sql);
        }

        public Task<List<Animal>> TesteGato(string a)
        {
            string sql = "select * where Tipo like %" + a + "%";

            return _conn.QueryAsync<Animal>(sql);
        }

        public Task<List<Animal>> Search(string q)
        {
            string sql = "Select * from Animal where Nome like '%" + q + "%'";

            return _conn.QueryAsync<Animal>(sql);
        }

        public Task<List<Animal>> Update(Animal p)
        {
            string sql = "Update Animal SET EstadoAdocao=?, Adotante=?,BolaEstadoAdocao1=?,BolaEstadoAdocao2=?,BolaEstadoAdocao3=?,BolaEstadoAdocao4=? where idAnimal=?";

            return _conn.QueryAsync<Animal>(sql, p.EstadoAdocao, p.Adotante, p.BolaEstadoAdocao1, p.BolaEstadoAdocao2, p.BolaEstadoAdocao3, p.BolaEstadoAdocao4, p.idAnimal);
        }
        public Task<List<Animal>> Update2(Animal p)
        {
            string sql = "Update Animal SET EstadoAdocao=?, BolaEstadoAdocao1=?,BolaEstadoAdocao2=?,BolaEstadoAdocao3=?,BolaEstadoAdocao4=? where idAnimal=?";

            return _conn.QueryAsync<Animal>(sql, p.EstadoAdocao, p.BolaEstadoAdocao1, p.BolaEstadoAdocao2, p.BolaEstadoAdocao3, p.BolaEstadoAdocao4, p.idAnimal);
        }
    }
}
