
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WhiteVilla.Domain.Entities;

namespace WhiteVilla.Application.Common.Interfaces
{
    public interface IAmenityRepository:IRepository<Amenity>
    {

        void Update(Amenity entity);

    }
}
