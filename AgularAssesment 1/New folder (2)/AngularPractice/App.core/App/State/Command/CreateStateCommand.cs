using App.core.Dto;
using App.core.Interface;
using Domain;
using Mapster;
using MediatR;


namespace App.core.App.State.Command
{
    public class CreateStateCommand : IRequest<int>
    {
        public StateDto State { get; set; }
    }

    public class CreateStateCommandHandler : IRequestHandler<CreateStateCommand, int>
    {
        private readonly IAppDBContext _applicationDbContext;

        public CreateStateCommandHandler(IAppDBContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<int> Handle(CreateStateCommand request, CancellationToken cancellationToken)
        {
            var model = request.State;
           
            var customer = model.Adapt<Domain.State>();
            await _applicationDbContext.Set<Domain.State>().AddAsync(customer);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return model.StateId;
        }
    }

}
