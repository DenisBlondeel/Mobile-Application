using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Commands;
using Cells;

namespace ProjectMobileApp.ViewModel
{
    public class AddPaymentCommand : CellCommand
    {

        private PaymentViewModel pvm;
        public AddPaymentCommand(PaymentViewModel pvm, Cell<bool> isEnabled) : base(isEnabled)
        {
            this.pvm = pvm;
        }

        public override void Execute(object parameter)
        {
            Console.WriteLine("saving payment");
            pvm.SavePayment();
        }
    }
}
