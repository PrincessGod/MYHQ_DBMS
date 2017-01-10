using MYHQ_DBMS.ViewModel;

namespace MYHQ_DBMS.Model
{
    public class UserInfo : ViewModelBase
    {
        private string department;
        private string name;
        private string passward;
        private string permission;
        private string post;
        private string userName;

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

        public string Department
        {
            get { return department; }
            set
            {
                if (department != null && department == value) return;
                department = value;
                OnPropertyChanged("Department");
            }
        }

        public string Post
        {
            get { return post; }
            set
            {
                if (post != null && post == value) return;
                post = value;
                OnPropertyChanged("Post");
            }
        }

        public string UserName
        {
            get { return userName; }
            set
            {
                if (userName != null && userName == value) return;
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        public string Passward
        {
            get { return passward; }
            set
            {
                if (passward != null && passward == value) return;
                passward = value;
                OnPropertyChanged("Passward");
            }
        }

        public string Permission
        {
            get { return permission; }
            set
            {
                if (permission != null && permission == value) return;
                permission = value;
                OnPropertyChanged("Permission");
            }
        }
    }
}