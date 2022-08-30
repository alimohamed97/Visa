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

namespace Visa.Portal.Controllers
{
    public class BlogsController : Controller
    {
        #region Fields

        private UnitOfWork UnitOfWork;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor

        public BlogsController(ApplicationContext context, IMapper mapper)
        {
            this.UnitOfWork = new UnitOfWork(context);
            this._mapper = mapper;
        }

        #endregion
        public async Task<IActionResult> Index()
        {
            var Blog = await UnitOfWork.BlogsRepository.GetAsync(includeProperties: "Author,Category");
            var model = _mapper.Map<IEnumerable<BlogsVM>>(Blog);
            
            
            //var Dpt = await UnitOfWork.AuthorRepository.GetAsync();
            //ViewBag.AuthorList = new SelectList(Dpt, "Id", "Name_Ar",model.);

            return View(model);
        }

        public async Task<IActionResult> Create()
        {

            var data = await UnitOfWork.AuthorRepository.GetAsync();
            ViewBag.AuthortList = new SelectList(data, "Id", "Name_En");
            var datas = await UnitOfWork.CategoryRepository.GetAsync();
            ViewBag.CategoryList = new SelectList(datas, "Id", "Title_En");

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(BlogsVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var Blog = _mapper.Map<Blogs>(model);
                    Blog.ImageName = FileUploader.UploadFile("Imgs", model.Image);

                    await UnitOfWork.BlogsRepository.InsertAsync(Blog);
                    UnitOfWork.Save();
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }



           
            var Dpt = await UnitOfWork.AuthorRepository.GetAsync();
            ViewBag.AuthorList = new SelectList(Dpt, "Id", "Name_Ar", model.Author);
            return View(model);
           


        }
        public async Task<IActionResult> EditBlogs(int id)
        {

            var landing = await UnitOfWork.BlogsRepository.GetByIDAsync(a => a.Id == id, includeProperties: "Author,Category");
            var model = _mapper.Map<BlogsVM>(landing);

            var Authorentity = await UnitOfWork.AuthorRepository.GetAsync();
            var Authormodel = _mapper.Map<IEnumerable<AuthorVM>>(Authorentity);

            ViewBag.AuthorList = new SelectList(Authormodel, "Id", "Name_En");


            var Categoryentity = await UnitOfWork.CategoryRepository.GetAsync();
            var Categorymodel = _mapper.Map<IEnumerable<CategoryVM>>(Categoryentity);

            ViewBag.CategoryList = new SelectList(Categorymodel, "Id", "Title_En");
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult>EditBlogs(BlogsVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Image != null)
                    {
                        FileUploader.RemoveFile("Imgs", model.ImageName);

                        var blogs = _mapper.Map<Blogs>(model);
                        blogs.ImageName = FileUploader.UploadFile("Imgs", model.Image);

                        UnitOfWork.BlogsRepository.Update(blogs);
                    }
                    else
                    {
                        var blogs = _mapper.Map<Blogs>(model);
                        blogs.ImageName = model.ImageName;
                        UnitOfWork.BlogsRepository.Update(blogs);
                    }


                    UnitOfWork.Save();
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
                var auth = await UnitOfWork.BlogsRepository.GetByIDAsync(a => a.Id == id);



                await UnitOfWork.BlogsRepository.DeleteAsync(auth.Id);
            }

            await UnitOfWork.SaveAsync();

            return RedirectToAction("Index");
        }
        #region Ajax Call

        [HttpPost]
        public async Task<JsonResult> GetBlogsById(int id)
        {
            var entity = await UnitOfWork.BlogsRepository.GetByIDAsync(a => a.Id == id);
            var model = _mapper.Map<BlogsVM>(entity);

            return Json(model);
        }


        #endregion
    }
}

