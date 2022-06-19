using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Veevo.DSK.Pages;
using Veevo.Kernel.API;

namespace Veevo.DSK
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            VeevoAPI.Initialize();
        }
    }
}
