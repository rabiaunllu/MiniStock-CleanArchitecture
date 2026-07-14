namespace MiniStock.Application.Common.Exceptions;

// Bu sınıf bizim kendi özel hata sınıfımız
public class ConflictException : Exception
{
    public ConflictException(string message) : base(message)
    {
    }
}