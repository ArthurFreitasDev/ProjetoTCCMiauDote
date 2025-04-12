namespace ProjetoTCCMiauDote;
using ProjetoTCCMiauDote.Models;
using ProjetoTCCMiauDote.Views;

public partial class TelaAdministrador : ContentPage
{
	public TelaAdministrador()
	{
		InitializeComponent();
	}

    string emailadm;
    protected async override void OnAppearing()
    {
        string ValidacaoLogin = App.User_Login.GetLogin();
        var allpessoas = await App.DbPessoa.GetAllPessoas();
        foreach (Pessoa i in allpessoas)
        {
            if (ValidacaoLogin == i.idPessoa.ToString())
                emailadm = i.Email;
        }
        if (emailadm == "Arthur@")
        {
            btnAdicionarAbrigo.IsVisible = true;
            btnAdicionarAbrigo.IsEnabled = true;
        }
        else
        {
            btnAdicionarAbrigo.IsVisible = false;
            btnAdicionarAbrigo.IsEnabled = false;
        }
    }
    private async void AdicionarFuncionario_click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AdicionarFuncionario());
    }

    private async void AdicionarAnimal_click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AdicionarAnimal());
    }

    private async void Registros_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Registro());
    }

    private async void EstadoAdocaoFuncionarios_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TelaEstadoAdocaoFuncionario());
    }

    private async void AdicionarAbrigo_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AdicionarAbrigo());
    }
}