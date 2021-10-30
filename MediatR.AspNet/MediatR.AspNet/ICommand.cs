namespace MediatR.AspNet {
    public interface ICommand<T> : IRequest<T> where T : class { }
}