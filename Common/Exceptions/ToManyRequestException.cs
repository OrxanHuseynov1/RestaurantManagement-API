namespace Common.Exceptions;

public class ToManyRequestException(string message) : Exception(message)
{
}
