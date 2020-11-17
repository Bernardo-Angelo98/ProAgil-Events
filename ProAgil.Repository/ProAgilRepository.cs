using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public class ProAgilRepository : IProAgilRepository
    {
        public readonly ProAgilContext _context;
        public ProAgilRepository(ProAgilContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        //Gerais
        void IProAgilRepository.Add<T>(T entity)
        {
            _context.Add(entity);
        }

        void IProAgilRepository.Delete<T>(T entity)
        {
            _context.Update(entity);
        }
        void IProAgilRepository.Update<T>(T entity)
        {
            _context.Remove(entity);   
        }
        async Task<bool> IProAgilRepository.SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        //EVENTO
        async Task<Evento[]> IProAgilRepository.GetAllEventoAsyncBy(bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(c => c.Lote)
                .Include(c => c.RedesSociais);
          if(includePalestrantes){
              query = query
              .Include(pe => pe.PalestranteEventos)
              .ThenInclude(p => p.Palestrante);
          }

          query = query.AsNoTracking()
          .OrderByDescending(c => c.DataEvento);

          return await query.ToArrayAsync();     
        }

        async Task<Evento> IProAgilRepository.GetAllEventoAsyncById(int eventoId, bool includePalestrantes)
        {
           IQueryable<Evento> query = _context.Eventos
                .Include(c => c.Lote)
                .Include(c => c.RedesSociais);
          if(includePalestrantes){
              query = query
              .Include(pe => pe.PalestranteEventos)
              .ThenInclude(p => p.Palestrante);
          }

          query = query.AsNoTracking()
                    .Where(c => c.Id == eventoId)
                    .OrderByDescending(c => c.DataEvento);

          return await query.FirstOrDefaultAsync();
        }

        async Task<Evento[]> IProAgilRepository.GetAllEventoAsyncByTema(string tema, bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(c => c.Lote)
                .Include(c => c.RedesSociais);
          if(includePalestrantes){
              query = query
              .Include(pe => pe.PalestranteEventos)
              .ThenInclude(p => p.Palestrante);
          }

          query = query.AsNoTracking()
                    .Where(c => c.Tema.ToLower().Contains(tema.ToLower()))
                    .OrderByDescending(c => c.DataEvento);

          return await query.ToArrayAsync();
        }

        //PALESTRANTE
        async Task<Palestrante> IProAgilRepository.GetAllPalestranteAsyncBy(int palestranteId, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(c => c.RedesSociais);
          if(includeEventos){
              query = query
              .Include(pe => pe.PalestranteEventos)
              .ThenInclude(e => e.Evento);
          }

          query = query.AsNoTracking()
                    .Where(p => p.Id == palestranteId)
                    .OrderBy(p => p.Nome);

          return await query.FirstOrDefaultAsync();
        }

        async Task<Palestrante[]> IProAgilRepository.GetAllPalestranteAsyncByName(string nome, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(c => c.RedesSociais);
          if(includeEventos){
              query = query
              .Include(pe => pe.PalestranteEventos)
              .ThenInclude(e => e.Evento);
          }

          query = query.AsNoTracking()
                        .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));
          

          return await query.ToArrayAsync();
        }


    }
}