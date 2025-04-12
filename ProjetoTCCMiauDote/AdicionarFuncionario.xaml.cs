using ProjetoTCCMiauDote.Models;
using ProjetoTCCMiauDote.Helpers;
using System.Diagnostics;

namespace ProjetoTCCMiauDote;

public partial class AdicionarFuncionario : ContentPage
{
	private App PropriedadesApp;
	public AdicionarFuncionario()
	{
		InitializeComponent();
		PropriedadesApp = (App)Application.Current;
	}

    private async void AdicionarFuncionario_Clicked(object sender, EventArgs e)
    {
		try
		{
            int controle = 1;
            string ValidacaoLogin = App.User_Login.GetLogin();
            var allpessoas = await App.DbPessoa.GetAllPessoas();
            foreach (Pessoa i in allpessoas)
            {
                if (i.IsAbrigo == true)
                {
                    controle++;
                    if (FuncionarioNome.Text != null & FuncionarioEmail.Text != null & FuncionarioSenha.Text != null & FuncionarioTelefone.Text != null)
                    {
                        Pessoa a = new Pessoa()
                        {
                            Nome = FuncionarioNome.Text,
                            Email = FuncionarioEmail.Text,
                            Telefone = FuncionarioTelefone.Text,
                            Senha = FuncionarioSenha.Text,
                            IsADM = true,
                            IsAbrigo = false,
                        };

                        await App.DbPessoa.InsertPessoa(a);

                        await DisplayAlert("Funcionario Adicionado", "O funcionario foi adicionado", "OK");
                        FuncionarioTelefone.Text = null;
                        FuncionarioSenha.Text = null;
                        FuncionarioNome.Text = null;
                        FuncionarioEmail.Text = null;

                        var allFuncionarios = await App.DbPessoa.GetAllPessoas();
                    }
                    else
                    {
                        await DisplayAlert("Ops!", "Preencha todos os campos", "OK");
                    }
                }
            }
            if (controle == 1)
                await DisplayAlert("Ops!", "Você não pode adicionar um funcionario se nao for um abrigo", "OK");
            
		}
		catch (Exception ex)
		{
			await DisplayAlert("Erro!", ex.Message, "OK");
		}
    }
}