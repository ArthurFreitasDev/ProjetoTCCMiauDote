
using ProjetoTCCMiauDote.Classes;
using ProjetoTCCMiauDote.Helpers;

namespace ProjetoTCCMiauDote
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

        }
        static HelpersAnimal _dbAnimal;
        public static HelpersAnimal DbAnimal
        {
            get
            {
                if (_dbAnimal == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
                        "banco_sqlite_animal.db3");
                    _dbAnimal = new HelpersAnimal(path);
                }
                return _dbAnimal;
            }
        }
        static HelpersPessoa _dbPessoa;
        public static HelpersPessoa DbPessoa
        {
            get
            {
                if(_dbPessoa == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "banco_sqlite_pessoa.db3");
                    _dbPessoa = new HelpersPessoa(path);
                }
                return _dbPessoa;
            }
        }



        static HelpersRegistros _dbRegistros;
        public static HelpersRegistros DbRegistros
        {
            get
            {
                if(_dbRegistros == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "banco_sqlite_registros.db3");
                    _dbRegistros = new HelpersRegistros(path);
                }
                return _dbRegistros;
            }
        }

        public static UserLogin User_Login = new UserLogin();
        public static ControleTrocadeTelas Troca_Telas = new ControleTrocadeTelas();
        public static AnimalSelecionado AnimalSelecionado = new AnimalSelecionado();
    }
}
