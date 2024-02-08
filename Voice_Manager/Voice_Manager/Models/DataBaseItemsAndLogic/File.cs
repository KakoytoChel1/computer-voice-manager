using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voice_Manager.Models.DataBaseItemsAndLogic
{
    public class File : INotifyPropertyChanged
    {
        public int Id { get; set; }

        private string _pathToFile;
        public string PathToFile
        {
            get { return _pathToFile; }
            set { _pathToFile = value; OnPropertyChanged("PathToFile"); }
        }
        private string _commandForFile;
        public string CommandForFile
        {
            get { return _commandForFile; }
            set { _commandForFile = value; OnPropertyChanged("CommandForFile"); }
        }

        public void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
