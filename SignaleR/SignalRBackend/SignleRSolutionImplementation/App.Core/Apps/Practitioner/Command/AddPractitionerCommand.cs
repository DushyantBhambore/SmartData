using App.Core.Dto;
using App.Core.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App.Core.Apps.Practitioner.Command
{
    public class AddPractitionerCommand : IRequest<string>
    {
        public PractitionerDto PractitionerDto { get; set; }
    }
    public class AddPractitionerCommandHandller : IRequestHandler<AddPractitionerCommand,string>
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
                if (request.PractitionerDto.PractitionerID == 0)
                {
                    var newpatient = new Domain.Patient
                    {
                        PId = request.PractitionerDto.PractitionerID,
                        Email = request.PractitionerDto.Email,
                        FirstName = request.PractitionerDto.FirstName,
                        LastName = request.PractitionerDto.LastName,
                        RoleId = request.PractitionerDto.RoleId,
                        Username = request.PractitionerDto.Username,
                        Password = request.PractitionerDto.Password,
                        Country = request.PractitionerDto.Country,
                        State = request.PractitionerDto.State,
                        City = request.PractitionerDto.City,
                        Gender = request.PractitionerDto.Gender,
                        CreatedBy = "Admin",
                        CreatedOn = DateTime.Now,
                        IsActive = true,
                        IsDeletd = false,
                    };
                    await _appDbContext.Set<Domain.Patient>().AddAsync(newpatient);
                    await _appDbContext.SaveChangesAsync();
                    return JsonSerializer.Serialize(new { message = "Practiioner is Added Successfully" });
                }

                else if (request.PractitionerDto.PractitionerID > 0)
                {

                    var updatuser = await _appDbContext.Set<Domain.Patient>().FindAsync(request.PractitionerDto.PId);

                    if (updatuser != null)
                    {

                        updatuser.PId = request.PractitionerDto.PractitionerID;
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
                        return JsonSerializer.Serialize(new { message = "Update Practiioner" });
                    }
                }
            }
            return JsonSerializer.Serialize(new { message = "Email is Already Exits" });

        }
    }
}
