namespace ProjetoTCCMiauDote;
using ProjetoTCCMiauDote.Models;
using Syncfusion.Maui.Core.Internals;
using System.Collections.ObjectModel;

public partial class EscolherAnimal : ContentPage
{
    string Escolha_TipoAnimal;
    ObservableCollection<Animal> lista_animais = new ObservableCollection<Animal>();    
	public EscolherAnimal()
	{
		InitializeComponent();
        lst_animais_EscolherAnimal.ItemsSource = lista_animais;
    }

    protected async override void OnAppearing()
    {
        try
        {
            if (lista_animais.Count == 0)
            {
                Escolha_TipoAnimal = App.Troca_Telas.GetTipoAnimal_TrocaTela();
                lista_animais.Clear();
                var allAnimais = App.DbAnimal.GetAllAnimal().Result;
                foreach (Animal i in allAnimais)
                {
                    if (i.Tipo == Escolha_TipoAnimal & i.EstadoAdocao == "EmEspera")
                    {
                        lista_animais.Add(i);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Ops!", ex.Message, "OK");
        }
    }

    private void lst_animais_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        Animal animal_selecionado =  e.SelectedItem as Animal;
        
        Navigation.PushAsync(new Views.TelaAnimal
        {
            BindingContext = animal_selecionado,
        });
    }

    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {
        if(lista_animais.Count != 0)
        {
            string q = e.NewTextValue;
            lista_animais.Clear();

            List<Animal> tmp = await App.DbAnimal.Search(q);
            foreach (Animal p in tmp)
            {
                lista_animais.Add(p);
            }
        }
    }
    
}