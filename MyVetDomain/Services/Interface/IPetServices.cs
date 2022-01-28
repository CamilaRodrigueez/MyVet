using MyVetDomain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyVetDomain.Services.Interface
{
    public interface IPetServices
    {
        List<PetDto> GetAllMyPets(int idUser);
        List<TypePetDto> GetAllTypePet();
        List<SexDto> GetAllSexs();
        Task<ResponseDto> DeletePetAsync(int idPet);
        Task<bool> InsertPetAsync(PetDto pet);
        Task<bool> UpdatePetAsync(PetDto pet);
    }
}
