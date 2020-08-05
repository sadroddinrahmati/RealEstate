using RealEstate.Core.Domain;
using RealEstate.Core.Interface.Services;
using RealEstate.Infrastructure.EFRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure.Services
{
    public class EstateService : IEstateService
    {
        #region Fields

        private readonly IRepository<Estate> _estateRepository;

        #endregion

        #region Constructor
        public EstateService(IRepository<Estate> estateRepository)
        {
            _estateRepository = estateRepository;
        }

        #endregion

        #region Methods
        public async Task<IList<Estate>> GetAllEstates(string term = "")
        { 
            if (term != "")
            {
                return await _estateRepository.GetAll(
                    e => e.Name.Contains(term) ||
                    e.Owner.Name.Contains(term) ||
                    e.Owner.LastName.Contains(term) ||
                    e.Owner.Mobile.Contains(term) ||
                    e.Area.ToString() == term
                                    , e => e.Owner);
            }

            return await _estateRepository.GetAll(null, e => e.Owner); 
        }

        public Estate GetEstateById(Guid id)
        {
            if (id == Guid.Empty)
                return null;

            return _estateRepository.FindByExpression(x => x.Id == id);
        }

        public void InsertEstate(Estate estate)
        {
            if (estate == null)
                throw new ArgumentNullException("estate");

            _estateRepository.Insert(estate);
            _estateRepository.SaveChanges();
        }

        public void UpdateEstate(Estate estate)
        {
            if (estate == null)
                throw new ArgumentNullException("estate");

            _estateRepository.Update(estate);
            _estateRepository.SaveChanges();
        }

        public void DeleteEstate(Estate estate)
        {
            if (estate == null)
                throw new ArgumentNullException("estate");
            estate.IsDelete = true;
            _estateRepository.Update(estate);
            _estateRepository.SaveChanges();
        }


        #endregion
    }
}
