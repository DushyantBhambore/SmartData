using StudentProject.Data;
using StudentProject.Interface;
using StudentProject.Model;

namespace StudentProject.Services
{
    public class PateintServices : IPateints
    {
        private readonly ApplicationDbContext dbContext;

        public PateintServices(ApplicationDbContext _dbContext)
        {
           dbContext = _dbContext;
        }
        public void AddPateint(PateintsModel model)
        {
            dbContext.pateints.Add(new Model.PateintsModel
            {
                Pateint_id = model.Pateint_id,
                PateintName = model.PateintName,
                Email = model.Email,
                DateOfBirth = DateTime.Now,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                City = model.City,
                Insurance_id = model.Insurance_id,

            });
            dbContext.SaveChanges();
        }

        public void DeletePateint(int id)
        {
            var obj = dbContext.pateints.Find(id);
            if (obj != null)
            {
                dbContext.pateints.Remove(obj);
                dbContext.SaveChanges();    
            }
            

        }

        public PateintsModel Getpateint(int id)
        {
            var obj = dbContext.pateints.Find(id);
            if (obj is not null)
            {
                PateintsModel model = new()
                {
                    PateintName = obj.PateintName,
                    Email = obj.Email,
                    DateOfBirth = obj.DateOfBirth,
                    PhoneNumber = obj.PhoneNumber,
                    Address = obj.Address,
                    City = obj.City,
                    Insurance_id = obj.Insurance_id,
                };
                return model;
            }
            return null;
            
        }

        public List<PateintsModel> GetPateintsList()
        {
            List<PateintsModel> model = new();
            var list = dbContext.pateints.ToList();

            foreach ( var obj in list )
            {
                model.Add(new PateintsModel
                {
                    Pateint_id = obj.Pateint_id,
                    PateintName = obj.PateintName,
                    Email = obj.Email,
                    DateOfBirth = obj.DateOfBirth,
                    PhoneNumber = obj.PhoneNumber,
                    Address = obj.Address,
                    City = obj.City,
                    Insurance_id = obj.Insurance_id,

                });
            }
            return model;
        }
        public void UpdatePateint(PateintsModel model)
        {
            var obj = dbContext.pateints.Find(model.Pateint_id);
            if(obj is not null)
            {
                obj.PateintName = model.PateintName;
                obj.Email = model.Email;
                obj.Address = model.Address;
                obj.City = model.City;
                obj.DateOfBirth = model.DateOfBirth;    
                obj.PhoneNumber = model.PhoneNumber;
                obj.Insurance_id = model.Insurance_id;
                dbContext.SaveChanges();
            }
        }
    }
}
