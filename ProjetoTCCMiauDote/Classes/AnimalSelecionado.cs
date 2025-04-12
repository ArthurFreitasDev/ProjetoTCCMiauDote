using ProjetoTCCMiauDote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTCCMiauDote.Classes
{
    public class AnimalSelecionado
    {
        public string idAnimalSelecionado;

        public void ValorIdAnimal(string idanimalselecionado)
        {
            idAnimalSelecionado = idanimalselecionado;
        }

        public string GetIdAnimal()
        {
            return idAnimalSelecionado;
        }

        public async void RetirarAnimal(Animal animal)
        {
            
            Animal a = new Animal
            {
                idAnimal = animal.idAnimal,
                EstadoAdocao = "EmEspera",
                Adotante = "null",
                BolaEstadoAdocao1 = "bolabranca",
                BolaEstadoAdocao2 = "bolabranca",
                BolaEstadoAdocao3 = "bolabranca",
                BolaEstadoAdocao4 = "bolabranca",
            };
            await App.DbAnimal.Update(a);
        }
    }
}
