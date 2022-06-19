using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Veevo.DSK.ViewModels;

namespace Veevo.DSK.Extensions
{
    public static class ApplicationExtension
    {
        private static Dictionary<string, Page>? Pages { get; set; }
        public static void CreatePagesDictionary(this LoginViewModel application)
        {
            Pages = new Dictionary<string, Page>();
            
        }
    }
}
