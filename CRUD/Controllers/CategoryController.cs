using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD.Models;

namespace CRUD.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            List<Category> categories = CategoryDataContext.LoadCategories();
            return View(categories);
        }
        /// <summary>
        /// checkbox批次刪除
        /// </summary>
        /// <returns></returns>
       
        [HttpPost]
        public ActionResult CheckBoxBatchDelete(int[] arrayOfValues)
        {
            
            return RedirectToAction("Index");
        }
       
        //新增產品分類
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert()
        {
            Category _category = new Category();
            _category.CategoryName = Request.Form["CategoryName"];
            _category.Description = Request.Form["Description"];
            CategoryDataContext.InsertCategory(_category);
            return RedirectToAction("Index");
        }
        //取得修改產品前產品分類資料
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Category _category = CategoryDataContext.LoadCategoryByID(id);
            return View(_category);
        }
        //取得修改後資料
        [HttpPost]
        public ActionResult Edit()
        {
            Category _category = new Category();
            _category.CategoryID = Convert.ToInt32(Request.Form["CategoryID"]);
            _category.CategoryName = Request.Form["CategoryName"];
            _category.Description = Request.Form["Description"];

            CategoryDataContext.EditCategory(_category);
            return RedirectToAction("Index");

        }
        //刪除產品分類
        public ActionResult Delete(int id)
        {
            CategoryDataContext.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}