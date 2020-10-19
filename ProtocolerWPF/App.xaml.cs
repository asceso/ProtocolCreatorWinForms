﻿using ProtocolerWPF.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace ProtocolerWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}