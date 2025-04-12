using ProjetoTCCMiauDote.Classes;
using ProjetoTCCMiauDote.Models;

namespace ProjetoTCCMiauDote
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            TelaAdministrador.FlyoutItemIsVisible = true;
            FlyoutLogout.FlyoutItemIsVisible = false;
        }

        private async void Shell_Loaded(object sender, EventArgs e)
        {
            while(1 == 1)
            {
                string ValidacaoLogin = App.User_Login.GetLogin();
                var allpessoas = await App.DbPessoa.GetAllPessoas();
                foreach (Pessoa i in allpessoas)
                {
                    if(i.idPessoa.ToString() == ValidacaoLogin & i.IsADM == true)
                    {
                        TelaAdministrador.FlyoutItemIsVisible = true;
                        FlyoutLogin.FlyoutItemIsVisible = false;
                        FlyoutCadastro.FlyoutItemIsVisible = false;
                        FlyoutLogout.FlyoutItemIsVisible = true;
                    }
                    else if(i.idPessoa.ToString() == ValidacaoLogin & i.IsADM == false)
                    {
                        TelaAdministrador.FlyoutItemIsVisible = false;
                        FlyoutLogin.FlyoutItemIsVisible = false;
                        FlyoutCadastro.FlyoutItemIsVisible = false;
                        FlyoutLogout.FlyoutItemIsVisible = true;
                    }
                    else if(ValidacaoLogin == null)
                    {
                        TelaAdministrador.FlyoutItemIsVisible = false;
                        FlyoutLogin.FlyoutItemIsVisible = true;
                        FlyoutCadastro.FlyoutItemIsVisible = true;
                        FlyoutLogout.FlyoutItemIsVisible = false;
                    }
                }
            }
        }
    }
}
