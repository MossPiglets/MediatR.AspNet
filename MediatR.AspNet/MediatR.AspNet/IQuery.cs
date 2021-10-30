namespace MediatR.AspNet {
    public interface IQuery<T> : IRequest<T> where T : class { }
}