namespace ProjetoTCCMiauDote;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private void btnLogin(object sender, EventArgs e)
    {

    }

    private async void Login_CriarConta(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CriarConta());
    }
}