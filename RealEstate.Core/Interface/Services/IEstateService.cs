using RealEstate.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Core.Interface.Services
{
    public interface IEstateService
    {
        Task<IList<Estate>> GetAllEstates(string term = "");
        Estate GetEstateById(Guid id);
        void InsertEstate(Estate estate);
        void UpdateEstate(Estate estate);
        void DeleteEstate(Estate estate);
    }
}
