using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Visa.BL.Helper;
using Visa.BL.Models;
using Visa.BL.Repository;
using Visa.DAL.Database;
using Visa.DAL.Entity;
//using Visa.DAL.Entity.LandPage;

namespace Visa.Portal.Controllers
{
    public class LandingController : Controller
    {
        #region Fields

        private UnitOfWork UnitOfWork;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor

        public LandingController(ApplicationContext context, IMapper mapper)
        {
            this.UnitOfWork = new UnitOfWork(context);
            this._mapper = mapper;
        }

        #endregion

        #region Actions
        public async Task<IActionResult> Index()
        {
            var landing = await UnitOfWork.LandingRepository.GetAsync(includeProperties: "StampedVisa,FaQuestion");
            var model = _mapper.Map<IEnumerable<LandingVm>>(landing);
            

            return View(model);
        }

        public async Task<IActionResult> CreateLand() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateLand(LandingVm model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    model.ImageName = FileUploader.UploadFile("Imgs", model.Image);

                    if(model.StampedVisa != null)
                    {
                        for (int i = 0; i < model.StampedVisa.Count; i++)
                        {
                            model.StampedVisa[i].ImageName = FileUploader.UploadFile("Imgs", model.StampedVisa[i].Image);
                        }

                        for (int i = 0; i < model.StampedVisa.Count; i++)
                        {
                            model.StampedVisa[i].LandingId = model.Id;
                        }
                    }

                    if (model.FaQuestion != null)
                    {
                        for (int i = 0; i < model.FaQuestion.Count; i++)
                        {
                            model.FaQuestion[i].LandingId = model.Id;
                        }
                    }

                    var data = _mapper.Map<Landing>(model);

                    await UnitOfWork.LandingRepository.InsertAsync(data);

                    await UnitOfWork.SaveAsync();
                    return RedirectToAction("Index");
                }

            }
            catch(Exception ex)
            {

            }

            return View(model);

        }


        public async Task<IActionResult> Edit(int id)
        {

            var landing = await UnitOfWork.LandingRepository.GetByIDAsync(a=>a.Id == id,includeProperties: "StampedVisa,FaQuestion,StampedVisa.LookUpValue");
            var model = _mapper.Map<LandingVm>(landing);

            var stepentity = await UnitOfWork.LookupValueRepository.GetAsync(a => a.ParentId == 1);
            var stepmodel = _mapper.Map<IEnumerable<LookUpValueVM>>(stepentity);

            ViewBag.StepList = new SelectList(stepmodel, "Id", "Name_En");
            return View(model);
        }


        [HttpPost]
        public IActionResult Edit(LandingVm model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if(model.Image != null)
                    {
                        model.ImageName = FileUploader.UploadFile("Imgs", model.Image);
                    }

                    if (model.StampedVisa != null)
                    {
                        for (int i = 0; i < model.StampedVisa.Count; i++)
                        {
                            if(model.StampedVisa[i].Image != null)
                            {
                                model.StampedVisa[i].ImageName = FileUploader.UploadFile("Imgs", model.StampedVisa[i].Image);
                            }
                        }

                        for (int i = 0; i < model.StampedVisa.Count; i++)
                        {
                            model.StampedVisa[i].LandingId = model.Id;
                        }
                    }

                    if (model.FaQuestion != null)
                    {
                        for (int i = 0; i < model.FaQuestion.Count; i++)
                        {
                            model.FaQuestion[i].LandingId = model.Id;
                        }
                    }

                    var data = _mapper.Map<Landing>(model);

                    UnitOfWork.LandingRepository.Update(data);

                    foreach (var item in data.FaQuestion)
                    {
                        UnitOfWork.FaQuestionRepository.Update(item);
                    }

                    foreach (var item in data.StampedVisa)
                    {
                        UnitOfWork.StampedVisaRepository.Update(item);
                    }

                    UnitOfWork.Save();
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {

            }

            return View(model);

        }



        public async Task<IActionResult> DeLete(int? id)
        {

            if(id != null)
            {
                var landing = await UnitOfWork.LandingRepository.GetByIDAsync(a => a.Id == id, includeProperties: "StampedVisa,FaQuestion,StampedVisa.LookUpValue");

                foreach (var item in landing.StampedVisa)
                {
                    await UnitOfWork.StampedVisaRepository.DeleteAsync(item.Id);
                }
                foreach (var item in landing.FaQuestion)
                {
                    await UnitOfWork.FaQuestionRepository.DeleteAsync(item.Id);
                }

                await UnitOfWork.LandingRepository.DeleteAsync(landing.Id);
            }

            await UnitOfWork.SaveAsync();

            return RedirectToAction("Index");
        }

        

        #endregion

        #region Ajax Call

        [HttpPost]
        public async Task<JsonResult> GetLandingById(int id)
        {
            var entity = await UnitOfWork.LandingRepository.GetByIDAsync(a => a.Id == id);
            var model = _mapper.Map<LandingVm>(entity);

            return Json(model);
        }

        [HttpPost]
        public async Task<JsonResult> GetSteps()
        {
            var entity = await UnitOfWork.LookupValueRepository.GetAsync(a=>a.ParentId == 1);
            var model = _mapper.Map<IEnumerable<LookUpValueVM>>(entity);

            return Json(model);
        }

        #endregion
    }

}
