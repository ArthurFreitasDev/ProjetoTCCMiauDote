using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTCCMiauDote.Classes
{
    public class ControleTrocadeTelas
    {
        public string TipoAnimal { get; set; }
        public async void TipoAnimal_TrocaTela(string tipoanimal)
        {
            TipoAnimal = tipoanimal;
        }

        public string GetTipoAnimal_TrocaTela()
        {
            Console.WriteLine("========================");
            Console.WriteLine(TipoAnimal);
            Console.WriteLine("========================");
            if (TipoAnimal == null)
            {
                return "ambos";
            }
            return TipoAnimal;
        }
    }
}
