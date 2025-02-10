using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace AvaloniaTaskManager.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        ObservableCollection<TaskItemViewModel> Tasks { get; } = new ObservableCollection<TaskItemViewModel>();

        [RelayCommand]
        private void DisplayTasks()
        {
            Tasks.Clear();
            foreach (var process in Process.GetProcesses())
            {
                Tasks.Add(new TaskItemViewModel(process));
            }
        }
    }
}
