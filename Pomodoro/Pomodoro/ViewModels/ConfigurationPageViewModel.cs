using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pomodoro.ViewModels
{
    public class ConfigurationPageViewModel : NotificationObject
    {
        private ObservableCollection<int> pomodoroDurations;

        public ObservableCollection<int> PomodoroDurations
        {
            get { return pomodoroDurations; }
            set { pomodoroDurations = value; OnPropertyChanged(); }
        }

        private ObservableCollection<int> breakDurations;

        public ObservableCollection<int> BreakDurations
        {
            get { return breakDurations; }
            set { breakDurations = value; OnPropertyChanged(); }
        }

        private int selectedpomodoroduration;

        public int SelectedPomodoroDuration
        {
            get { return selectedpomodoroduration; }
            set { selectedpomodoroduration = value; OnPropertyChanged(); }
        }

        private int selectedBreakDuration;

        public int SelectedBreakDuration
        {
            get { return selectedBreakDuration; }
            set { selectedBreakDuration = value; OnPropertyChanged(); }
        }

        public ICommand SaveCommand { get; set; }

        public ConfigurationPageViewModel()
        {
            LoadPomodoroDurations();
            LoadBreakDurations();
            SaveCommand = new Command(SaveCommandExecute);
        }

        private void LoadBreakDurations()
        {
            PomodoroDurations = new ObservableCollection<int>
            {
                1,
                5,
                10,
                25
            };
        }

        private void LoadPomodoroDurations()
        {
            BreakDurations = new ObservableCollection<int>
            {
                1,
                5,
                10,
                25
            };
        }

        private async void SaveCommandExecute()
        {
            Application.Current.Properties["PomodoroDuration"] = SelectedPomodoroDuration;
            Application.Current.Properties["BreakDuration"] = SelectedBreakDuration;

            await Application.Current.SavePropertiesAsync();
        }
    }
}