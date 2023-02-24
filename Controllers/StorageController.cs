using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication_CW_11_1.DAL;
using WebApplication_CW_11_1.Models;

namespace WebApplication_CW_11_1.Controllers
{
    public class StorageController : Controller
    {   
        private readonly IProductsRepository _productsRepository;

        public StorageController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        public ActionResult List(int IdCategory)
        {
            var y = (_productsRepository.GetAllCategories());
            var z = y.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Type });
            ViewBag.Cat = z;
            if(IdCategory!=0)
            {
              return View(_productsRepository.GetAll().Where(x => x.Category.Id == IdCategory).ToList());
              
            }
            return View(_productsRepository.GetAll());

        }
       

        // GET: StorageController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: StorageController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StorageController1/Create
        public ActionResult Create()
        {

            var y = (_productsRepository.GetAllCategories());
            var z = y.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Type }) ;
            ViewBag.Cat = z;
            ViewBag.Emad = "ali";
            return View();
        }

        // POST: StorageController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product,int Cat)
        {   
            var ListId = _productsRepository.GetAll().Select(x => x.Id).ToList();
            var max = ListId.Max();
            product.Category = _productsRepository.GetCategoryById(Cat);
            product.Id = max + 1;
            _productsRepository.Create(product);
            return RedirectToAction("List");
        }
        

        // GET: StorageController1/Edit/5
        public ActionResult Edit(int id)
        {
            var y = (_productsRepository.GetAllCategories());
            var z = y.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Type });
            ViewBag.Cat = z;

            var result = _productsRepository.GetById(id);
            return View(result);
        }

        // POST: StorageController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product,int Cat)
        {
            product.Category = _productsRepository.GetCategoryById(Cat);
            _productsRepository.Update(product);

            return RedirectToAction("List");

        }

        // GET: StorageController1/Delete/5
        public ActionResult Delete(int id)
        {
            _productsRepository.Delete(id);

            return RedirectToAction("List");
        }


        public ActionResult Sell(int id)
        {
            _productsRepository.SellProduct(id);
            return RedirectToAction("List");
        }

        // POST: StorageController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
