using Caliburn.Micro;
using Squirrel;
using System.Threading.Tasks;
using System.Windows;
using TSD_Comp_Tabulator_USASF.ViewModels;

namespace TSD_Comp_Tabulator_USASF
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
            CheckForUpdates();
        }

        private async Task CheckForUpdates()
        {
            using (var manager = new UpdateManager(@"http://tttkjk.com/TSDTabulator-USASF/Releases"))
            {
                await manager.UpdateApp();
            }
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

    }
}
