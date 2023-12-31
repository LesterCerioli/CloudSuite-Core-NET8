using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.Models;
using CloudSuite.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Repositories
{
	public class MediaRepository : IMediaRepository
	{

		protected readonly CoreDbContext Db;
		protected readonly DbSet<Media> DbSet;

		public MediaRepository(CoreDbContext context) 
		{
			Db = context;
			DbSet = context.Medias;
		}

		

		public async Task Add(Media media)
		{
			await Task.Run(() =>
			{
				DbSet.Add(media);
				Db.SaveChangesAsync();
			});
		}

		public async Task<Media> GetByCaption(string caption)
		{
			return DbSet.FirstOrDefault(a => a.Caption == caption);
		}

		public async Task<Media> GetByFileName(string fileName)
		{
			return DbSet.FirstOrDefault(a => a.FileName == fileName);
		}

		public async Task<Media> GetByFileSize(int? fileSize)
		{
			return DbSet.FirstOrDefault(a => a.FileSize == fileSize); 
		}

		public async Task<IEnumerable<Media>> GetList()
		{
			return await DbSet.ToListAsync();
		}

		public void Remove(Media media)
		{
			DbSet.Remove(media);
		}

		public void Update(Media media)
		{
			DbSet.Update(media);
		}

		public void Dispose()
		{
			Db.Dispose();
		}
	}
}
