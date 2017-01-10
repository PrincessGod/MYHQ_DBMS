using MYHQ_DBMS.ViewModel;

namespace MYHQ_DBMS.Model
{
    public class OperationHistory : ViewModelBase
    {
        private string name;
        private string operation;

        private string operationTime;

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