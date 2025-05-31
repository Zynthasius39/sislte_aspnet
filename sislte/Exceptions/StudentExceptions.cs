namespace sislte.Exceptions;

public class StudentException(string message) : Exception(message);
public class StudentInvalidCredentialsException() : StudentException("Invalid email or password.");
public class StudentAlreadyExistsException(string email) : StudentException($"A user with email '{email}' already exists.");
public class StudentNotFoundException(object key) : StudentException($"Student with key '{key}' was not found.");
