using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Visa.BL.Models;
using Visa.BL.Repository;
using Visa.DAL.Database;
using Visa.DAL.Entity;

namespace Visa.Portal.Controllers
{
    public class HomeTestimonialsController : Controller
    {
        #region Fields

        private UnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        #endregion
        #region Ctor

        public HomeTestimonialsController(ApplicationContext context, IMapper mapper)
        {
            this.unitOfWork = new UnitOfWork(context);
            this._mapper = mapper;
        }

        #endregion
        #region Actions
        public async Task<IActionResult> Index()
        {
            var entity = await unitOfWork.HomeTestimonialsRepository.GetAsync();
            var model = _mapper.Map<IEnumerable<HomeTestimonialsVM>>(entity);
          
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(HomeTestimonialsVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                  
                    
                        var Testimonials = _mapper.Map<HomeTestimonials>(model);
                        Testimonials.Title_Ar = model.Title_Ar;
                           Testimonials.Title_Ar = model.Title_Ar;
                         unitOfWork.HomeTestimonialsRepository.Update(Testimonials);
                    


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
        public async Task<JsonResult> GetTestMonialsById(int id)
        {
            var entity = await unitOfWork.HomeTestimonialsRepository.GetByIDAsync(a => a.Id == id);
            var model = _mapper.Map<HomeTestimonialsVM>(entity);

            return Json(model);
        }


        #endregion

    }
}
