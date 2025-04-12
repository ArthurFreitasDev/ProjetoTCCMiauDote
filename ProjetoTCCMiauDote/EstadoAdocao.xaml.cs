using ProjetoTCCMiauDote.Models;
using Syncfusion.Maui.Core.Internals;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Diagnostics;
using ProjetoTCCMiauDote.Classes;

namespace ProjetoTCCMiauDote;

public partial class EstadoAdocao : ContentPage
{
    ObservableCollection<Animal> lista_animais = new ObservableCollection<Animal>();
    bool resposta;
    public EstadoAdocao()
    {
        InitializeComponent();
        lst_animais.ItemsSource = lista_animais;
    }

    protected async override void OnAppearing()
    {
        lista_animais.Clear();
 
        string id_pessoa = App.User_Login.GetLogin();
        var allFuncionarios = await App.DbAnimal.GetAllAnimal();
        foreach (Animal i in allFuncionarios)
        {
            if (i.Adotante == id_pessoa)
            {
                lista_animais.Add(i);
            }
        }
    }

    private async void lst_animais_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        resposta = await DisplayAlert("Cancelar", "Voce deseja cancelar a adocao", "sim", "nao");

        if(resposta)
        {
            resposta = false;

            Animal animal_selecionado = e.SelectedItem as Animal;
            App.AnimalSelecionado.RetirarAnimal(animal_selecionado);
            lista_animais.Clear();
            OnAppearing();
        }
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
    }
}