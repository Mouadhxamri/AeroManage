using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane : Service<Plane>, IServicePlane

    {
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


    }
}
