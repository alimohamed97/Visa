using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Visa.BL.Helper;
using Visa.BL.Models;
using Visa.BL.Repository;
using Visa.DAL.Database;
using Visa.DAL.Entity;

namespace Visa.Portal.Controllers
{
    public class MainController : Controller
    {


        #region Fields

        private UnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        #endregion


        #region Ctor

        public MainController(ApplicationContext context, IMapper mapper)
        {
            this.unitOfWork = new UnitOfWork(context);
            this._mapper = mapper;
        }

        #endregion


        #region Actions

        public async Task<IActionResult> Index()
        {
            var entity = await unitOfWork.HaderRepository.GetAsync();
            var model = _mapper.Map<IEnumerable<HeaderVM>>(entity);
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(HeaderVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if(model.Image != null)
                    {
                        FileUploader.RemoveFile("Imgs", model.ImageName);

                        var header = _mapper.Map<Header>(model);
                        header.ImageName = FileUploader.UploadFile("Imgs", model.Image);

                        unitOfWork.HaderRepository.Update(header);
                    }
                    else
                    {
                        var header = _mapper.Map<Header>(model);
                        header.ImageName = model.ImageName;
                        unitOfWork.HaderRepository.Update(header);
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
        public async Task<JsonResult> GetHeaderById(int id)
        {
            var entity = await unitOfWork.HaderRepository.GetByIDAsync(a => a.Id == id);
            var model = _mapper.Map<HeaderVM>(entity);

            return Json(model);
        }


        #endregion
    }
}
