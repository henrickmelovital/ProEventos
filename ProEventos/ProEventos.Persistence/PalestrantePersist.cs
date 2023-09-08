using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Context;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class PalestrantePersist : IPalestrantePersist
    {
        private readonly AppDbContext _appDbContext;

        public PalestrantePersist(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includePalestrantes = false)
        {
            IQueryable<Palestrante> query = _appDbContext.Palestrantes
               .Include(P => P.RedesSociais);


            if (includePalestrantes)
            {
                query = query
                    .Include(P => P.PalestrantesEventos)
                    .ThenInclude(PE => PE.Evento);
            }

            query = query.AsNoTracking().OrderBy(P => P.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string Nome, bool includeEventos)
        {
            IQueryable<Palestrante> query = _appDbContext.Palestrantes
               .Include(P => P.RedesSociais);


            if (includeEventos)
            {
                query = query
                    .Include(P => P.PalestrantesEventos)
                    .ThenInclude(PE => PE.Evento);
            }

            query = query.AsNoTracking().OrderBy(P => P.Id)
                .Where(P => P.Nome.ToLower()
                .Contains(Nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestrantesByIdAsync(int palestranteId, bool includeEventos)
        {
            IQueryable<Palestrante> query = _appDbContext.Palestrantes
               .Include(P => P.RedesSociais);


            if (includeEventos)
            {
                query = query
                    .Include(P => P.PalestrantesEventos)
                    .ThenInclude(PE => PE.Evento);
            }

            query = query.AsNoTracking().OrderBy(P => P.Id)
                .Where(P => P.Id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
