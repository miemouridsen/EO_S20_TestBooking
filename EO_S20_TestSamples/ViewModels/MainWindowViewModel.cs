using EO_S20_TestSamples.Views;
using Prism.Commands;
using Prism.Mvvm;

namespace EO_S20_TestSamples.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Test Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }

        private DelegateCommand _testCenterCommand;
        public DelegateCommand TestCenterCommand =>
            _testCenterCommand ?? (_testCenterCommand = new DelegateCommand(ExecuteTestCenterCommand));

        void ExecuteTestCenterCommand()
        {
            //Create view
            TestCenter testCenterInstance = new TestCenter();
            //Show view
            testCenterInstance.Show();
            //Close current view
            App.Current.Windows[0].Close();
        }

        private DelegateCommand _labCommand;
        public DelegateCommand LabCommand =>
            _labCommand ?? (_labCommand = new DelegateCommand(ExecuteLabCommand));

        void ExecuteLabCommand()
        {
            //Create view
            Lab labInstance = new Lab();
            //Show view
            labInstance.Show();
            //Close current view
            App.Current.Windows[0].Close();
        }
    }
}
