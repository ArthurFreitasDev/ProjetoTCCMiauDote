
namespace ProjetoTCCMiauDote
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            /*Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handle, view) =>
            {
                #if __ANDROID__
                        handle.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
                #endif
            });*/
        }
    }
}
