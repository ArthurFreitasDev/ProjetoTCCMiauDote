namespace ProjetoTCCMiauDote;

public partial class Logout : ContentPage
{
	public Logout()
	{
		InitializeComponent();
	}

    private async void ContentPage_Loaded(object sender, EventArgs e)
    {
		App.User_Login.Logout();
        await Task.Delay(1000);
        await Shell.Current.GoToAsync("//MainPage");
    }
}