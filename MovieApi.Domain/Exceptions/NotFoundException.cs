namespace MovieApi.Domain.Exceptions;

public class NotFoundException(string entityName, object key)
    : Exception($"{entityName} med id {key} hittades inte.")
{ }
