using EO_S20_TestSamples.Models;
using EO_S20_TestSamples.Views;
using Microsoft.Win32;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace EO_S20_TestSamples.ViewModels
{
    class LabViewModel : BindableBase
    {
        private string _title = "Test Application - Laboratory";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private DialogService _dialogService;

        public LabViewModel(DialogService dialogService)
        {
            this._dialogService = dialogService;
        }

        private int _currentIndex;
        public int CurrentIndex
        {
            get { return _currentIndex; }
            set { SetProperty(ref _currentIndex, value); }
        }

        private ObservableCollection<PatientTest> _tests;
        public ObservableCollection<PatientTest> Tests
        {
            get { return _tests; }
            set { SetProperty(ref _tests, value); }
        }

        private string filename = "";
        public string Filename
        {
            get { return filename; }
            set { SetProperty(ref filename, value); }
        }

        private DelegateCommand _loadTestsCommand;
        public DelegateCommand LoadTestsCommand =>
            _loadTestsCommand ?? (_loadTestsCommand = new DelegateCommand(ExecuteLoadTestsCommand));

        void ExecuteLoadTestsCommand()
        {
            var openDialog = new OpenFileDialog
            {
                Filter = "Json files (*.json)|*.json|Text files (*.txt)|*.txt",
            };
            if (openDialog.ShowDialog(App.Current.MainWindow) == true)
            {
                Filename = openDialog.FileName;
                StreamReader r = new StreamReader(openDialog.FileName);
                string jsonString = r.ReadToEnd();
                Tests = JsonConvert.DeserializeObject<ObservableCollection<PatientTest>>(jsonString);
            }
        }

        private DelegateCommand _saveCommand;
        public DelegateCommand SaveCommand =>
            _saveCommand ?? (_saveCommand = new DelegateCommand(ExecuteSaveCommand));

        void ExecuteSaveCommand()
        {
            var saveDialog = new SaveFileDialog
            {
                Filter = "Json files (*.json)|*.json|Text files (*.txt)|*.txt",
            };
            if (saveDialog.ShowDialog(App.Current.MainWindow) == true)
            {
                Filename = saveDialog.FileName;
                StreamWriter w = new StreamWriter(Filename);
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(w, Tests);
                w.Close();
            }
        }

        private DelegateCommand _homePageCommand;
        public DelegateCommand HomePageCommand =>
            _homePageCommand ?? (_homePageCommand = new DelegateCommand(ExecuteHomePageCommand));

        void ExecuteHomePageCommand()
        {
            MainWindow mainWindowsInstance = new MainWindow();
            mainWindowsInstance.Show();
            App.Current.Windows[0].Close();
        }

        private DelegateCommand _setTestResult;
        public DelegateCommand SetTestResultCommand =>
            _setTestResult ?? (_setTestResult = new DelegateCommand(ExecuteSetTestResultCommand));

        void ExecuteSetTestResultCommand()
        {
            PatientTest pt = Tests[CurrentIndex];
            ((App)App.Current).PatientTest = pt;
            _dialogService.Show("TestResult", null, r =>
            {
                if (r.Result == ButtonResult.OK)
                {
                    Title = "Test result submitted";
                }
                else
                {
                    Title = "Something went wrong";
                }
            });
        }
    }
}
