using App.core.Dto;
using App.core.Interface;
using Domain;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.core.App.State.Query
{
    //public class GetStateByCountryId : IRequest<StateDto>
    //{
    //    public int Id { get; set; }
    //}

    //public class GetStateByCountryIdHandller : IRequestHandler<GetStateByCountryId, StateDto>
    //{
    //    private readonly IAppDBContext _appDBContext;

    //    public GetStateByCountryIdHandller(IAppDBContext appDBContext)
    //    {
    //        _appDBContext = appDBContext;
    //    }
    //    public Task<StateDto> Handle(GetStateByCountryId request, CancellationToken cancellationToken)
    //    {

    //        var countryid = request.Id;

    //        var model = _appDBContext.Set<Domain.State>().FirstOrDefault(a => a.CountryId == countryid);
            
    //        if(model !=null || model.IsDelete==true)
    //        {
    //            return null;
    //        }
    //        return model.Adapt<StateDto>();
    //    }
    //}

}
