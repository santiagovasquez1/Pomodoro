﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pomodoro
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new RootPage();
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
