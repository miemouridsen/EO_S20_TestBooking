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
    class TestCenterViewModel : BindableBase
    {
        private string _title = "Test Application - Test Center";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private DialogService _dialogService;

        public TestCenterViewModel(DialogService dialogService)
        {
            _dialogService = dialogService;
        }

        private int _currentIndex;
        public int CurrentIndex
        {
            get { return _currentIndex; }
            set { SetProperty(ref _currentIndex, value); }
        }

        private ObservableCollection<PatientTest> _patients;
        public ObservableCollection<PatientTest> Patients
        {
            get { return _patients; }
            set { SetProperty(ref _patients, value); }
        }

        private string filename = "";
        public string Filename
        {
            get { return filename; }
            set { SetProperty(ref filename, value); }
        }

        private DelegateCommand _loadPatientsCommand;
        public DelegateCommand LoadPatientsCommand =>
            _loadPatientsCommand ?? (_loadPatientsCommand = new DelegateCommand(ExecuteLoadPatientsCommand));

        void ExecuteLoadPatientsCommand()
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
                Patients = JsonConvert.DeserializeObject<ObservableCollection<PatientTest>>(jsonString);
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
                serializer.Serialize(w, Patients);
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

        private DelegateCommand _setPatientStatus;
        public DelegateCommand SetPatientStatusCommand =>
            _setPatientStatus ?? (_setPatientStatus = new DelegateCommand(ExecuteSetPatientStatusCommand));

        void ExecuteSetPatientStatusCommand()
        {
            PatientTest patient = Patients[CurrentIndex];
            ((App)App.Current).PatientTest = patient;
            _dialogService.ShowDialog("PatientStatus", null, r =>
            {
                if (r.Result == ButtonResult.OK)
                {
                    Title = "Patient status changed";
                }
                else
                {
                    Title = "Something went wrong";
                }
            });
        }
    }
}
