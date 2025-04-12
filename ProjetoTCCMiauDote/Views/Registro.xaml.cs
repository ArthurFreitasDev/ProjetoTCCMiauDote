using System.Collections.ObjectModel;
using ProjetoTCCMiauDote.Models;
namespace ProjetoTCCMiauDote.Views;
using System.Collections.ObjectModel;

public partial class Registro : ContentPage
{
	ObservableCollection<Registros> lista_registros = new ObservableCollection<Registros>();
	public Registro()
	{
		InitializeComponent();
		lst_registros_Registro.ItemsSource = lista_registros;
	}

	private async void ContentPage_Loaded(object sender, EventArgs e)
    {
        var allregistros = await App.DbRegistros.GetAllRegistros();

		foreach (Registros i in allregistros)
		{
            lista_registros.Add(i);
		}
    }
}