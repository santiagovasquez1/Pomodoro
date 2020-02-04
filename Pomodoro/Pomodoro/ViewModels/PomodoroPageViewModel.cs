using System;
using System.Timers;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pomodoro.ViewModels
{
    public class PomodoroPageViewModel : NotificationObject
    {
        private Timer timer;

        //Indica el avance del tiempo
        private TimeSpan ellapsed;

        public TimeSpan Ellapsed
        {
            get { return ellapsed; }
            set { ellapsed = value; OnPropertyChanged(); }
        }

        private bool isRunning;

        public bool IsRunning
        {
            get { return isRunning; }
            set { isRunning = value; OnPropertyChanged(); }
        }

        public ICommand StartOrPauseCommand { get; set; }

        public PomodoroPageViewModel()
        {
            InitializeTimer();
            StartOrPauseCommand = new Command(StartOrPauseCommandExecute);
        }

        private void InitializeTimer()
        {
            timer = new Timer
            {
                Interval = 1000,
            };
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //Cada vez que ocurra un segundo Ellapsed se debe de actualizar
            Ellapsed = Ellapsed.Add(TimeSpan.FromSeconds(1));
        }

        private void StartTimer()
        {
            timer.Start();
            IsRunning = true;
        }

        private void StopTimer()
        {
            timer.Stop();
            IsRunning = false;
        }

        private void StartOrPauseCommandExecute()
        {
            if (IsRunning)
                StopTimer();
            else
                StartTimer();
        }
    }
}