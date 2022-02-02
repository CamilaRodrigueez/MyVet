using MyVetDomain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyVetDomain.Services.Interface
{
    public interface IDatesServices
    {
        List<DatesDto> GetAllMyDates(int idUser);
        List<TypePetDto> GetAllTypePet();
        List<StateDto> GetAllState();
        List<ServicesDto> GetAllServices();
        List<PetDto> GetAllNamePets();
        Task<bool> InsertDateAsync(DatesDto dates);
        Task<ResponseDto> DeleteDateAsync(int idDate);

    }
}
