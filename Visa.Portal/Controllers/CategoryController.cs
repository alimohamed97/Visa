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
    public class CategoryController : Controller
    {
        #region Fields

        private UnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor

        public CategoryController(ApplicationContext context, IMapper mapper)
        {
            this.unitOfWork = new UnitOfWork(context);
            this._mapper = mapper;
        }

        #endregion




        #region Actions

        public async Task<IActionResult> Index()
        {
            var entity = await unitOfWork.CategoryRepository.GetAsync();
            var model = _mapper.Map<IEnumerable<CategoryVM>>(entity);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryVM model)
        {



            var Cat = _mapper.Map<Category>(model);
            Cat.Title_Ar = model.Title_Ar;
            Cat.Title_En = model.Title_En;

            await unitOfWork.CategoryRepository.InsertAsync(Cat);


            unitOfWork.Save();
            return RedirectToAction("Index");


        }


        [HttpPost]
        public async Task<IActionResult> Edit(CategoryVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                  
                    
                    
                        var Cat = _mapper.Map<Category>(model);
                          Cat.Title_Ar = model.Title_Ar;
                          Cat.Title_En = model.Title_En;

                    unitOfWork.CategoryRepository.Update(Cat);
                    


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
                var Testimon = await unitOfWork.CategoryRepository.GetByIDAsync(a => a.Id == id);

                

                await unitOfWork.CategoryRepository.DeleteAsync(Testimon.Id);
            }

            await unitOfWork.SaveAsync();

            return RedirectToAction("Index");
        }
        #endregion


        #region Ajax Call

        [HttpPost]
        public async Task<JsonResult> GetCategoryById(int id)
        {
            var entity = await unitOfWork.CategoryRepository.GetByIDAsync(a => a.Id == id);
            var model = _mapper.Map<CategoryVM>(entity);

            return Json(model);
        }


        #endregion
    }
}
