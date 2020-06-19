using System;
using System.Threading;

namespace MyTimer
{
    public class MyTimer
    {
        public MyTimer(string name, int seconds)
        {
            if (seconds < 0)
                throw new ArgumentOutOfRangeException(nameof(seconds),
                    "The value of the variable must not be negative.");
            Name = name;
            Seconds = seconds;
            RemainingSeconds = 0;
            IsBusy = false;
        }

        public bool IsBusy { get; private set; }

        public string Name { get; }
        public int Seconds { get; }
        public int RemainingSeconds { get; private set; }

        public event Action<MyTimer> TimerStarted;
        public event Action<MyTimer> TimerFinished;
        public event Action<MyTimer> TimerTick;

        public void Start()
        {
            if (IsBusy)
                throw new InvalidOperationException("Unable to start timer: it is already running");
            IsBusy = true;
            RemainingSeconds = Seconds;
            TimerStarted?.Invoke(this);
            for (var i = 0; i < Seconds; i++)
            {
                RemainingSeconds = Seconds - i - 1;
                Thread.Sleep(1000);
                TimerTick?.Invoke(this);
            }

            TimerFinished?.Invoke(this);
            IsBusy = false;
        }
    }
}