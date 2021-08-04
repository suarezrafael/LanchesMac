using LanchesMac.Repositories;
using LanchesMac.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LanchesMac.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public LancheController(ILancheRepository lancheRepository, ICategoriaRepository categoriaRepository )
        {
            _lancheRepository = lancheRepository;
            _categoriaRepository = categoriaRepository;
        }

        public IActionResult List()
        {
            var lanches = _lancheRepository.Lanches;
            var lancheListViewModel = new LancheListViewModel();
            lancheListViewModel.Lanches = lanches;
            lancheListViewModel.CategoriaAtual = "Categoria Atual";
            return View(lancheListViewModel);
        }
    }
}
