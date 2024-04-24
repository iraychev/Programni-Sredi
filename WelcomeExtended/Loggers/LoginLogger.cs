using System;

public class LoginLogger
{
    private readonly string _successLogPath = "SuccessLog.txt";
    private readonly string _errorLogPath = "ErrorLog.txt";

    public LoginLogger()
    {
    }
    public void LogSuccess(string username)
    {
        var logMessage = $"{DateTime.Now}: User {username} logged in successfully.";
        File.AppendAllText(_successLogPath, logMessage + Environment.NewLine);
    }

    public void LogError(string username, string errorMessage)
    {
        var logMessage = $"{DateTime.Now}: User {username} failed to log in. Error: {errorMessage}";
        File.AppendAllText(_errorLogPath, logMessage + Environment.NewLine);
    }
}
