using ProjetoTCCMiauDote.Models;

namespace ProjetoTCCMiauDote.Views;

public partial class AnaliseAdotante : ContentPage
{
	public AnaliseAdotante()
	{
		InitializeComponent();
	}
    string idanimal_;
    private async void ContentPage_Loaded(object sender, EventArgs e)
    {
		var animal_ = BindingContext as Animal;
        idanimal_ = animal_.idAnimal.ToString();
		string adotante = animal_.Adotante.ToString();
		var allPessoas = await App.DbPessoa.GetAllPessoas();
		foreach ( var p in allPessoas )
		{
			if(p.idPessoa.ToString() == adotante)
			{
				BindingContext = p;
			}
		}
    }

    private async void Aprovar_Clicked(object sender, EventArgs e)
    {
        Animal i = new Animal
        {
            idAnimal = int.Parse(idanimal_),
            EstadoAdocao = "Aprovado",
            BolaEstadoAdocao1 = "bolaverde",
            BolaEstadoAdocao2 = "bolaverde",
            BolaEstadoAdocao3 = "bolabranca",
            BolaEstadoAdocao4 = "bolabranca",
        };
        await App.DbAnimal.Update2(i);
    }

    private async void Pronto_Clicked(object sender, EventArgs e)
    {
        Animal i = new Animal
        {
            idAnimal = int.Parse(idanimal_),
            EstadoAdocao = "ProntoPB",
            BolaEstadoAdocao1 = "bolaverde",
            BolaEstadoAdocao2 = "bolaverde",
            BolaEstadoAdocao3 = "bolaverde",
            BolaEstadoAdocao4 = "bolabranca",
        };
        await App.DbAnimal.Update2(i);
    }

    private async void Adotado_Clicked(object sender, EventArgs e)
    {
        Animal i = new Animal
        {
            idAnimal = int.Parse(idanimal_),
            EstadoAdocao = "Adotado",
            BolaEstadoAdocao1 = "bolaverde",
            BolaEstadoAdocao2 = "bolaverde",
            BolaEstadoAdocao3 = "bolaverde",
            BolaEstadoAdocao4 = "bolaverde",
        };
        await App.DbAnimal.Update2(i);
    }

    private async void Cancelar_Clicked(object sender, EventArgs e)
    {
        Animal i = new Animal
        {
            idAnimal = int.Parse(idanimal_),
            EstadoAdocao = "EmEspera",
            BolaEstadoAdocao1 = "bolabranca",
            BolaEstadoAdocao2 = "bolabranca",
            BolaEstadoAdocao3 = "bolabranca",
            BolaEstadoAdocao4 = "bolabranca",
        };
        await App.DbAnimal.Update2(i);
    }
}