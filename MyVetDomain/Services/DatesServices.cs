using Common.Utils.Enums;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models.Master;
using Infraestructure.Entity.Models.Vet;
using MyVetDomain.Dto;
using MyVetDomain.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVetDomain.Services
{
    public class DatesServices : IDatesServices
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion


        #region Builder
        public DatesServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        public List<DatesDto> GetAllMyDates(int idUser)
        {
            var dates = _unitOfWork.DatesRepository.FindAll(p => p.PetEntity.UserPetEntity.IdUser == idUser
                                                            , d => d.PetEntity.UserPetEntity
                                                            , d => d.ServicesEntity
                                                            , d => d.StateEntity).ToList();


            List<DatesDto> list = dates.Select(x => new DatesDto
            {
                Date = x.Date,
                IdDates = x.Id,
                IdPet = x.IdPet,
                Name = x.PetEntity.Name,
                IdServives = x.IdServives,
                Services = x.ServicesEntity.Services,
                IdState = x.IdState,
                Estado = x.StateEntity.State,
                ClosingDate = x.ClosingDate,
                Contact = x.Contact,

            }).ToList();


            return list;
        }

        public List<TypePetDto> GetAllTypePet()
        {
            List<TypePetEntity> typePets = _unitOfWork.TypePetRepository.GetAll().ToList();

            List<TypePetDto> list = typePets.Select(x => new TypePetDto
            {
                IdTypePet = x.Id,
                TypePet = x.TypePet
            }).ToList();

            return list;
        }
        public List<StateDto> GetAllState()
        {
            List<StateEntity> states = _unitOfWork.StateRepository.GetAll().ToList();

            List<StateDto> list = states.Select(x => new StateDto
            {
                IdState = x.IdState,
                State = x.State
            }).ToList();

            return list;
        }
        public List<ServicesDto> GetAllServices()
        {
            List<ServicesEntity> services = _unitOfWork.ServicesRepository.GetAll().ToList();

            List<ServicesDto> list = services.Select(x => new ServicesDto
            {
                IdServices = x.Id,
                Services = x.Services
            }).ToList();

            return list;
        }
        public List<PetDto> GetAllNamePets()
        {
            List<PetEntity> pets = _unitOfWork.PetRepository.GetAll().ToList();

            List<PetDto> list = pets.Select(x => new PetDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return list;
        }

        public async Task<bool> InsertDateAsync(DatesDto dates)
        {
            DatesEntity datesEntity = new DatesEntity()
            {
                Contact = dates.Contact,
                Date = dates.Date,
                IdServives = dates.IdServives,
                IdPet=dates.IdPet,
                IdState =(int)Enums.State.CitaActiva,

            };

            _unitOfWork.DatesRepository.Insert(datesEntity);
            return await _unitOfWork.Save() > 0;
        }

        public async Task<ResponseDto> DeleteDateAsync(int idDate)
        {
            ResponseDto response = new ResponseDto();

            _unitOfWork.DatesRepository.Delete(idDate);
            response.IsSuccess = await _unitOfWork.Save() > 0;
            if (response.IsSuccess)
                response.Message = "Se elminnó correctamente la Cita";
            else
                response.Message = "Hubo un error al eliminar la Cita, por favor vuelva a intentalo";

            return response;
        }

        public async Task<bool> UpdateDateAsync(DatesDto dates)
        {
            bool result = false;

            DatesEntity datesEntity = _unitOfWork.DatesRepository.FirstOrDefault(x => x.Id == dates.IdDates);
            if (datesEntity != null)
            {
                datesEntity.Contact = dates.Contact;
                datesEntity.Date = dates.Date;
                datesEntity.IdServives = dates.IdServives;
                datesEntity.Name = dates.Name;

                _unitOfWork.DatesRepository.Update(datesEntity);

                result = await _unitOfWork.Save() > 0;
            }

            return result;
        }
        #endregion
    }
}
