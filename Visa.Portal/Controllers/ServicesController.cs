using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Visa.BL.Helper;
using Visa.BL.Models;
using Visa.BL.Repository;
using Visa.DAL.Database;
using Visa.DAL.Entity;

namespace Visa.Portal.Controllers
{
    public class ServicesController : Controller
    {

        #region Fields

        private UnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        #endregion


        #region Ctor

        public ServicesController(ApplicationContext context, IMapper mapper)
        {
            this.unitOfWork = new UnitOfWork(context);
            this._mapper = mapper;
        }

        #endregion


        #region Actions

        public async Task<IActionResult> Index()
        {
            var entity = await unitOfWork.ServicesRepository.GetAsync();
            var model = _mapper.Map<IEnumerable<ServicesVM>>(entity);
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(ServicesVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Image != null)
                    {
                        FileUploader.RemoveFile("Imgs", model.ImageName);

                        var service = _mapper.Map<Services>(model);
                        service.ImageName = FileUploader.UploadFile("Imgs", model.Image);

                        unitOfWork.ServicesRepository.Update(service);
                    }
                    else
                    {
                        var service = _mapper.Map<Services>(model);
                        service.ImageName = model.ImageName;
                        unitOfWork.ServicesRepository.Update(service);
                    }


                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {

            }

            return RedirectToAction("Index");

        }

        #endregion


        #region Ajax Call

        [HttpPost]
        public async Task<JsonResult> GetServicesById(int id)
        {
            var entity = await unitOfWork.ServicesRepository.GetByIDAsync(a => a.Id == id);
            var model = _mapper.Map<ServicesVM>(entity);

            return Json(model);
        }


        #endregion
    }
}
