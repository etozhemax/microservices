using MediatR;
using Microservices.Catalog.Application.Commands.Brands;
using Microservices.Catalog.Core.Entities;
using Microservices.Catalog.Core.Repositories.Interfaces;

namespace Microservices.Catalog.Application.Handlers.Brands
{
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, bool>
    {
        private readonly IRepository<ProductBrandEntity, string> _repository;

        public DeleteBrandCommandHandler(
            IRepository<ProductBrandEntity, string> repository
            )
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteAsync(request.BrandId);
        }
    }
}
