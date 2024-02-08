using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voice_Manager.ViewModels
{
    public abstract class MessageBase
    {
        public MessageBase(string text)
        {
            Text = text;
        }
        public virtual string Text { get; protected set; }
        public string Time
        {
            get { return DateTime.Now.ToString("HH:mm:tt"); }
            private set { }
        }
    }
}
