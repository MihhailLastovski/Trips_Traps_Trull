using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Trips_Traps_Trull
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TicTacToe();
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
