using ProjetoTCCMiauDote.Classes;
using ProjetoTCCMiauDote.Models;
using ProjetoTCCMiauDote.ViewModel;
using ProjetoTCCMiauDote.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;


namespace ProjetoTCCMiauDote
{
    public partial class MainPage : ContentPage
    {
        private int _currentIndex = 0;

        //ObservableCollection<Animal> lista_animais_cao = new ObservableCollection<Animal>();

        public ObservableCollection<ControleTrocadeTelas> ItensTroca { get; set; }


        public ObservableCollection<Models.Animal> gatos = new ObservableCollection<Models.Animal>();
        public ObservableCollection<Models.Animal> cao = new ObservableCollection<Models.Animal>();



        public MainPage()
        {
            InitializeComponent();


            col_gatos.ItemsSource = gatos;
            col_cao.ItemsSource = cao;

            ItensTroca = new ObservableCollection<ControleTrocadeTelas>();

            var Itens = new List<CarouselModel>
            {
                new CarouselModel {Imagem = "Resources/Imagens/Banner2.png"},
                new CarouselModel {Imagem = "Resources/Imagens/Banner1.png"},
                new CarouselModel {Imagem = "Resources/Imagens/Banner3.png"},
                new CarouselModel {Imagem = "Resources/Imagens/Banner4.png"}
            };
            MainPageCarouselView.ItemsSource = Itens;

            StartCarouselTimer();
        }

        protected async override void OnAppearing()
        {
            gatos.Clear();
            cao.Clear();
            var allAnimais = App.DbAnimal.GetAllAnimal().Result;
            foreach (Animal i in allAnimais)
            {
                if(i.EstadoAdocao == "EmEspera")
                {
                    if (i.Tipo == "gato")
                    {
                        gatos.Add(i);
                    }
                    else if (i.Tipo == "cao")
                    {
                        cao.Add(i);
                    }
                }
            }
        }


        private void StartCarouselTimer()
        {

            //System.Threading.Timer.ActiveCount

            Application.Current.Dispatcher.StartTimer(TimeSpan.FromSeconds(5), () =>
            {
                // Altera para o próximo item no CarouselView
                _currentIndex = (_currentIndex + 1) % 4;
                MainPageCarouselView.Position = _currentIndex;

                // Retorna true para continuar o timer, false para parar
                return true;
            });

            //BindableObject.Dispatcher.StartTimer()

            //var timer = Application.Current.Dispatcher.CreateTimer();
            //timer.Interval = TimeSpan.FromSeconds(1);
            //timer.Tick += (s, e) => DoSomething();
            //timer.Start();
        }

        private async void MainPage_EscolherCachorro(object sender, EventArgs e)
        {
            try
            {
                string cachorro = "cao";
                App.Troca_Telas.TipoAnimal_TrocaTela(cachorro);
                await Navigation.PushAsync(new EscolherAnimal());
            }
            catch(Exception ex)
            {
                await DisplayAlert("ops!", ex.Message, "OK");
            }
        }

        private async void MainPage_EscolherGato(object sender, EventArgs e)
        {
            string gato = "gato";
            App.Troca_Telas.TipoAnimal_TrocaTela(gato);
            await Navigation.PushAsync(new EscolherAnimal());
        }

        private async void MainPage_ComprasPet(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ComprasPet());
        }

        private void lst_Cao_MainPage_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Animal animal_selecionado = e.SelectedItem as Animal;

            Console.WriteLine("Sexo: " + animal_selecionado.Genero);

            Navigation.PushAsync(new Views.TelaAnimal
            {
                BindingContext = animal_selecionado,
            });
        }

        private async void ContentPage_Loaded(object sender, EventArgs e)
        {
            Pessoa a = new Pessoa()
            {
                Nome = "Arthur",
                Email = "Arthur@",
                Senha = "1234",
                IsADM = true,
                IsAbrigo = true,
            };
            await App.DbPessoa.InsertPessoa(a);
        }
    }
}
