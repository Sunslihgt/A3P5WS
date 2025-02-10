using System.Collections.ObjectModel;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AvaloniaTaskManager.Models;
using System.Diagnostics;
using System;

namespace AvaloniaTaskManager.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<TaskItemViewModel> Tasks { get; } = new ObservableCollection<TaskItemViewModel>();

        public MainWindowViewModel()
        {
            Tasks.Add(new TaskItemViewModel(new Models.TaskItem()
            {
                Name = "Test",
                Pid = 1234
            }));

            DisplayTasks();
        }

        [RelayCommand]
        public void DisplayTasks()
        {
            Tasks.Clear();
            foreach (var process in Process.GetProcesses())
            {
                Tasks.Add(new TaskItemViewModel(process));
            }
            //Console.WriteLine("Displaying tasks");
            //Console.WriteLine(Tasks);
        }
    }
}
