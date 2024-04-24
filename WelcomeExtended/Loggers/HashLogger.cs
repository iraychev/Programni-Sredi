using System.Collections.Concurrent;
using System.Text;
using Microsoft.Extensions.Logging;

namespace WelcomeExtended.Loggers
{
    internal class HashLogger : ILogger
    {
            private readonly ConcurrentDictionary<int, string> _logMessages;
            private readonly string _name;
            private readonly string _filePath = "log.txt";

        public HashLogger(string name)
        {
            _logMessages = new ConcurrentDictionary<int, string>();
            _name = name;
        }

        public void PrintAllMessages()
        {
            foreach (var logEntry in _logMessages)
            {
                Console.WriteLine($"EventId: {logEntry.Key}, Message: {logEntry.Value}");
            }
        }

        public void PrintMessage(int eventId)
        {
            if (_logMessages.TryGetValue(eventId, out var message))
            {
                Console.WriteLine($"EventId: {eventId}, Message: {message}");
            }
            else
            {
                Console.WriteLine("No message found for the given EventId.");
            }
        }

        public void DeleteMessage(int eventId)
        {
            _logMessages.TryRemove(eventId, out _);
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            var message = formatter(state, exception);

            switch (logLevel)
            {
                case LogLevel.Critical:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            Console.WriteLine(" - LOGGER - ");
            var messageToBeLogged = new StringBuilder();
            messageToBeLogged.Append($"[{logLevel}]");
            messageToBeLogged.AppendFormat(" [{0}]", _name);
            Console.WriteLine(messageToBeLogged);
            Console.WriteLine($" {formatter(state, exception)}");
            Console.WriteLine("- LOGGER -");
            Console.ResetColor();

            _logMessages[eventId.Id] = message;

            File.AppendAllText(_filePath, $"{message}\n");

        }
    }
}
