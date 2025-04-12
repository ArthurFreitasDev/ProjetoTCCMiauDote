namespace ProjetoTCCMiauDote.Views;
using ProjetoTCCMiauDote.Models;
using Syncfusion.Maui.Core.Internals;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Diagnostics;
using ProjetoTCCMiauDote.Classes;

public partial class TelaEstadoAdocaoFuncionario : ContentPage
{
    ObservableCollection<Animal> lista_animais = new ObservableCollection<Animal>();
    public TelaEstadoAdocaoFuncionario()
    {
        InitializeComponent();
        lst_animais.ItemsSource = lista_animais;
    }

    private async void ContentPage_Loaded(object sender, EventArgs e)
    {
        lista_animais.Clear();

        var allFuncionarios = await App.DbAnimal.GetAllAnimal();
        foreach (Animal i in allFuncionarios)
        {
            if(i.EstadoAdocao == "Avaliando" | i.EstadoAdocao == "ProntoPB" | i.EstadoAdocao == "Aprovado")
                lista_animais.Add(i);
        }
    }

    private void lst_animais_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        Animal animal_selecionado = e.SelectedItem as Animal;

        Navigation.PushAsync(new Views.AnaliseAdotante
        {
            BindingContext = animal_selecionado,
        });
    }
}