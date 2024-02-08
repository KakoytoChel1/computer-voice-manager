using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voice_Manager.Models.DataBaseItemsAndLogic
{
    public class Answer : INotifyPropertyChanged
    {
        public int Id { get; set; }

        private string _answer;
        public string AssistantAnswer
        {
            get { return _answer; }
            set { _answer = value; OnPropertyChanged("AssistantAnswer"); }
        }

        private string _answerCommand;
        public string AnswerCommand
        {
            get { return _answerCommand; }
            set { _answerCommand = value; OnPropertyChanged("AnswerCommand"); }
        }

        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
