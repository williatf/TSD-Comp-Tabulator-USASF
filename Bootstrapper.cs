using Caliburn.Micro;
using System.Windows;
using TSD_Comp_Tabulator.ViewModels;

namespace TSD_Comp_Tabulator
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

    }
}
