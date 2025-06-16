using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoPizza.Models;
using ContosoPizza.Services;

namespace ContosoPizza.Pages
{
    public class PizzaListModel : PageModel
    {
        private readonly PizzaService _service;
        public IList<Pizza> PizzaList { get; set; } = default!;

        [BindProperty]
        public Pizza NewPizza { get; set; } = default!;

        public PizzaListModel(PizzaService service)
        {
            _service = service;
        }

        public void OnGet(int? id)
        {
            PizzaList = _service.GetPizzas();
            NewPizza = new Pizza();

            if (id.HasValue && id.Value > 0)
            {
                NewPizza = _service.GetPizza(id.Value);
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || NewPizza == null)
            {
                PizzaList = _service.GetPizzas();
                return Page();
            }

            if (NewPizza.Id > 0)
            {
                _service.UpdatePizza(NewPizza);
            }
            else
            {
                _service.AddPizza(NewPizza);
            }

            return RedirectToPage("./PizzaList", NewPizza = new Pizza());
        }

        public IActionResult OnPostDelete(int id)
        {
            _service.DeletePizza(id);

            return RedirectToAction("Get");
        }
    }
}
