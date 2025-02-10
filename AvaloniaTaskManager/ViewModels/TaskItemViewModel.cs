using AvaloniaTaskManager.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaTaskManager.ViewModels
{
    public partial class TaskItemViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string? _name;
        [ObservableProperty]
        private int? _pid;

        public TaskItemViewModel(TaskItem item)
        {
            // Init the properties with the given values
            Name = item.Name;
            Pid = item.Pid;
        }

        public TaskItemViewModel(Process process)
        {
            // Init the properties with the given values
            Name = process.ProcessName;
            Pid = process.Id;
        }
    }
}
