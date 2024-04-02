using MediatR;
using Microservices.Catalog.Application.Commands.Brands;
using Microservices.Catalog.Core.Entities;
using Microservices.Catalog.Core.Repositories.Interfaces;

namespace Microservices.Catalog.Application.Handlers.Brands
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, bool>
    {
        private readonly IRepository<ProductBrandEntity, string> _repository;

        public UpdateBrandCommandHandler(
            IRepository<ProductBrandEntity, string> repository
            )
        {
            _repository = repository;
        }

        public Task<bool> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            return _repository.UpdateAsync(request.Brand);
        }
    }
}
