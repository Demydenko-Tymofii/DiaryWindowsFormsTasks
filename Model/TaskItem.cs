using System;
using System.ComponentModel;

namespace WindowsFormsTasks.Model
{
    public class TaskItem : INotifyPropertyChanged
    {
        public int Id { get; set; }

        string _Name;
        public string Name
        {
            get { return _Name; }
            set 
            {
                if (_Name != value)
                {
                    _Name = value;

                    OnPropertyChanged(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }

        public string Desc { get; set; }
        public DateTime Alert { get; set; }
        public DateTime Created { get; set; }

        public string NameFull 
        {
            get { return $"[{Created:dd-MM-yyyy HH:mm}] {Name}";  }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(object sender, PropertyChangedEventArgs e) 
        {
            if(PropertyChanged != null)
                PropertyChanged(sender, e);
        }
    }
}
