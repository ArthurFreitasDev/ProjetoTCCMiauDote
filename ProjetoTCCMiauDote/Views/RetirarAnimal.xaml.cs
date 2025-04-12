namespace ProjetoTCCMiauDote.Views;
using ProjetoTCCMiauDote.Models;

public partial class RetirarAnimal : ContentPage
{
	public RetirarAnimal()
	{
		InitializeComponent();
	}

    private async void ContentPage_Loaded(object sender, EventArgs e)
    {
        Animal id = BindingContext as Animal;
        Animal a = new Animal
        {
            idAnimal = id.idAnimal,
            EstadoAdocao = "EmEspera",
            Adotante = "null",
            BolaEstadoAdocao1 = "bolabranca",
            BolaEstadoAdocao2 = "bolabranca",
            BolaEstadoAdocao3 = "bolabranca",
            BolaEstadoAdocao4 = "bolabranca",
        };
        await App.DbAnimal.Update(a);

        await Task.Delay(200);
        await Shell.Current.GoToAsync("//MainPage");
    }
}