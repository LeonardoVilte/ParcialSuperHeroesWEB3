using GestionSuperheroes.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GestionSuperheroes.Servicios
{
	public interface ILogica
	{
		Task<Superheroe> AgregarSuperheroe(Superheroe superheroe);
		Task<List<Superheroe>> ListarTodosLosSuperheroes();
		Task<List<Superheroe>> ListarSuperheroesPorUniverso(int idUniverso);
		Task<List<Universo>> ObtenerTodosLosUniversos();
		Task<Superheroe> EliminarSuperheroe(int idSuperheroe);

    }
	public class Logica : ILogica
	{
		private readonly SuperHeroeUniversoContext _context;

		public Logica(SuperHeroeUniversoContext context) 
		{ 
			_context = context;
		}

		public async Task<Superheroe> AgregarSuperheroe(Superheroe superheroe)
		{
			superheroe.Eliminado = false;
			_context.Superheroes.Add(superheroe);
			await _context.SaveChangesAsync();

			return superheroe;
		}

		public async Task<List<Superheroe>> ListarSuperheroesPorUniverso(int idUniverso)
		{
			return await _context.Superheroes
				.Include(s => s.IdUniversoNavigation)
				.Where(s => !s.Eliminado && s.IdUniverso == idUniverso)
				.ToListAsync();
		}

		public async Task<List<Superheroe>> ListarTodosLosSuperheroes()
		{
			return await _context.Superheroes
				.Include(s => s.IdUniversoNavigation)
				.Where(s => !s.Eliminado)
				.ToListAsync();
		}

		public async Task<List<Universo>> ObtenerTodosLosUniversos() 
		{ 
			return await _context.Universos
				.OrderBy(u => u.IdUniverso)
				.ToListAsync();
		}
		public async Task<Superheroe> EliminarSuperheroe(int idSuperheroe)
		{
			var superheroe = await _context.Superheroes.FindAsync(idSuperheroe);
			if (superheroe == null) {
				return null;
			}
			superheroe.Eliminado = true;
		
			await _context.SaveChangesAsync();
			return superheroe;
		}
	}
}
