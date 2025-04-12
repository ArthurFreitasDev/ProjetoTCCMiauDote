using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ProjetoTCCMiauDote.Helpers;
using System.Reflection.Metadata;

namespace ProjetoTCCMiauDote.Models
{
    public class Animal
    {
        [PrimaryKey, AutoIncrement]
        public int idAnimal { get; set; }
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public string Descricao { get; set; }
        public string Vacina {  get; set; }
        public string Raca { get; set; }
        public string Genero { get; set; }
        public string Porte { get; set; }
        public string Doenca { get; set; }
        public string Cor { get; set; }
        public string Foto { get; set; }
        public string Abrigo { get; set; }
        public string Castrado { get; set; }
        public string EstadoAdocao { get; set; }
        public string Tipo { get; set; }
        public string Adotante { get; set; }
        public string BolaEstadoAdocao1 { get; set; }
        public string BolaEstadoAdocao2 { get; set; }
        public string BolaEstadoAdocao3 { get; set; }
        public string BolaEstadoAdocao4 { get; set; }
    }
}
