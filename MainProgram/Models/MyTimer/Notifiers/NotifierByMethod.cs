using System;

namespace MyTimer.Notifiers
{
    public class NotifierByMethod : Notifier
    {
        /// <summary>
        ///     Creates an event handler with the specified <see langword="delegates" />
        /// </summary>
        /// <param name="timerStarted">A delegate representing a method to be executed when timer will start.</param>
        /// <param name="timerFinished">A delegate representing a method to be executed when timer will be finished.</param>
        public NotifierByMethod(TimerStarted timerStarted, Action<string, int> timerFinished) : base(timerStarted,
            timerFinished)
        {
        }

        public override void Init(MyTimer myTimer)
        {
            timer = myTimer;
            timer.TimerStarted += OnTimerStarted;
            timer.TimerFinished += OnTimerFinished;
            timer.TimerTick += OnTimerTick;
        }

        private void OnTimerStarted(MyTimer myTimer)
        {
            timerStartedDelegate?.Invoke(myTimer.Name, myTimer.Seconds);
        }

        private void OnTimerFinished(MyTimer myTimer)
        {
            timerFinishedDelegate?.Invoke(myTimer.Name, myTimer.Seconds);
        }

        private void OnTimerTick(MyTimer myTimer)
        {
            TimerTickDelegate?.Invoke(myTimer.Name, myTimer.Seconds);
        }
    }
}