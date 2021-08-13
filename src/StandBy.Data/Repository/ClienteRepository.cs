using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StandBy.Business.Interfaces;
using StandBy.Business.Models;
using StandBy.Data.Context;

namespace StandBy.Data.Repository
{
    public class ClienteRepository : Repository<Cliente> , ICliente
    {
        public ClienteRepository(AppDbContext context) : base (context)
        {

        }
    }

}
