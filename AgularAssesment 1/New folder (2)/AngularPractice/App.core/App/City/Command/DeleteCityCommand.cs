using App.core.Interface;
using MediatR;

namespace App.Core.Apps.City.Command

{
  public class DeleteCityCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
    public class DeleteCityCommandHandller : IRequestHandler<DeleteCityCommand, int>
    {
        private readonly IAppDBContext applicationDbContext;

        public DeleteCityCommandHandller(IAppDBContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }
        public async Task<int> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var model = request.Id;

            var findid = applicationDbContext.Set<Domain.City>().Find(model);

            if (findid != null || findid.IsDelete == true)
            {
                findid.IsDelete = true;
                findid.IsActive = false;
                await applicationDbContext.SaveChangesAsync();
                return findid.CityId;
            }
            return 0;
        }
    }
}
