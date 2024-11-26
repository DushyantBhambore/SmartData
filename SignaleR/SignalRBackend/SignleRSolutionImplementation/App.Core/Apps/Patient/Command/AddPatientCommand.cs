using App.Core.Dto;
using App.Core.Interface;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App.Core.Apps.Patient.Command
{
    public class AddPatientCommand : IRequest<string>
    {
        public PatientDto patientDto { get; set; }
    }
    public class AddPatientCommandHandller : IRequestHandler<AddPatientCommand, string>
    {
        private readonly IAppDbContext _appDbContext;

        public AddPatientCommandHandller(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<string> Handle(AddPatientCommand request, CancellationToken cancellationToken)
        {

            var chcekemail = await _appDbContext.Set<Domain.Patient>().
                FirstOrDefaultAsync(a=>a.Email ==request.patientDto.Email);

            if (chcekemail == null || (chcekemail != null && chcekemail.PId == request.patientDto.PId))
            {
                if (request.patientDto.PId == 0)
                {
                    var newpatient = new Domain.Patient
                    {
                        PId = request.patientDto.PId,
                        Email = request.patientDto.Email,
                        FirstName = request.patientDto.FirstName,
                        LastName = request.patientDto.LastName,
                        RoleId = request.patientDto.RoleId,
                        Username = request.patientDto.Username,
                        Password = request.patientDto.Password,
                        Country = request.patientDto.Country,
                        State = request.patientDto.State,
                        City = request.patientDto.City,
                        Gender = request.patientDto.Gender,
                        CreatedBy = "Admin",
                        CreatedOn = DateTime.Now,
                        IsActive = true,
                        IsDeletd = false,
                    };
                    await _appDbContext.Set<Domain.Patient>().AddAsync(newpatient);
                    await _appDbContext.SaveChangesAsync();
                    return JsonSerializer.Serialize(new { message = "Patient is Added Successfully" });
                }

                else if (request.patientDto.PId>0)
                {

                    var updatuser = await _appDbContext.Set<Domain.Patient>().FindAsync(request.patientDto.PId);

                    if (updatuser != null)
                    {

                        updatuser.PId = request.patientDto.PId;
                        updatuser.Username = request.patientDto.Username;
                        updatuser.FirstName = request.patientDto.FirstName;
                        updatuser.LastName = request.patientDto.LastName;
                        updatuser.Email = request.patientDto.Email;
                        updatuser.Password = request.patientDto.Password;
                        updatuser.RoleId = request.patientDto.RoleId;
                        updatuser.Country = request.patientDto.Country;
                        updatuser.State = request.patientDto.State;
                        updatuser.City = request.patientDto.City;
                        updatuser.Gender = request.patientDto.Gender;
                        updatuser.UpdateBy = "Admin";
                        updatuser.UpdatedOn = DateTime.Now;
                        await _appDbContext.SaveChangesAsync(cancellationToken);
                        return JsonSerializer.Serialize(new { message = "Update Patient" });
                    }
                }
            }
            return JsonSerializer.Serialize(new { message = "Email is Already Exits" });


        }
    }
}
