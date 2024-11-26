using App.Core.Dto;
using App.Core.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace App.Core.Apps.Agent.Command
{
    public class AgentCommad : IRequest<string>
    {
        public AgentDto AgentDto { get; set; }
    }
    public class AgentCommandHandller : IRequestHandler<AgentCommad, string>
    {
        private readonly IAppDbContext _appDbContext;

        public AgentCommandHandller(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<string> Handle(AgentCommad request, CancellationToken cancellationToken)
        {

            var chcekemail = await _appDbContext.Set<Domain.Agent>().
               FirstOrDefaultAsync(a => a.Email == request.AgentDto.Email);

            if (chcekemail == null || (chcekemail != null && chcekemail.AId == request.AgentDto.AId))
            {
                if (request.AgentDto.AId == 0)
                {
                    var newpatient = new Domain.Patient
                    {
                        PId = request.AgentDto.AId,
                        Email = request.AgentDto.Email,
                        FirstName = request.AgentDto.FirstName,
                        LastName = request.AgentDto.LastName,
                        RoleId = request.AgentDto.RoleId,
                        Username = request.AgentDto.Username,
                        Password = request.AgentDto.Password,
                        Country = request.AgentDto.Country,
                        State = request.AgentDto.State,
                        City = request.AgentDto.City,
                        Gender = request.AgentDto.Gender,
                        CreatedBy = "Admin",
                        CreatedOn = DateTime.Now,
                        IsActive = true,
                        IsDeletd = false,
                    };
                    await _appDbContext.Set<Domain.Patient>().AddAsync(newpatient);
                    await _appDbContext.SaveChangesAsync();
                    return JsonSerializer.Serialize(new { message = "Agent is Added Successfully" });
                }

                else if (request.AgentDto.AId > 0)
                {

                    var updatuser = await _appDbContext.Set<Domain.Patient>().FindAsync(request.AgentDto.AId);

                    if (updatuser != null)
                    {

                        updatuser.PId = request.AgentDto.AId;
                        updatuser.Username = request.AgentDto.Username;
                        updatuser.FirstName = request.AgentDto.FirstName;
                        updatuser.LastName = request.AgentDto.LastName;
                        updatuser.Email = request.AgentDto.Email;
                        updatuser.Password = request.AgentDto.Password;
                        updatuser.RoleId = request.AgentDto.RoleId;
                        updatuser.Country = request.AgentDto.Country;
                        updatuser.State = request.AgentDto.State;
                        updatuser.City = request.AgentDto.City;
                        updatuser.Gender = request.AgentDto.Gender;
                        updatuser.UpdateBy = "Admin";
                        updatuser.UpdatedOn = DateTime.Now;
                        await _appDbContext.SaveChangesAsync(cancellationToken);
                        return JsonSerializer.Serialize(new { message = "Update Agent" });
                    }
                }
            }
            return JsonSerializer.Serialize(new { message = "Email is Already Exits" });


        }
    }
}

