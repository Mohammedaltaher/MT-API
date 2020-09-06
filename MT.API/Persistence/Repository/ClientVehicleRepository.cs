using AggriPortal.API.Domain.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
namespace  AggriPortal.API.Persistence.Repository
{
    public interface IClientVehicleRepository : IBaseRepository<ClientVehicle>
    {
        Task<IEnumerable<ClientVehicle>> GetClientVehiclesInclude(Guid[] clientIds);
        Task<IEnumerable<ClientVehicle>> GetClientVehiclesInclude(Guid ClientId);
    }

    #region Implementation
    public class ClientVehicleRepository : BaseRepository<ClientVehicle>, IClientVehicleRepository
    {
        public ClientVehicleRepository(AppDbContext context)
            : base(context)
        {

        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<IEnumerable<ClientVehicle>> GetClientVehiclesInclude(Guid[] clientIds)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            return this.GetMany(x => clientIds.Contains(x.ClientId))
                       .Include("Client.ApplicationUser")
                       .Include("VehicleIdType")
                       .Include("VehiclePlateFirstLetter")
                       .Include("VehiclePlateSecondLetter")
                       .Include("VehiclePlateThirsdLetter")
                       .Include("VehiclePlateType")
                       .Include("VehicleMaker")
                       .Include("VehicleModel")
                       .Include("VehicleMajorColor")
                       .Include("VehicleIdType");
        }
        public async Task<IEnumerable<ClientVehicle>> GetClientVehiclesInclude(Guid ClientId)
        {
            return await this.GetMany(x => x.ClientId == ClientId)
                .Include("Client")
                .Include("Client.ApplicationUser")
                .Include("VehicleIdType")
                .Include("VehiclePlateFirstLetter")
                .Include("VehiclePlateSecondLetter")
                .Include("VehiclePlateThirsdLetter")
                .Include("VehiclePlateType")
                .Include("VehicleMaker")
                .Include("VehicleModel")
                .Include("VehicleMajorColor")
                .Include("VehicleBodyType")
                .Include("VehicleIdType")
                .Include("VehicleRegistrationCity")
                .Include("VehicleRepairMethod")
                .Include("VehicleUse")
                .Include("VehicleTransmissionType")
                .Include("VehicleAxleWeight").ToListAsync();
        }
    }
    #endregion
}
