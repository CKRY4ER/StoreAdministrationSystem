namespace StoreAdministrationSystem.Admin.Client.Services.Exceptions;

public class ServerException : Exception
{
    public ServerException(string? message = default) : base(message)
    {
    }
}
