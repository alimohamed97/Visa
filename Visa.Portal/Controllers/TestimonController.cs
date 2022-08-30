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
    public class TestimonController : Controller
    {
        #region Fields

        private UnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor

        public TestimonController(ApplicationContext context, IMapper mapper)
        {
            this.unitOfWork = new UnitOfWork(context);
            this._mapper = mapper;
        }

        #endregion
        #region Actions

        public async Task<IActionResult> Index()
        {
            var entity = await unitOfWork.TestimonialsRepository.GetAsync();
            var model = _mapper.Map<IEnumerable<TestimonialsVM>>(entity);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TestimonialsVM model)
        {



            var Landing = _mapper.Map<Testimonials>(model);
            Landing.ImageName = FileUploader.UploadFile("Imgs", model.Image);

            await unitOfWork.TestimonialsRepository.InsertAsync(Landing);


            unitOfWork.Save();
            return RedirectToAction("Index");


        }

       
        [HttpPost]
        public async Task<IActionResult> Edit(TestimonialsVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Image != null)
                    {
                        FileUploader.RemoveFile("Imgs", model.ImageName);

                        var Testimon = _mapper.Map<Testimonials>(model);
                        Testimon.ImageName = FileUploader.UploadFile("Imgs", model.Image);

                        unitOfWork.TestimonialsRepository.Update(Testimon);
                    }
                    else
                    {
                        var Testimon = _mapper.Map<Testimonials>(model);
                        Testimon.ImageName = model.ImageName;
                        unitOfWork.TestimonialsRepository.Update(Testimon);
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
        
        public async Task<IActionResult> DeLete(int? id)
        {

            if (id != null)
            {
                var Testimon = await unitOfWork.TestimonialsRepository.GetByIDAsync(a => a.Id == id);

                //foreach (var item in landing.StampedVisa)
                //{
                //    await UnitOfWork.StampedVisaRepository.DeleteAsync(item.Id);
                //}
                //foreach (var item in landing.FaQuestion)
                //{
                //    await UnitOfWork.FaQuestionRepository.DeleteAsync(item.Id);
                //}

                await unitOfWork.TestimonialsRepository.DeleteAsync(Testimon.Id);
            }

            await unitOfWork.SaveAsync();

            return RedirectToAction("Index");
        }
        #endregion


        #region Ajax Call

        [HttpPost]
        public async Task<JsonResult> GetTestimonialsById(int id)
        {
            var entity = await unitOfWork.TestimonialsRepository.GetByIDAsync(a => a.Id == id);
            var model = _mapper.Map<TestimonialsVM>(entity);

            return Json(model);
        }


        #endregion
    }
}
