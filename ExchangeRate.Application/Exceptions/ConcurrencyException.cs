﻿namespace ExchangeRate.Application.Exceptions;

public sealed class ConcurrencyException(string message, Exception innerException) : Exception(message, innerException)
{

}
