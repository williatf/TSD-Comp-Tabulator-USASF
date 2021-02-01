using Caliburn.Micro;
using Squirrel;
using System.Threading.Tasks;
using System.Windows;
using TSD_Comp_Tabulator.ViewModels;

namespace TSD_Comp_Tabulator
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
            using (var manager = new UpdateManager(@"http://tttkjk.com/TSDTabulator/Releases"))
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
