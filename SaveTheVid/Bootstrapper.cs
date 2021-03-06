﻿using Caliburn.Micro;
using SaveTheVid.ViewModels;
using System.Windows;

namespace SaveTheVid
{
    class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }
    }
}
