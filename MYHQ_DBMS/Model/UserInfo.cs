using MYHQ_DBMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYHQ_DBMS.Model
{
     public class UserInfo : ViewModelBase
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
         private string department;
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
         private string post;
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
         private string userName;
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
         private string passward;
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
         private string permission;
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
