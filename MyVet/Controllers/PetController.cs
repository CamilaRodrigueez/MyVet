﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVetDomain.Dto;
using MyVetDomain.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Common.Utils.Constant.Const;

namespace MyVet.Controllers
{
    [Authorize]
    public class PetController : Controller
    {
        #region Attribute
        private readonly IPetServices _petServices;
        #endregion

        #region Buider
        public PetController(IPetServices petServices)
        {
            _petServices = petServices;
        }
        #endregion

        #region Methods
        [HttpGet]
        public IActionResult Index()
        {
            var user = HttpContext.User;
            string idUser = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.IdUser).Value;

            List<PetDto> list = _petServices.GetAllMyPets(Convert.ToInt32(idUser));

            return View(list);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePet(int idPet)
        {
            ResponseDto response = await _petServices.DeletePetAsync(idPet);
            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetAllSexs()
        {
            List<SexDto> response = _petServices.GetAllSexs();
            return Ok(response);
        }
        [HttpGet]
        public IActionResult GetAllTypePet()
        {
            List<TypePetDto> response = _petServices.GetAllTypePet();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertPet(PetDto pet)
        {
            var user = HttpContext.User;
            string idUser = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.IdUser).Value;
            pet.IdUser = Convert.ToInt32(idUser);

            bool response = await _petServices.InsertPetAsync(pet);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePet(PetDto pet)
        {
            //var user = HttpContext.User;
            //string idUser = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.IdUser).Value;
            //pet.IdUser = Convert.ToInt32(idUser);

            bool response = await _petServices.UpdatePetAsync(pet);
            return Ok(response);
        }
        #endregion
    }
}
