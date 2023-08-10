using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CevikMetalTeknik.Data;
using System.IO;
namespace CevikMetalTeknik
{
    public partial class App : Application
    {
        private static NoteDatabase db;
        public static NoteDatabase Database
        {
            get
            {
                if (db==null)
                {
                    db = new NoteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"Stokdb"));
                }
                return db;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
