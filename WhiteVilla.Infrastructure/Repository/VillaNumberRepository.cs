﻿using Microsoft.EntityFrameworkCore;
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
    public class VillaNumberRepository : Repository<VillaNumber>, IVillaNumberRepository
    {
        private readonly ApplicationDbContext _db;

        public VillaNumberRepository(ApplicationDbContext db):base(db) 
        {
            _db = db;

        }
        public void Update(VillaNumber entity)
        {
            _db.VillaNumbers.Update(entity);
        }
    }
}
