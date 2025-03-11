using DemoApiCalls.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DemoApiCalls
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static AppDataContext _dataContext;
        public App()
        {
            //KeepAwake.SetAlwaysAwake(true);
        }

        public static AppDataContext DataContext
        {
            get => _dataContext ??= new AppDataContext();
            private set => _dataContext = value;
        }
    }
}
