﻿using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Infrastructure.Database.Repositories
{
    public class ReservationRepository : IReservationRepository
    {

        private readonly StakeholdersContext _dbContext;

        public ReservationRepository(StakeholdersContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
