using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_do_List.Models
{
    internal class ToDoModels : INotifyPropertyChanged
    {
        public DateTime DateOfCreation { get; set; } = DateTime.Now; //field for creation date
		private bool _isDone;
		private string _task;


        public bool IsDone
		{
			get { return _isDone; }
			set
			{
				if (_isDone == value) //if the same information is received
					return;
				_isDone = value;
				OnPropertyChanged("IsDone");
			}
		}
		public string Text
		{
			get { return _task; }
			set
			{
				if(_task == value)
					return;
				_task = value;
				OnPropertyChanged("Text");
			}
		}
		//BildingList subscribes to this event to save changes 
        public event PropertyChangedEventHandler PropertyChanged;
		//this method accesses the event and calls it 
		protected virtual void OnPropertyChanged(string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

	}
}
