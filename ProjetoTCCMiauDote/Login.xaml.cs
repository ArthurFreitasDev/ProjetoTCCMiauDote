namespace ProjetoTCCMiauDote;
using ProjetoTCCMiauDote.Models;
using ProjetoTCCMiauDote.Classes;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    

    private async void btnLogin(object sender, EventArgs e)
    {
        int IDManterLogin = 0;
        try
        {
            var allFuncionarios = await App.DbPessoa.GetAllPessoas();
            foreach (Pessoa i in allFuncionarios)
            {
                if(i.Email == Login_Email.Text && i.Senha == Login_Senha.Text)
                {
                    IDManterLogin = i.idPessoa;
                    App.User_Login.ManterLogin(i.idPessoa.ToString());
                    await Shell.Current.GoToAsync("//MainPage");
                }
            }
            if (IDManterLogin == 0)
                await DisplayAlert("Ops!", "Login invalido, email ou senha incorreto", "OK");
        }
        catch(Exception ex)
        {
            await DisplayAlert("Erro!", ex.Message, "OK");
        }
    }

    private async void Login_CriarConta(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//CriarConta");
    }
}