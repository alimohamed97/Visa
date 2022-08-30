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
    public class AboutController : Controller
    {
        #region Fields

        private UnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        #endregion


        #region Ctor

        public AboutController(ApplicationContext context, IMapper mapper)
        {
            this.unitOfWork = new UnitOfWork(context);
            this._mapper = mapper;
        }

        #endregion


        #region Actions

        public async Task<IActionResult> Index()
        {
            var entity = await unitOfWork.AboutRepository.GetAsync();
            var model = _mapper.Map<IEnumerable<AboutVM>>(entity);
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(AboutVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Image != null)
                    {
                        FileUploader.RemoveFile("Imgs", model.ImageName);

                        var about = _mapper.Map<About>(model);
                        about.ImageName = FileUploader.UploadFile("Imgs", model.Image);

                        unitOfWork.AboutRepository.Update(about);
                    }
                    else
                    {
                        var about = _mapper.Map<About>(model);
                        about.ImageName = model.ImageName;
                        unitOfWork.AboutRepository.Update(about);
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
        public async Task<JsonResult> GetAboutById(int id)
        {
            var entity = await unitOfWork.AboutRepository.GetByIDAsync(a => a.Id == id);
            var model = _mapper.Map<AboutVM>(entity);

            return Json(model);
        }


        #endregion
    }
}
