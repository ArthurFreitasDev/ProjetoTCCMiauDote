using ProjetoTCCMiauDote.Models;
using ProjetoTCCMiauDote.Helpers;
using System.Runtime.ConstrainedExecution;
using System.Diagnostics;
using Microsoft.Maui.Storage;
using System.Net.Http.Headers;
using ProjetoTCCMiauDote.Classes;
using Newtonsoft.Json;

namespace ProjetoTCCMiauDote.Views;

public partial class AdicionarAnimal : ContentPage
{
    string FotoUrl;
    private App PropriedadesApp;
    public AdicionarAnimal()
	{
		InitializeComponent();
        PropriedadesApp = (App)Application.Current;
    }

    private async void AdicionarAnimal_Clicked(object sender, EventArgs e)
    {
        try
        {
            Animal a = new Animal()
            {
                Nome = Animal_Nome.Text,
                DataNascimento = Animal_DataNascimento.Text,
                Vacina = Animal_Vacinas.Text,
                Doenca = Animal_Doencas.Text,
                Cor = Animal_Cor.Text,
                Genero = Animal_Genero.Text,
                Porte = Animal_Porte.Text,
                Descricao = Animal_Descricao.Text,
                Raca = Animal_Raca.Text,
                Castrado = Animal_Castrado.Text,
                EstadoAdocao = "EmEspera",
                Tipo = Animal_Tipo.Text,
                Abrigo = Animal_Abrigo.Text,
                Foto = FotoUrl,
                BolaEstadoAdocao1 = "bolaverde",
                BolaEstadoAdocao2 = "bolabranca",
                BolaEstadoAdocao3 = "bolabranca",
                BolaEstadoAdocao4 = "bolabranca",
            };
            await App.DbAnimal.InsertAnimal(a);
            await DisplayAlert("Animal Adicionado", "O animal foi adicionado", "OK");


            string IDTesteUsuario = App.User_Login.GetLogin();

            var allFuncionarios = await App.DbPessoa.GetAllPessoas();
            foreach (Pessoa p in allFuncionarios)
            {
                if (p.idPessoa.ToString() == IDTesteUsuario)
                {
                    Registros r = new Registros()
                    {
                        Nome = p.Nome,
                        Data = DateTime.Now.ToString("dd/MM/yyyy"),
                        CaracteristicaRegistro = "Adicionou animal: " + Animal_Nome.Text,
                    };
                    await App.DbRegistros.InsertRegistros(r);
                }
            }
        }
        catch(Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }


    async void EnviarImagem(FileResult arquivo)
    {
        try
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
                Debug.WriteLine(FotoUrl);
                Debug.WriteLine(FotoUrl);
                Debug.WriteLine(FotoUrl);
                Debug.WriteLine(FotoUrl);
                Debug.WriteLine(FotoUrl);
            }
            else
            {
                Debug.WriteLine("Falha na deserialização da resposta.");
            }
        }
        catch(Exception ex)
        {
            DisplayAlert("ops", ex.Message, "OK");
        }
    }


    private async void AdicionarImagemAnimal_Clicked(object sender, EventArgs e)
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
}