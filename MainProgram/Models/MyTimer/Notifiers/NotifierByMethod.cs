using System;

namespace MyTimer
{
    public class NotifierByMethod : ICutDownNotifier
    {
        private readonly Action<string, int> timerFinishedDelegate;

        private readonly TaskStarted timerStartedDelegate;
        private MyTimer timer;

        public Action<string, int> TimerTickDelegate;

        public NotifierByMethod(TaskStarted timerStarted, Action<string, int> timerFinished)
        {
            timerStartedDelegate = timerStarted;
            timerFinishedDelegate = timerFinished;
        }

        public void Init(MyTimer myTimer)
        {
            timer = myTimer;
            timer.TimerStarted += OnTimerStarted;
            timer.TimerFinished += OnTimerFinished;
            timer.TimerTick += OnTimerTick;
        }

        public void Run()
        {
            timer?.Start();
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