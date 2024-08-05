using Microsoft.VisualBasic;
using ProjetoTCCMiauDote.Models;
using ProjetoTCCMiauDote.ViewModel;
using ProjetoTCCMiauDote.Views;

namespace ProjetoTCCMiauDote
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var Itens = new List<CarouselModel>
            {
                new CarouselModel {Imagem = "Resources/Imagens/Banner2.png"},
                new CarouselModel {Imagem = "Resources/Imagens/Banner1.png"}
            };
            MainPageCarouselView.ItemsSource = Itens;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }

        private async void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TelaAnimal());
        }
    }

}
