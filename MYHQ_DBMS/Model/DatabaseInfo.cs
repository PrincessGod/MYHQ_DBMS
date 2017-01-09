using MYHQ_DBMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYHQ_DBMS.Model
{
    public class DatabaseInfo : ViewModelBase
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
    }
}
