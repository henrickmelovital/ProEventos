using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    internal interface IPalestrantePersist
    {
        // PALESTRANTES:
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string Nome, bool includeEventos);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);
        Task<Palestrante> GetPalestrantesByIdAsync(int PalestranteId, bool includeEventos);
    }
}
