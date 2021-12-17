using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace EO_S20_TestSamples.ViewModels
{
    class TestResultViewModel : BindableBase, IDialogAware
    {
        private string title = "Test Result";
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            throw new NotImplementedException();
        }

        public void OnDialogClosed()
        {
            throw new NotImplementedException();
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
