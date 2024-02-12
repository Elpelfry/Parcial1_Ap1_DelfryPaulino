using Microsoft.EntityFrameworkCore;
using Parcial1_Ap1_DelfryPaulino.DAL;
using Parcial1_Ap1_DelfryPaulino.Models;
using System.Linq.Expressions;

namespace Parcial1_Ap1_DelfryPaulino.Services;

public class MestasService
{
    private readonly Contexto _contexto;

    public MestasService(Contexto contexto)
    {
        _contexto = contexto;
    }
    public async Task<bool> Guardar(Metas meta)
    {
        if (!await Existe(meta.MetaId))
            return await Insertar(meta);
        else
            return await Modificar(meta);
    }
    public async Task<bool> Existe(int metaid)
    {
        return await _contexto.Metas.AnyAsync(m => m.MetaId == metaid);
    }

    public async Task<bool> Insertar(Metas meta)
    {
        _contexto.Add(meta);
        return await _contexto.SaveChangesAsync()>0;
    }

    public async Task<bool> Modificar(Metas meta)
    {
        _contexto.Update(meta);
        int cambio = await _contexto.SaveChangesAsync();
        _contexto.Entry(meta).State = EntityState.Detached;
        return cambio > 0;
    }
    public async Task<Metas?> Buscar(int metaid)
    {
        return await _contexto.Metas.
            AsNoTracking().
            FirstOrDefaultAsync(m => m.MetaId == metaid);
    }

    public async Task<bool> Eliminar(Metas meta)
    {
        return await _contexto.Metas.
            Where(m => m.MetaId == meta.MetaId)
            .ExecuteDeleteAsync() > 0;  
    }

    public async Task<List<Metas>> Listar(Expression<Func<Metas, bool>> criterio)
    {
        return await _contexto.Metas.
            AsNoTracking().
            Where(criterio).
            ToListAsync();  
    }

}
