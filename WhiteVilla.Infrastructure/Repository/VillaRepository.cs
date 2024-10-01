using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WhiteVilla.Application.Common.Interfaces;
using WhiteVilla.Domain.Entities;
using WhiteVilla.Infrastructure.Data;

namespace WhiteVilla.Infrastructure.Repository
{
    public class VillaRepository :Repository<Villa> ,IVillaRepository
    {
        private readonly ApplicationDbContext _db;

        public VillaRepository(ApplicationDbContext db):base(db) 
        {
            _db = db;

        }
        public void Add(Villa entity)
        {
           _db.Add(entity);
        }

        public void Update(Villa entity)
        {
            _db.Update(entity);
        }
    }
}
