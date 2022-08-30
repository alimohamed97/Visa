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
    public class ContactController : Controller
    {

        #region Fields

        private UnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        #endregion


        #region Ctor

        public ContactController(ApplicationContext context, IMapper mapper)
        {
            this.unitOfWork = new UnitOfWork(context);
            this._mapper = mapper;
        }

        #endregion


        #region Actions

        public async Task<IActionResult> Index()
        {
            var entity = await unitOfWork.ContactRepository.GetAsync();
            var model = _mapper.Map<IEnumerable<ContactVM>>(entity);
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(ContactVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Image != null)
                    {
                        FileUploader.RemoveFile("Imgs", model.ImageName);

                        var contact = _mapper.Map<Contact>(model);
                        contact.ImageName = FileUploader.UploadFile("Imgs", model.Image);

                        unitOfWork.ContactRepository.Update(contact);
                    }
                    else
                    {
                        var contact = _mapper.Map<Contact>(model);
                        contact.ImageName = model.ImageName;
                        unitOfWork.ContactRepository.Update(contact);
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
        public async Task<JsonResult> GetContactById(int id)
        {
            var entity = await unitOfWork.ContactRepository.GetByIDAsync(a => a.Id == id);
            var model = _mapper.Map<ContactVM>(entity);

            return Json(model);
        }


        #endregion

    }
}
