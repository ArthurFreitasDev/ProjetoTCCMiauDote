using ProjetoTCCMiauDote.Models;

namespace ProjetoTCCMiauDote.Views;

public partial class TelaAnimal : ContentPage
{
	public TelaAnimal()
	{
		InitializeComponent();
	}

    private async void ContentPage_Loaded(object sender, EventArgs e)
    {
		
    }

    private async void Adotar_Clicked(object sender, EventArgs e)
    {
        string id_usuario = App.User_Login.GetLogin();
        
        Animal id = BindingContext as Animal;
        Animal a = new Animal
        {
            idAnimal = id.idAnimal,
            EstadoAdocao = "Avaliando",
            Adotante = id_usuario,
            BolaEstadoAdocao1 = "bolaverde",
            BolaEstadoAdocao2 = "bolabranca",
            BolaEstadoAdocao3 = "bolabranca",
            BolaEstadoAdocao4 = "bolabranca",
        };
        await App.DbAnimal.Update(a);
        await Shell.Current.GoToAsync("//MainPage");
    }
}