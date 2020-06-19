using System;

namespace MyTimer
{
    public delegate void TaskStarted(string name, int seconds);

    public class NotifierByDelegate : ICutDownNotifier
    {
        private readonly Action<string, int> timerFinishedDelegate;

        private readonly TaskStarted timerStartedDelegate;
        private MyTimer timer;

        public Action<string, int> TimerTickDelegate;

        public NotifierByDelegate(TaskStarted timerStarted, Action<string, int> timerFinished)
        {
            timerStartedDelegate = timerStarted;
            timerFinishedDelegate = timerFinished;
        }

        public void Init(MyTimer myTimer)
        {
            timer = myTimer;
            timer.TimerStarted += delegate(MyTimer argTimer)
            {
                timerStartedDelegate?.Invoke(argTimer.Name, argTimer.Seconds);
            };
            timer.TimerFinished += delegate(MyTimer argTimer)
            {
                timerFinishedDelegate?.Invoke(argTimer.Name, argTimer.Seconds);
            };
            timer.TimerTick += delegate(MyTimer argTimer)
            {
                TimerTickDelegate?.Invoke(argTimer.Name, argTimer.Seconds);
            };
        }

        public void Run()
        {
            timer?.Start();
        }
    }
}