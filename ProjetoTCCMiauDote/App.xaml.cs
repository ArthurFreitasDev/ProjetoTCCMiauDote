namespace ProjetoTCCMiauDote
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handle, view) =>
            {
                #if __ANDROID__
                        handle.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
                #endif
            });
        }
        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);

            const int newWidth = 460;
            const int newHeight = 820;

            window.Width = newWidth;
            window.Height = newHeight;

            return window;
        }
    }
}
