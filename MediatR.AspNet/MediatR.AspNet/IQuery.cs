namespace MediatR.AspNet {
    public interface IQuery : IRequest {}
    public interface IQuery<T> : IRequest<T> where T : class { }
}