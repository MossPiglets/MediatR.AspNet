# MediatR.AspNet

CQRS support for MediatR in ASP.Net.

Made as .Net Standard 2.0 library.

### Features

- interface `IQuery<T>`
- interface `ICommand<T>`
- custom Exceptions:
    - `ExistsException`
    - `DeletedNotAllowedException`
    - `NotFoundException`
    - `OperationNotAllowedException`
    - `UpdateNotAllowedException`
- custom Exception Filter

### Usage

1. Add Nuget package from [here](https://www.nuget.org/packages/MediatR.AspNet/).
2. In startup of your project:

        public void ConfigureServices(IServiceCollection services) {
			services.AddMediatR(typeof(Startup));
			services.AddControllers(o => o.Filters.AddMediatrExceptions());
		}

You can see Demo Project [here](https://github.com/MossPiglets/MediatR.AspNet/tree/develop/MediatR.AspNet/Demo)

### Development
We are happy to accept suggestions for further development. Please feel free to add Issues :)

### Authors
- [Katarzyna-Kadziolka](https://github.com/Katarzyna-Kadziolka)

### License
This project is licensed under the MIT License - see the [LICENSE](https://raw.githubusercontent.com/MossPiglets/MediatR.AspNet/develop/LICENSE) file for details.