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
    public class AuthorController : Controller
    {
        #region Fields

        private UnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor

        public AuthorController(ApplicationContext context, IMapper mapper)
        {
            this.unitOfWork = new UnitOfWork(context);
            this._mapper = mapper;
        }

        #endregion
        #region Actions

        public async Task<IActionResult> Index()
        {
            var entity = await unitOfWork.AuthorRepository.GetAsync();
            var model = _mapper.Map<IEnumerable<AuthorVM>>(entity);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AuthorVM model)
        {



            var Auth = _mapper.Map<Author>(model);
            Auth.ImageName = FileUploader.UploadFile("Imgs", model.Image);

            await unitOfWork.AuthorRepository.InsertAsync(Auth);


            unitOfWork.Save();
            return RedirectToAction("Index");


        }


        [HttpPost]
        public async Task<IActionResult> Edit(AuthorVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Image != null)
                    {
                        FileUploader.RemoveFile("Imgs", model.ImageName);

                        var Auth = _mapper.Map<Author>(model);
                        Auth.ImageName = FileUploader.UploadFile("Imgs", model.Image);

                        unitOfWork.AuthorRepository.Update(Auth);
                    }
                    else
                    {
                        var auth = _mapper.Map<Author>(model);
                        auth.ImageName = model.ImageName;
                        unitOfWork.AuthorRepository.Update(auth);
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
                var auth = await unitOfWork.AuthorRepository.GetByIDAsync(a => a.Id == id);

                

                await unitOfWork.AuthorRepository.DeleteAsync(auth.Id);
            }

            await unitOfWork.SaveAsync();

            return RedirectToAction("Index");
        }
        #endregion


        #region Ajax Call

        [HttpPost]
        public async Task<JsonResult> GetAuthorById(int id)
        {
            var entity = await unitOfWork.AuthorRepository.GetByIDAsync(a => a.Id == id);
            var model = _mapper.Map<AuthorVM>(entity);

            return Json(model);
        }


        #endregion
    }
}
