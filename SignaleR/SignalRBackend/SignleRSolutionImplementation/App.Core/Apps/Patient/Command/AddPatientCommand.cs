using App.Core.Dto;
using App.Core.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

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
                FirstOrDefaultAsync(a => a.Email == request.patientDto.Email);

            if (chcekemail == null || (chcekemail != null && chcekemail.PId == request.patientDto.PId))
            {
                var newpatient = new Domain.Patient();

                if (request.patientDto.PId == 0)
                {
                    {
                        newpatient.PId = request.patientDto.PId;
                        newpatient.Email = request.patientDto.Email;
                        newpatient.FirstName = request.patientDto.FirstName;
                        newpatient.LastName = request.patientDto.LastName;
                        newpatient.RoleId = request.patientDto.RoleId;
                        newpatient.Username = request.patientDto.Username;
                        newpatient.Password = request.patientDto.Password;
                        newpatient.Country = request.patientDto.Country;
                        newpatient.State = request.patientDto.State;
                        newpatient.City = request.patientDto.City;
                        newpatient.Gender = request.patientDto.Gender;
                        newpatient.CreatedBy = "Admin";
                        newpatient.CreatedOn = DateTime.Now;
                        newpatient.IsActive = true;
                        newpatient.IsDeletd = false;
                    };


                    var newuser = await _appDbContext.Set<Domain.User>().FirstOrDefaultAsync(a => a.UserId == 0);

                    var adduser = new Domain.User();

                    if (newuser == null)
                    {

                        adduser.UserName = request.patientDto.Username;
                        adduser.RoleId = request.patientDto.RoleId;
                        adduser.FirstName = request.patientDto.FirstName;
                        adduser.LastName = request.patientDto.LastName;
                        adduser.Email = request.patientDto.Email;
                        adduser.Password = request.patientDto.Password;
                        adduser.CreatedBy = "Admin";
                        adduser.IsActive = true;
                        adduser.IsDeletd = false;
                        adduser.CreatedOn = DateTime.Now;
                        await _appDbContext.Set<Domain.User>().AddAsync(adduser);
                        await _appDbContext.SaveChangesAsync();
                    }

                    var userid = await _appDbContext.Set<Domain.Patient>().FirstOrDefaultAsync(a => a.UserId == 0);
                    if (userid != null)
                    {
                        newpatient.UserId = adduser.UserId;
                        await _appDbContext.Set<Domain.Patient>().AddAsync(newpatient);
                        await _appDbContext.SaveChangesAsync();
                    }
                    return JsonSerializer.Serialize(new { message = "Patient is Added Successfully" });
                }

                else if (request.patientDto.PId > 0)
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
                    }

                    var newuser = await _appDbContext.Set<Domain.User>().FirstOrDefaultAsync(a => a.UserId == updatuser.UserId);
                    if (newuser != null)
                    {

                        newuser.UserName = request.patientDto.Username;
                        newuser.RoleId = request.patientDto.RoleId;
                        newuser.FirstName = request.patientDto.FirstName;
                        newuser.LastName = request.patientDto.LastName;
                        newuser.Email = request.patientDto.Email;
                        newuser.Password = request.patientDto.Password;
                        newuser.UpdateBy = "Admin";
                        newuser.UpdatedOn = DateTime.Now;
                        await _appDbContext.SaveChangesAsync(cancellationToken);
                    }
                    return JsonSerializer.Serialize(new { message = "Update Patient" });

                }
            }
            return JsonSerializer.Serialize(new { message = "Email is Already Exits" });


        }
    }
}
