using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voice_Manager.Models.DataBaseItemsAndLogic
{
    public class Site : INotifyPropertyChanged
    {
        public int Id { get; set; }

        private string _urlOfSite;
        public string UrlOfSite
        {
            get { return _urlOfSite; }
            set { _urlOfSite = value; OnPropertyChanged("UrlOfSite"); }
        }
        private string _commandForSite;
        public string CommandForSite
        {
            get { return _commandForSite; }
            set { _commandForSite = value; OnPropertyChanged("CommandForSite"); }
        }

        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
