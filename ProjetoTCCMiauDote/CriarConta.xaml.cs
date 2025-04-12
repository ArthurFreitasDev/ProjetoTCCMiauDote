using ProjetoTCCMiauDote.Models;
using ProjetoTCCMiauDote.Helpers;
using System.Runtime.ConstrainedExecution;
using System.Diagnostics;
using Microsoft.Maui.Storage;
using System.Net.Http.Headers;
using ProjetoTCCMiauDote.Classes;
using Newtonsoft.Json;

namespace ProjetoTCCMiauDote;

public partial class CriarConta : ContentPage
{
    string FotoUrl;
    private App PropriedadesApp;
    public CriarConta()
	{
		InitializeComponent();
        PropriedadesApp = (App)Application.Current;
    }

    private async void CriarConta_Login(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Login");
    }

    private async void AnexarComprovante_Clickd(object sender, EventArgs e)
    {
        var value = await PickAndShow(ImageByte);
        if (value != null)
        {
            EnviarImagem(value);
        }
    }
    PickOptions ImageByte;

    public async Task<FileResult> PickAndShow(PickOptions options)
    {
        try
        {
            var result = await FilePicker.Default.PickAsync(options);
            if (result != null)
            {
                if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                    result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                {
                    using var stream = await result.OpenReadAsync();
                    byte[] bytes = new byte[stream.Length];
                    await stream.ReadAsync(bytes, 0, bytes.Length);
                }
            }
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Erro!" + ex.Message);
        }

        return null;
    }

    async void EnviarImagem(FileResult arquivo)
    {
        using var httpClient = new HttpClient();
        using var fileStream = await arquivo.OpenReadAsync();
        using var form = new MultipartFormDataContent();

        var fileContent = new StreamContent(fileStream);
        fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg"); // Ajuste o tipo de conteúdo conforme necessário

        form.Add(fileContent, "upload", arquivo.FileName);

        var response = await httpClient.PostAsync("https://alt.marciossupiais.shop/arthur_miaudote/", form);
        response.EnsureSuccessStatusCode();
        var responseContent = await response.Content.ReadAsStringAsync();

        // retorna resultado do link da imagem salva na API
        // exemplo:
        // {"status":"sucesso","arquivo":"https:\/\/marciossupiais.shop\/arthur_miaudote\/uploads\/file_66e9c3b5c52a5.jpg"}
        var apiResponse = JsonConvert.DeserializeObject<FIlesUpload>(responseContent);

        if (apiResponse != null)
        {
            string status = apiResponse.Status;
            FotoUrl = apiResponse.Arquivo;

            //
            Debug.WriteLine(FotoUrl);
        }
        else
        {
            Debug.WriteLine("Falha na deserialização da resposta.");
        }
    }

    private async void CriarConta_Clicked(object sender, EventArgs e)
    {
        try
        {
            Pessoa a = new Pessoa()
            {
                Nome = txtNome.Text,
                Email = txtEmail.Text,
                Telefone = txtTelefone.Text,
                DataNascimento = txtDataNascimento.Text,
                Senha = txtSenha.Text,
                CEP = txtCEP.Text,
                Rua = txtRua.Text,
                Numero = txtNumero.Text,
                Bairro = txtBairro.Text,
                Cidade = txtCidade.Text,
                Estado = txtEstado.Text,
                Complemento = txtComplemento.Text,
                Renda = txtRendaMensal.Text,
                OutroAnimal = txtOutroAnimal.Text,
                CPF = txtCPF.Text,
                LocalAdequado = txtEspacoAberto.Text,
                IsAbrigo = false,
                IsADM = false,
                ComprovanteResidencia = FotoUrl
            };
            await App.DbPessoa.InsertPessoa(a);
            App.User_Login.ManterLogin(a.idPessoa.ToString());
            await Shell.Current.GoToAsync("//MainPage");
            await DisplayAlert("Conta Criada!", "A sua Conta foi criada com exito", "OK");
            
        }
        catch (Exception ex)
        {
            DisplayAlert("Ops!", ex.Message, "OK");
        }
    }
}