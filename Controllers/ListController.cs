using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using MVC_ToDoList.Context;
using MVC_ToDoList.Models;

namespace MVC_ToDoList.Controllers
{
    public class ListController : Controller
    {
        protected readonly MVCTodoListContext _context;
        protected IQueryable<ListModel> _query;

        public ListController(MVCTodoListContext context)
        {
            _context = context;
            _query = _context.Set<ListModel>();
        }

        public IActionResult List()
        {
            var query = _query;

            return View(_query);
        }        

        public ActionResult Create(long? id)
        {
            ListModel model = new ListModel();

            if (id.HasValue)
            {
                var retorno = _query.SingleOrDefault(x => x.Id == id.Value);
                
                model = retorno;
            }
            
            return View(model);
        }

        public ActionResult Save(ListModel model)
        {
            if (model.Id > 0)
            {
                var local = _query.SingleOrDefault(x => x.Id == model.Id);

                if (local == null)
                    ModelState.AddModelError("", "Erro ao alterar o registro");

                local.Titulo = model.Titulo;
                local.Anotacao = model.Anotacao;

                _context.SaveChanges();
            }
            else
            {
                _context.ListModels.Add(model);

                _context.SaveChanges();

            }

            return RedirectToAction("List");
        }

        public ActionResult Delete(long id)
        {
            var item = _query.SingleOrDefault(x => x.Id == id);

            _context.Remove(item);

            _context.SaveChanges();

            return RedirectToAction("List");
        }
    }
}
