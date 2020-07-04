using System;

namespace MyTimer.Notifiers
{
    public class NotifierByLambda : Notifier
    {
        /// <summary>
        ///     Creates an event handler with the specified <see langword="delegates" />
        /// </summary>
        /// <param name="timerStarted">A delegate representing a method to be executed when timer will start.</param>
        /// <param name="timerFinished">A delegate representing a method to be executed when timer will be finished.</param>
        public NotifierByLambda(TimerStarted timerStarted, Action<string, int> timerFinished) : base(timerStarted,
            timerFinished)
        {
        }

        public override void Init(MyTimer myTimer)
        {
            timer = myTimer;
            timer.TimerStarted += argTimer => timerStartedDelegate?.Invoke(argTimer.Name, argTimer.Seconds);
            timer.TimerFinished += argTimer => timerFinishedDelegate?.Invoke(argTimer.Name, argTimer.Seconds);
            timer.TimerTick += argTimer => TimerTickDelegate?.Invoke(argTimer.Name, argTimer.Seconds);
        }
    }
}