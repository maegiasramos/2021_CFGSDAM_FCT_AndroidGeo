using TareasXamarin.Services;
using Xamarin.Forms;

namespace TareasXamarin
{
    public partial class App : Application
    {
        // Objeto que referencie a la base de datos
        static DatabaseCrud userDatabase;

        public App()
        {
            InitializeComponent();
            DependencyService.Register<MockDataStore>();
            // Asociamos la página principal en la que arrancará la app
            MainPage = new NavigationPage(new Views.LoginPage());
        }

        // Conexión con base de datos al inicializar app
        public static DatabaseCrud UserDatabase
        {
            get
            {
                if(userDatabase == null)
                {
                    userDatabase = new DatabaseCrud(DependencyService.Get<ILocalFileHelper>().GetLocalFilePath("Database.db3"));
                }
                return userDatabase;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
