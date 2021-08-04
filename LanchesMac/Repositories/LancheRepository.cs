using LanchesMac.Context;
using LanchesMac.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanchesMac.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        private readonly AppDbContext _appDbContext;

        public LancheRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Lanche> Lanches => _appDbContext.Lanches.Include(c=>c.Categoria);

        public IEnumerable<Lanche> LanchesPreferidos => _appDbContext.Lanches.Where(l=>l.IsLanchePreferido).Include(c=>c.Categoria);

        public Lanche GetLancheById(int lancheId)
        {
            return _appDbContext.Lanches.FirstOrDefault(f=>f.LancheId == lancheId);
        }
    }
}
