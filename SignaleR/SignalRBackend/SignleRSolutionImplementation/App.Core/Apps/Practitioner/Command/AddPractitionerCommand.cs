using App.Core.Dto;
using App.Core.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace App.Core.Apps.Practitioner.Command
{
    public class AddPractitionerCommand : IRequest<string>
    {
        public PractitionerDto PractitionerDto { get; set; }
    }
    public class AddPractitionerCommandHandller : IRequestHandler<AddPractitionerCommand, string>
    {
        private readonly IAppDbContext _appDbContext;

        public AddPractitionerCommandHandller(IAppDbContext appDbContext)
        {

            _appDbContext = appDbContext;
        }

        public async Task<string> Handle(AddPractitionerCommand request, CancellationToken cancellationToken)
        {
            var chcekemail = await _appDbContext.Set<Domain.Practitioner>().
               FirstOrDefaultAsync(a => a.Email == request.PractitionerDto.Email);

            if (chcekemail == null || (chcekemail != null && chcekemail.PractitionerID == request.PractitionerDto.PractitionerID))
            {
                var newpractioner = new Domain.Practitioner();
                if (request.PractitionerDto.PractitionerID == 0)
                {

                    {
                        newpractioner.PractitionerID = request.PractitionerDto.PractitionerID;
                        newpractioner.Email = request.PractitionerDto.Email;
                        newpractioner.FirstName = request.PractitionerDto.FirstName;
                        newpractioner.LastName = request.PractitionerDto.LastName;
                        newpractioner.RoleId = request.PractitionerDto.RoleId;
                        newpractioner.Username = request.PractitionerDto.Username;
                        newpractioner.Password = request.PractitionerDto.Password;
                        newpractioner.Country = request.PractitionerDto.Country;
                        newpractioner.State = request.PractitionerDto.State;
                        newpractioner.City = request.PractitionerDto.City;
                        newpractioner.Gender = request.PractitionerDto.Gender;
                        newpractioner.CreatedBy = "Admin";
                        newpractioner.CreatedOn = DateTime.Now;
                        newpractioner.IsActive = true;
                        newpractioner.IsDeletd = false;
                    };

                    var newuser = await _appDbContext.Set<Domain.User>().FirstOrDefaultAsync(a => a.UserId == 0);
                    var adduser = new Domain.User();
                    if (newuser == null)
                    {

                        adduser.UserName = request.PractitionerDto.Username;
                        adduser.RoleId = request.PractitionerDto.RoleId;
                        adduser.FirstName = request.PractitionerDto.FirstName;
                        adduser.LastName = request.PractitionerDto.LastName;
                        adduser.Email = request.PractitionerDto.Email;
                        adduser.Password = request.PractitionerDto.Password;
                        adduser.IsActive = true;
                        adduser.IsDeletd = false;
                        adduser.CreatedBy = "Admin";
                        adduser.CreatedOn = DateTime.Now;
                        await _appDbContext.Set<Domain.User>().AddAsync(adduser);
                        await _appDbContext.SaveChangesAsync();
                    }
                    var userid = await _appDbContext.Set<Domain.Practitioner>().FirstOrDefaultAsync(a => a.UserId == 0);
                    if (userid == null)
                    {
                        newpractioner.UserId = adduser.UserId;
                        await _appDbContext.Set<Domain.Practitioner>().AddAsync(newpractioner);
                        await _appDbContext.SaveChangesAsync();
                    }

                    return JsonSerializer.Serialize(new { message = "Practiioner is Added Successfully" });
                }

                else if (request.PractitionerDto.PractitionerID > 0)
                {

                    var updatuser = await _appDbContext.Set<Domain.Practitioner>().FindAsync(request.PractitionerDto.PractitionerID);

                    if (updatuser != null)
                    {
                        updatuser.PractitionerID = request.PractitionerDto.PractitionerID;
                        updatuser.Username = request.PractitionerDto.Username;
                        updatuser.FirstName = request.PractitionerDto.FirstName;
                        updatuser.LastName = request.PractitionerDto.LastName;
                        updatuser.Email = request.PractitionerDto.Email;
                        updatuser.Password = request.PractitionerDto.Password;
                        updatuser.RoleId = request.PractitionerDto.RoleId;
                        updatuser.Country = request.PractitionerDto.Country;
                        updatuser.State = request.PractitionerDto.State;
                        updatuser.City = request.PractitionerDto.City;
                        updatuser.Gender = request.PractitionerDto.Gender;
                        updatuser.UpdateBy = "Admin";
                        updatuser.UpdatedOn = DateTime.Now;
                        await _appDbContext.SaveChangesAsync(cancellationToken);
                    }
                    var newuser = await _appDbContext.Set<Domain.User>().FirstOrDefaultAsync(a => a.UserId == updatuser.UserId);
                    if (newuser != null)
                    {
                        newuser.UserName = request.PractitionerDto.Username;
                        newuser.RoleId = request.PractitionerDto.RoleId;
                        newuser.FirstName = request.PractitionerDto.FirstName;
                        newuser.LastName = request.PractitionerDto.LastName;
                        newuser.Email = request.PractitionerDto.Email;
                        newuser.Password = request.PractitionerDto.Password;
                        newuser.UpdateBy = "Admin";
                        newuser.UpdatedOn = DateTime.Now;
                        await _appDbContext.SaveChangesAsync(cancellationToken);
                    }

                    return JsonSerializer.Serialize(new { message = "Update Practiioner" });

                }
            }
            return JsonSerializer.Serialize(new { message = "Email is Already Exits" });

        }
    }
}
