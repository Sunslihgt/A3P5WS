using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using WPFTaskManager.Models;

namespace WPFTaskManager.ViewModels
{
    public class TaskItemViewModel : INotifyPropertyChanged
    {
        private string _name;
        private int _pid;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public int Pid
        {
            get => _pid;
            set
            {
                _pid = value;
                OnPropertyChanged();
            }
        }

        public TaskItemViewModel(TaskItem item)
        {
            _name = item.Name ?? "";
            _pid = item.Pid ?? -1;
        }

        public TaskItemViewModel(Process process)
        {
            _name = process.ProcessName;
            _pid = process.Id;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
