using EO_S20_TestSamples.ViewModels;
using EO_S20_TestSamples.Views;
using Prism.Ioc;
using System.Windows;

namespace EO_S20_TestSamples
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
            containerRegistry.RegisterDialog<PatientStatus, PatientStatusViewModel>();
            containerRegistry.RegisterDialog<TestResult, TestResultViewModel>();
        }
    }
}
