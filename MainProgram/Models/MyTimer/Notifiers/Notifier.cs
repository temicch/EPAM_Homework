using System;

namespace MyTimer
{
    public abstract class Notifier : ICutDownNotifier
    {
        protected readonly Action<string, int> timerFinishedDelegate;

        protected readonly TimerStarted timerStartedDelegate;
        protected MyTimer timer;

        /// <summary>
        ///     The delegate representing the method that will be called at each tick of the <see langword="timer" />
        /// </summary>
        public Action<string, int> TimerTickDelegate;

        protected Notifier(TimerStarted timerStarted, Action<string, int> timerFinished)
        {
            timerStartedDelegate = timerStarted;
            timerFinishedDelegate = timerFinished;
        }

        public abstract void Init(MyTimer myTimer);

        public virtual void Run()
        {
            timer?.Start();
        }
    }
}