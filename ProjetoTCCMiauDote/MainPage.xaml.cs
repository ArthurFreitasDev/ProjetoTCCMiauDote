using Microsoft.Maui.Layouts;
using ProjetoTCCMiauDote.Views;

namespace ProjetoTCCMiauDote
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainFlyoutPage());
        }
    }

}
