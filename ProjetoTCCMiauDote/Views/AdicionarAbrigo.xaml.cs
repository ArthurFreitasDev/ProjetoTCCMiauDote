namespace ProjetoTCCMiauDote.Views;
using ProjetoTCCMiauDote.Models;
using ProjetoTCCMiauDote.Helpers;
using System.Diagnostics;

public partial class AdicionarAbrigo : ContentPage
{
    private App PropriedadesApp;
    public AdicionarAbrigo()
	{
		InitializeComponent();
        PropriedadesApp = (App)Application.Current;
    }

    string emailadm;
    private async void AdicionarAbrigo_Clicked(object sender, EventArgs e)
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
            Pessoa a = new Pessoa()
            {
                Nome = Abrigo_Nome.Text,
                Cidade = Abrigo_Cidade.Text,
                Bairro = Abrigo_Bairro.Text,
                Rua = Abrigo_Rua.Text,
                Numero = Abrigo_Numero.Text,
                CEP = Abrigo_CEP.Text,
                Complemento = Abrigo_Complemento.Text,
                Telefone = Abrigo_Telefone.Text,
                Email = Abrigo_Email.Text,
                Senha = Abrigo_CrieUmaSenha.Text,
                IsADM = true,
                IsAbrigo = true,
            };
            await App.DbPessoa.InsertPessoa(a);
            await DisplayAlert("Abrigo Adicionado", "O abrigo foi adicionado", "OK");
        }

        
    }
}