using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTCCMiauDote.Models
{
    public class Registros
    {
        [PrimaryKey, AutoIncrement]
        public int idRegistro { get; set; }
        public string Nome { get; set; }
        public string Data { get; set; }
        public string CaracteristicaRegistro { get; set; }
    }
}
