using App.core.Interface;
using MediatR;

namespace App.Core.Apps.Country.Command

{
  public class DeleteCountryCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
    public class DeleteCountryCommandHandller : IRequestHandler<DeleteCountryCommand, int>
    {
        private readonly IAppDBContext applicationDbContext;

        public DeleteCountryCommandHandller(IAppDBContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }
        public async Task<int> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            var model = request.Id;

            var findid = applicationDbContext.Set<Domain.Country>().Find(model);

            if (findid != null)
            {
                findid.IsDelete = true;
                findid.IsActive = false;
                await applicationDbContext.SaveChangesAsync();
                return findid.CountryId;
            }
            return 0;
        }
    }
}
