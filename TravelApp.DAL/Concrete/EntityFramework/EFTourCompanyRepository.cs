﻿using Microsoft.EntityFrameworkCore;
using TravelApp.DAL.Abstract;
using TravelApp.DAL.Concrete.EntityFramework.DataManagement;
using TravelApp.Entity.POCO;

namespace TravelApp.DAL.Concrete.EntityFramework
{
    public class EFTourCompanyRepository : EFRepository<TourCompany>, ITourCompanyRepository
    {
        public EFTourCompanyRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
