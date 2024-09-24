using System.Security;

public class SmtpEmailSettings
{
    public string? Username { get; internal set; }
    public int Port { get; internal set; }
    public string? Host { get; internal set; }
    public SecureString? Password { get; internal set; }
}