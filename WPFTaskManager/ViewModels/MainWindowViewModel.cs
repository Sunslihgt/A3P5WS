using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using WPFTaskManager.Models;

namespace WPFTaskManager.ViewModels
{
    public class MainWindowViewModel
    {
        public ObservableCollection<TaskItemViewModel> Tasks { get; } = new();

        public ICommand DisplayTasksCommand { get; }

        public MainWindowViewModel()
        {
            DisplayTasksCommand = new RelayCommand(DisplayTasks);
            Tasks.Add(new TaskItemViewModel(new TaskItem
            {
                Name = "Test Task",
                Pid = 1234
            }));
        }

        private void DisplayTasks()
        {
            Tasks.Clear();
            foreach (var process in Process.GetProcesses())
            {
                Tasks.Add(new TaskItemViewModel(process));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
