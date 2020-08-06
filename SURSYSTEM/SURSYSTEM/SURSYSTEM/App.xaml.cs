using SURSYSTEM.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SURSYSTEM
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new PersonasPage();
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
