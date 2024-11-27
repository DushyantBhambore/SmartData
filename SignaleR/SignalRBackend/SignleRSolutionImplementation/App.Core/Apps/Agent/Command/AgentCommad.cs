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
                var newagent = new Domain.Agent();


                if (request.AgentDto.AId == 0)
                {

                    {
                        newagent.AId = request.AgentDto.AId;
                        newagent.Email = request.AgentDto.Email;
                        newagent.FirstName = request.AgentDto.FirstName;
                        newagent.LastName = request.AgentDto.LastName;
                        newagent.RoleId = request.AgentDto.RoleId;
                        newagent.Username = request.AgentDto.Username;
                        newagent.Password = request.AgentDto.Password;
                        newagent.Country = request.AgentDto.Country;
                        newagent.State = request.AgentDto.State;
                        newagent.City = request.AgentDto.City;
                        newagent.Gender = request.AgentDto.Gender;
                        newagent.CreatedBy = "Admin";
                        newagent.CreatedOn = DateTime.Now;
                        newagent.IsActive = true;
                        newagent.IsDeletd = false;
                    };
                    var newuser = await _appDbContext.Set<Domain.User>().FirstOrDefaultAsync(a => a.UserId == 0);
                    var adduser = new Domain.User();
                    if (newuser == null)
                    {

                        adduser.UserName = request.AgentDto.Username;
                        adduser.RoleId = request.AgentDto.RoleId;
                        adduser.FirstName = request.AgentDto.FirstName;
                        adduser.LastName = request.AgentDto.LastName;
                        adduser.Email = request.AgentDto.Email;
                        adduser.Password = request.AgentDto.Password;
                        adduser.IsActive = true;
                        adduser.IsDeletd = false;
                        adduser.CreatedBy = "Admin";
                        adduser.CreatedOn = DateTime.Now;
                        await _appDbContext.Set<Domain.User>().AddAsync(adduser);
                        await _appDbContext.SaveChangesAsync();
                    }
                    var userid = await _appDbContext.Set<Domain.Agent>().FirstOrDefaultAsync(a => a.UserId == 0);
                    if (userid == null)
                    {
                        newagent.UserId = adduser.UserId;
                        await _appDbContext.Set<Domain.Agent>().AddAsync(newagent);
                        await _appDbContext.SaveChangesAsync();
                    }

                    return JsonSerializer.Serialize(new { message = "Agent is Added Successfully" });
                }

                else if (request.AgentDto.AId > 0)
                {

                    var updatuser = await _appDbContext.Set<Domain.Agent>().FindAsync(request.AgentDto.AId);

                    if (updatuser != null)
                    {

                        updatuser.AId = request.AgentDto.AId;
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
                    }
                    var newuser = await _appDbContext.Set<Domain.User>().FirstOrDefaultAsync(a => a.UserId == updatuser.UserId);
                    if (newuser != null)
                    {

                        newuser.UserName = request.AgentDto.Username;
                        newuser.RoleId = request.AgentDto.RoleId;
                        newuser.FirstName = request.AgentDto.FirstName;
                        newuser.LastName = request.AgentDto.LastName;
                        newuser.Email = request.AgentDto.Email;
                        newuser.Password = request.AgentDto.Password;
                        newuser.UpdateBy = "Admin";
                        newuser.UpdatedOn = DateTime.Now;
                        await _appDbContext.SaveChangesAsync(cancellationToken);
                    }
                    return JsonSerializer.Serialize(new { message = "Update Agent" });

                }
            }
            return JsonSerializer.Serialize(new { message = "Email is Already Exits" });


        }
    }
}

