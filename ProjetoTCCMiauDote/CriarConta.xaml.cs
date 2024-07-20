namespace ProjetoTCCMiauDote;

public partial class CriarConta : ContentPage
{
	public CriarConta()
	{
		InitializeComponent();
	}

    private async void CriarConta_Login(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new Login());
    }
}