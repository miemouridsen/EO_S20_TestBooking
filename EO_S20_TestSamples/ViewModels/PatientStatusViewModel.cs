using EO_S20_TestSamples.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace EO_S20_TestSamples.ViewModels
{
    class PatientStatusViewModel : BindableBase, IDialogAware
    {
        private string _title = "Patient Status";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private PatientTest _patient;
        public PatientTest Patient
        {
            get { return _patient; }
            set { SetProperty(ref _patient, value); }
        }

        private DelegateCommand<string> _closeDialogCommand;
        public DelegateCommand<string> CloseDialogCommand =>
            _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand<string>(ExecuteCloseDialogCommand));

        void ExecuteCloseDialogCommand(string parameter)
        {
            ButtonResult result = ButtonResult.None;

            if (parameter == "true")
            {
                result = ButtonResult.OK;
                ((App)App.Current).PatientTest = Patient;
            }
            else if (parameter == "false")
            {
                result = ButtonResult.Cancel;
            }

            RaiseRequestClose(new DialogResult(result));
        }

        private void RaiseRequestClose(DialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog() => true;

        public void OnDialogClosed() { }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Patient = ((App)App.Current).PatientTest;
        }

        private DelegateCommand _testedCommand;
        public DelegateCommand TestedCommand =>
            _testedCommand ?? (_testedCommand = new DelegateCommand(ExecuteTestedCommand));

        void ExecuteTestedCommand()
        {
            Patient.Status = "Tested";
            Patient.TestDate = DateTime.Now;
            Patient.Guid = Guid.NewGuid();
        }

        private DelegateCommand _notTestedCommand;
        public DelegateCommand NotTestedCommand =>
            _notTestedCommand ?? (_notTestedCommand = new DelegateCommand(ExecuteNotTestedCommand));

        void ExecuteNotTestedCommand()
        {
            Patient.Status = "Didn't show up";
        }
    }
}
