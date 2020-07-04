namespace MyTimer.Notifiers
{
    public interface ICutDownNotifier
    {
        /// <summary>
        ///     Initialize the handler using the specified <see langword="timer" />
        /// </summary>
        /// <param name="myTimer">Timer</param>
        void Init(MyTimer myTimer);

        /// <summary>
        ///     Start <see langword="timer" />
        /// </summary>
        void Run();
    }
}