﻿using System;
using System.Threading.Tasks;
using System.Windows;
using MainProgram.Utility;
using MyTimer;
using MyTimer.Notifiers;

namespace MainProgram.ViewModels
{
    internal class Task_08ViewModel : BaseViewModel
    {
        public Task_08ViewModel()
        {
            CalculateCommand = new BasicCommand(Calculate);
            ClearOutputCommand = new BasicCommand(obj =>
            {
                Output = string.Empty;
                OnPropertyChanged(nameof(Output));
            });
        }

        public string Output { get; set; } = string.Empty;

        public int TimerSeconds { get; set; } = 2;

        public BasicCommand CalculateCommand { get; set; }
        public BasicCommand ClearOutputCommand { get; set; }

        private void OutputWriteLine(string str)
        {
            lock (Output)
            {
                Output += $"[{DateTime.Now.ToString("hh:mm:ss")}] {str}\n";
                OnPropertyChanged(nameof(Output));
            }
        }

        public void Calculate(object obj)
        {
            try
            {
                ExecuteTimer();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private async void ExecuteTimer()
        {
            TimerStarted timerStarted = (name, seconds) => OutputWriteLine($"'{name}' started for {seconds} seconds.");
            Action<string, int> timerFinished = (name, seconds) => OutputWriteLine($"'{name}' finished.");

            ICutDownNotifier[] notifiers =
            {
                new NotifierByDelegate(timerStarted, timerFinished),
                new NotifierByLambda(timerStarted, timerFinished),
                new NotifierByMethod(timerStarted, timerFinished)
            };

            notifiers[0].Init(new MyTimer.MyTimer("Чтение задания", TimerSeconds));
            notifiers[1].Init(new MyTimer.MyTimer("Выполнение задания", TimerSeconds));
            notifiers[2].Init(new MyTimer.MyTimer("Проверка задания перед отправкой", TimerSeconds));

            foreach (var notifier in notifiers)
                await Task.Run(() => notifier.Run());
        }
    }
}