using System;

namespace MyTimer
{
    public class NotifierByLambda : ICutDownNotifier
    {
        private readonly Action<string, int> timerFinishedDelegate;

        private readonly TaskStarted timerStartedDelegate;
        private MyTimer timer;

        public Action<string, int> TimerTickDelegate;

        public NotifierByLambda(TaskStarted timerStarted, Action<string, int> timerFinished)
        {
            timerStartedDelegate = timerStarted;
            timerFinishedDelegate = timerFinished;
        }

        public void Init(MyTimer myTimer)
        {
            timer = myTimer;
            timer.TimerStarted += argTimer => timerStartedDelegate?.Invoke(argTimer.Name, argTimer.Seconds);
            timer.TimerFinished += argTimer => timerFinishedDelegate?.Invoke(argTimer.Name, argTimer.Seconds);
            timer.TimerTick += argTimer => TimerTickDelegate?.Invoke(argTimer.Name, argTimer.Seconds);
        }

        public void Run()
        {
            timer?.Start();
        }
    }
}