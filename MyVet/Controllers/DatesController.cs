using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class DatesController : Controller
    {
        #region Attribute
        private readonly IDatesServices _datesServices;
        #endregion

        #region Buider
        public DatesController(IDatesServices datesServices)
        {
            _datesServices = datesServices;
        }
        #endregion
        [HttpGet]
        public IActionResult Index()
        { 
            return View();
        }
        [HttpGet]
        public IActionResult GetAllMyDates()
        {
            var user = HttpContext.User;
            string idUser = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.IdUser).Value;

            List<DatesDto> list = _datesServices.GetAllMyDates(Convert.ToInt32(idUser));
            return Ok(list);
        }
        [HttpGet]
        public IActionResult GetAllServices()
        {
            List<ServicesDto> response = _datesServices.GetAllServices();
            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetAllNamePets()
        {
            List<PetDto> response = _datesServices.GetAllNamePets();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertDate(DatesDto dates)
        {
            bool response = await _datesServices.InsertDateAsync(dates);
            return Ok(response);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteDate(int idDate)
        {
            ResponseDto response = await _datesServices.DeleteDateAsync(idDate);
            return Ok(response);
        }

    }
}
