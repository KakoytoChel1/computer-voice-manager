using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voice_Manager.Models.DataBaseItemsAndLogic
{
    public class Control : INotifyPropertyChanged
    {
        public int Id { get; set; }

        private int _relayNumber;

        public int RelayNumber
        {
            get { return _relayNumber; }
            set { _relayNumber = value; OnPropertyChanged("RelayNumber"); }
        }

        private string _onCommand;

        public string OnCommand
        {
            get { return _onCommand; }
            set { _onCommand = value; OnPropertyChanged("OnCommand"); }
        }

        private string _offCommand;

        public string OffCommand
        {
            get { return _offCommand; }
            set { _offCommand = value; OnPropertyChanged("OffCommand"); }
        }



        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
