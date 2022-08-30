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
    public class ContactBannerController : Controller
    {
        #region Fields

        private UnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor

        public ContactBannerController(ApplicationContext context, IMapper mapper)
        {
            this.unitOfWork = new UnitOfWork(context);
            this._mapper = mapper;
        }

        #endregion
        #region Actions
        public async Task<IActionResult> Index()
        {
            var entity = await unitOfWork.ContactBannerRepository.GetAsync();
            var model = _mapper.Map<IEnumerable<ContactBannerVM>>(entity);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ContactBannerVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Image != null)
                    {
                        FileUploader.RemoveFile("Imgs", model.ImageName);

                        var ContactBab = _mapper.Map<ContactBanner>(model);
                        ContactBab.ImageName = FileUploader.UploadFile("Imgs", model.Image);

                        unitOfWork.ContactBannerRepository.Update(ContactBab);
                    }
                    else
                    {
                        var ContactBan = _mapper.Map<ContactBanner>(model);
                        ContactBan.ImageName = model.ImageName;
                        unitOfWork.ContactBannerRepository.Update(ContactBan);
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
        public async Task<JsonResult> GetContactBanById(int id)
        {
            var entity = await unitOfWork.ContactBannerRepository.GetByIDAsync(a => a.Id == id);
            var model = _mapper.Map<ContactBannerVM>(entity);

            return Json(model);
        }


        #endregion
    }
}
