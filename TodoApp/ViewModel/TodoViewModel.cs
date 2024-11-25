using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TodoApp.ViewModel
{
    public class TodoViewModel :INotifyPropertyChanged
    {
        public ObservableCollection<string> todos { get; }
        private string text;
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand Add { get; }
        public ICommand Delete { get; }



        public string Text
        {
            get => text;
            set
            {
                if (text != value)
                {
                    text = value;
                    OnPropertyChanged();

                }
            }
        }
        public TodoViewModel()
        {
            todos = new ObservableCollection<string>();
            
            Add = new Command(AddTodo);
            Delete = new Command<string>(Remove);



        }



        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        }
        public void AddTodo()
        {
            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            todos.Add(Text);

            text = string.Empty;
            OnPropertyChanged(nameof(Text));
        }
        public void Remove(string todo)
        {
            todos.Remove(todo);
        }
    }
}
