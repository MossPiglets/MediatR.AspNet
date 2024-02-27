using MediatR.AspNet;

namespace Demo.Exceptions;

public class MyCustomException : BaseApplicationException {
    public MyCustomException() : base("I'm a teapot", StatusCodes.Status418ImATeapot, "I'm a custom teapot") { }
}
