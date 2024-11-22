using App.core.Dto;
using App.core.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.core.App.Customer.Command
{
    public class UpdateCustomerCommand : IRequest<string>
    {
        public CustomerDto Customer { get; set; }
    }
    public class UpdateCustomerCommandHandller : IRequestHandler<UpdateCustomerCommand, string>
    {
        private readonly IAppDBContext applicationDbContext;

        public UpdateCustomerCommandHandller(IAppDBContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }
        public async Task<string> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var model = request.Customer;

            var obj = applicationDbContext.Set<Domain.Customers>().Find(model.CustomerID);
            if (obj != null)
            {
                obj.FirstName = model.FirstName;
                obj.LastName = model.LastName;
                obj.PhoneNumber = model.PhoneNumber;
                obj.CustomerAddressLine1 = model.CustomerAddressLine1;
                obj.CustomerAddressLine2 = model.CustomerAddressLine2;
                obj.CustomerEmail = model.CustomerEmail;
                obj.DateofBirth = model.DateofBirth;
                obj.Gender = model.Gender;
                obj.Occupation = model.Occupation;
                obj.Income = model.Income;
                obj.CityId = model.CityId;
                obj.StateId = model.StateId;
                obj.CountryId = model.CountryId;
                obj.PurchaseHistory = model.PurchaseHistory;
                obj.Feedback = model.Feedback;
                obj.PaymentMethod = model.PaymentMethod;
                obj.ReferralSource = model.ReferralSource;
                obj.CompanyName = model.CompanyName;
                obj.LastLoginDate = model.LastLoginDate;
                obj.IsActive = model.IsActive;
                obj.SocialMediaHandle = model.SocialMediaHandle;
                obj.CreditScore = model.CreditScore;
                obj.IsDelete = model.IsDelete;
        await applicationDbContext.SaveChangesAsync();
                // Return a proper JSON response
                return "{\"message\":\"Id Updated Successfully\"}";
            }
            return "{\"message\":\"Patient not found\"}";
        }
    }
}
