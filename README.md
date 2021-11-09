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
**Configuration**

1. Add Nuget package from [here](https://www.nuget.org/packages/MediatR.AspNet/).
2. In startup of your project:

        public void ConfigureServices(IServiceCollection services) {
			services.AddMediatR(typeof(Startup));
			services.AddControllers(o => o.Filters.AddMediatrExceptions());
		}

You can see Demo Project [here](https://github.com/MossPiglets/MediatR.AspNet/tree/develop/MediatR.AspNet/Demo)

**Example usage**

Example for `GetById` endpoint:

1. Create model:

        public class Product {

            public int Id { get; set; }
            public string Name { get; set; }
        }
2. Create model Dto:

        public class ProductDto {

            public int Id { get; set; }
            public string Name { get; set; }
        }
3. Create `GetByIdQuery`:

        public class GetProductByIdQuery : IQuery<ProductDto> {

            public int Id { get; set; }
        }
4. Create `GetByIdQueryHandler`:

        public class GetProductByIdQueryHandler: IRequestHandler<GetProductByIdQuery, ProductDto> {
        
            private readonly ProductContext _context;
            private readonly IMapper _mapper;
        
            public GetProductByIdQueryHandler(ProductContext context, IMapper mapper) {
                _context = context;
                _mapper = mapper;
            }
        
            public Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) {
                var productEntity = await _context.Products
                    .Where(a => a.ProductId == request.id);
                if (productEntity == null) {
                    throw new NotFoundException(typeof(Product), request.Id.ToString());
                }

                var mappedProductEntity = _mapper.Map<ProductDto>(productEntity);
                return Task.FromResult(mappedProductEntity);
            }
        }

5. Usage in controller:

        [ApiController]
        [Route("[controller]")]
        public class ProductsController : ControllerBase {
        
            private readonly IMediator _mediator;

            public ProductsController(IMediator mediator) {
                _mediator = mediator;
            }
        
            [HttpGet("{id}")]
            public async Task<ProductDto> GetById([FromRoute]int id) {
                var query = new GetProductByIdQuery {
                    Id = id
                };
                return await _mediator.Send(query);
            }
        }
    


### Development
We are happy to accept suggestions for further development. Please feel free to add Issues :)

### Authors
- [Katarzyna-Kadziolka](https://github.com/Katarzyna-Kadziolka)

### License
This project is licensed under the MIT License - see the [LICENSE](https://raw.githubusercontent.com/MossPiglets/MediatR.AspNet/develop/LICENSE) file for details.