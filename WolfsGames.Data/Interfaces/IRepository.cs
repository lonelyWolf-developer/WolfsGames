using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfsGames.Data.Interfaces
{
	public interface IRepository<TEntity>
	{
		List<TEntity> GetAll();
		TEntity FindById(int id);
		TEntity FindByUrl(string url);
		void Insert(TEntity entity);
		void Update(TEntity entity);
		void Delete(int id);
	}
}
