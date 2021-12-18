using EO_S20_TestSamples.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace EO_S20_TestSamples.ViewModels
{
    class TestResultViewModel : BindableBase, IDialogAware
    {
        private string _title = "Test Result";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private PatientTest _test;
        public PatientTest Test
        {
            get { return _test; }
            set { SetProperty(ref _test, value); }
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
                ((App)App.Current).PatientTest = Test;
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
            Test = ((App)App.Current).PatientTest;
        }


        private DelegateCommand _positiveCommand;
        public DelegateCommand PositiveCommand =>
            _positiveCommand ?? (_positiveCommand = new DelegateCommand(ExecutePositiveCommandCommand));

        void ExecutePositiveCommandCommand()
        {
            Test.Result = "Positive";
            Test.ResultDate = DateTime.Now;
        }

        private DelegateCommand _negativeCommand;
        public DelegateCommand NegativeCommand =>
            _negativeCommand ?? (_negativeCommand = new DelegateCommand(ExecuteNegativeCommand));

        void ExecuteNegativeCommand()
        {
            Test.Result = "Negative";
            Test.ResultDate = DateTime.Now;
        }

        private DelegateCommand _invalidCommand;
        public DelegateCommand InvalidCommand =>
            _invalidCommand ?? (_invalidCommand = new DelegateCommand(ExecuteInvalidCommand));

        void ExecuteInvalidCommand()
        {
            Test.Result = "Invalid";
            Test.ResultDate = DateTime.Now;
        }
    }
}
