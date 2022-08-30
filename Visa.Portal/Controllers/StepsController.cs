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
    public class StepsController : Controller
    {
          #region Fields

        private UnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        #endregion


        #region Ctor

        public StepsController(ApplicationContext context, IMapper mapper)
        {
            this.unitOfWork = new UnitOfWork(context);
            this._mapper = mapper;
        }

        #endregion


        #region Actions

        public async Task<IActionResult> Index()
        {
            var entity = await unitOfWork.StepsRepository.GetAsync();
            var model = _mapper.Map<IEnumerable<StepsVM>>(entity);
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(StepsVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Image != null)
                    {
                        FileUploader.RemoveFile("Imgs", model.ImageName);

                        var steps = _mapper.Map<Steps>(model);
                        steps.ImageName = FileUploader.UploadFile("Imgs", model.Image);

                        unitOfWork.StepsRepository.Update(steps);
                    }
                    else
                    {
                        var steps = _mapper.Map<Steps>(model);
                         steps.ImageName = model.ImageName;
                        unitOfWork.StepsRepository.Update( steps);
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
        public async Task<JsonResult> GetStepsById(int id)
        {
            var entity = await unitOfWork.StepsRepository.GetByIDAsync(a=>a.Id == id);
            var model = _mapper.Map<StepsVM>(entity);

            return Json(model);
        }


        #endregion
    }
}
