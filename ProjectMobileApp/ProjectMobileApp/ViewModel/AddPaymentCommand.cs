using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ProjectMobileApp.ViewModel
{
    public class AddPaymentCommand : ICommand
    {
        private PaymentViewModel pvm;
        public AddPaymentCommand(PaymentViewModel pvm)
        {
            this.pvm = pvm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true; // String.IsNullOrEmpty("" + pvm.CategoryError + pvm.AmountError + pvm.DateError + pvm.NameError);
        }

        public void Execute(object parameter)
        {
            //pvm.Service.AddPayment(pvm.CurrentPayment);
        }
    }
}
