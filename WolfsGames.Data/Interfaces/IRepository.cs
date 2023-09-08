﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolfsGames.Data.Models;

namespace WolfsGames.Data.Interfaces
{
	public interface IRepository<TEntity>
	{
		List<TEntity> GetAll();
		TEntity FindById(int id);
		void Insert(TEntity entity);
		void Update(TEntity entity);
		void Delete(int id);
	}
}
