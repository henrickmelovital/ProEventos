using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Context;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class EventoPersist : IEventoPersist
    {
        private readonly AppDbContext _appDbContext;

        public EventoPersist(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            // _appDbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _appDbContext.Eventos
                .Include(E => E.Lotes)
                .Include(E => E.RedesSociais);

            if (includePalestrantes)
            {
                query = query
                    .Include(E => E.PalestrantesEventos)
                    .ThenInclude(PE => PE.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(E => E.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _appDbContext.Eventos
                .Include(E => E.Lotes)
                .Include(E => E.RedesSociais);

            if (includePalestrantes)
            {
                query = query
                    .Include(E => E.PalestrantesEventos)
                    .ThenInclude(PE => PE.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(E => E.Id)
                .Where(E => E.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventosByIdAsync(int EventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _appDbContext.Eventos
                .Include(E => E.Lotes)
                .Include(E => E.RedesSociais);

            if (includePalestrantes)
            {
                query = query
                    .Include(E => E.PalestrantesEventos)
                    .ThenInclude(PE => PE.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(E => E.Id)
                .Where(E => E.Id == EventoId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
