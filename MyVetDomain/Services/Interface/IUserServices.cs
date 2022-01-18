﻿using Infraestructure.Entity.Models;
using MyVetDomain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyVetDomain.Services.Interface
{
    public  interface IUserServices
    {
        List<UserEntity> GetAll();
        UserEntity GetUser(int idUser);

        Task<bool> UpdateUser(UserEntity user);
        Task<bool> DeleteUser(int idUser);
        Task<ResponseDto> CreateUser(UserEntity data);
    }
}
