using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ProjetoTCCMiauDote.Helpers;

namespace ProjetoTCCMiauDote.Models
{
    public class Pessoa
    {
        [PrimaryKey, AutoIncrement]
        public int idPessoa { get; set; }
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Complemento { get; set; }
        public string Telefone { get; set; }
        public string Renda { get; set; }
        public string ComprovanteResidencia { get; set; }
        public string OutroAnimal { get; set; }
        public string CPF { get; set; }
        public string LocalAdequado { get; set; }
        public bool IsADM { get; set; }
        public bool IsAbrigo { get; set; }
    }
}
