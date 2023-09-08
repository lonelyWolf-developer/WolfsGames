using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolfsGames.Data.Interfaces;

namespace WolfsGames.Data.Repositories
{
	public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		protected DbContext webContext;
		protected DbSet<TEntity> dbSet;

		public BaseRepository(ApplicationDbContext context)
		{
			webContext = context;

			dbSet = webContext.Set<TEntity>();
		}


		public void Delete(int id)
		{
			TEntity entity = dbSet.Find(id);
			try
			{
				dbSet.Remove(entity);
				webContext.SaveChanges();
			}
			catch (Exception)
			{
				webContext.Entry(entity).State = EntityState.Unchanged;
				throw;
			}
		}

		public TEntity FindById(int id)
		{
			return dbSet.Find(id);
		}

		public List<TEntity> GetAll()
		{
			return dbSet.ToList();
		}

		public void Insert(TEntity entity)
		{
			dbSet.Add(entity);
			webContext.SaveChanges();
		}

		public void Update(TEntity entity)
		{
			if (dbSet.Contains(entity))
			{
				dbSet.Update(entity);
			}
			else
			{
				dbSet.Add(entity);
			}

			webContext.SaveChanges();
		}
	}
}
