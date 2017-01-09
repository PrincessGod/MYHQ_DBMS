using MYHQ_DBMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYHQ_DBMS.Model
{
    public class OperationHistory : ViewModelBase
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (name != null && name == value) return;
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private string operationTime;
        public string OperationTime
        {
            get { return operationTime; }
            set
            {
                if (operationTime != null && operationTime == value) return;
                operationTime = value;
                OnPropertyChanged("OperationTime");
            }
        }
        private string operation;
        public string Operation
        {
            get { return operation; }
            set
            {
                if (operation != null && operation == value) return;
                operation = value;
                OnPropertyChanged("Operation");
            }
        }

    }
}
