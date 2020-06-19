using System;
using System.Threading;

namespace MyTimer
{
    public class MyTimer
    {
        /// <summary>
        ///     Create a <see langword="timer" /> with the specified <see langword="name" /> and <see langword="time" /> of seconds
        /// </summary>
        /// <param name="name">Timer name</param>
        /// <param name="seconds">Time in seconds</param>
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

        /// <summary>
        ///     Returns true if the <see langword="timer" /> is running
        /// </summary>
        public bool IsBusy { get; private set; }

        /// <summary>
        ///     Timer <see langword="name" />
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     The number of <see langword="seconds" /> after which the timer raises an event
        /// </summary>
        public int Seconds { get; }

        /// <summary>
        ///     The number of <see langword="seconds remaining" /> before the timer expires
        /// </summary>
        public int RemainingSeconds { get; private set; }

        /// <summary>
        ///     Occurs when the <see langword="timer" /> has just started
        /// </summary>
        public event Action<MyTimer> TimerStarted;

        /// <summary>
        ///     Occurs when the <see langword="timer" /> completes
        /// </summary>
        public event Action<MyTimer> TimerFinished;

        /// <summary>
        ///     Occurs on every tick of the <see langword="timer" />
        /// </summary>
        public event Action<MyTimer> TimerTick;

        /// <summary>
        ///     Start the <see langword="timer" />
        /// </summary>
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