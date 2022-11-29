using Microsoft.Data.Sqlite;
using RefactorThis.Infrastructure.Interfaces;
using RefactorThis.Models;

namespace RefactorThis.Infrastructure
{
    public class ProductOptionRepository : BaseRepository, IProductOptionRepository<ProductOption>
	{
		public ProductOptionRepository(string strConn) : base(strConn)
		{
		}

		/// <summary>
		/// Get Options
		/// </summary>
		/// <param name="productId"></param>
		/// <returns></returns>
		public List<ProductOption> GetList(Guid productId)
		{
			var items = new List<ProductOption>();
			using var conn = new SqliteConnection(_strConn);
			conn.Open();
			var cmd = conn.CreateCommand();
			cmd.CommandText = $"select * from productoptions where productid = '{productId}' collate nocase";

			var rdr = cmd.ExecuteReader();
			while (rdr.Read())
			{
				Guid id = Guid.Parse(rdr.GetString(0));
				Guid pid = Guid.Parse(rdr["productid"].ToString());
				string? pName = rdr["Name"].ToString();
				string? description = rdr["Description"].ToString();
				var option = CreateProductOption(id, pid, pName, description);
				items.Add(option);
			}

			return items;
		}

		private ProductOption CreateProductOption(Guid id, Guid productId, string? name, string? description)
		{
			var productOption = new ProductOption();
			productOption.Id = id;
			productOption.ProductId = productId;
			productOption.Name = name;
			productOption.Description = description;
			return productOption;
		}

		/// <summary>
		/// Get product option
		/// </summary>
		/// <param name="id"></param>
		/// <param name="productId"></param>
		/// <returns></returns>
		public ProductOption GetById(Guid productId, Guid id)
		{
			ProductOption productOptionNew = new();
			using var conn = new SqliteConnection(_strConn);
			conn.Open();
			var cmd = conn.CreateCommand();

			cmd.CommandText = $"select * from productoptions where id = '{id}' collate nocase and productid = '{productId}' collate nocase";

			var rdr = cmd.ExecuteReader();
			if (!rdr.Read())
				return productOptionNew;

			productOptionNew.Id = id;

			if (Guid.TryParse(rdr["ProductId"].ToString(), out Guid result))
			{
				productOptionNew.ProductId = result;
			}

			productOptionNew.Name = (DBNull.Value == rdr["Name"]) ? null : rdr["Name"].ToString();
			productOptionNew.Description = (DBNull.Value == rdr["Description"]) ? null : rdr["Description"].ToString();

			return productOptionNew;
		}

		/// <summary>
		/// Add Option
		/// </summary>
		/// <param name="productOption"></param>
		/// <returns></returns>
		public void Add(ProductOption productOption)
		{
			using var conn = new SqliteConnection(_strConn);
			conn.Open();
			var cmd = conn.CreateCommand();

			cmd.CommandText = $"insert into productoptions (id, productid, name, description) values ('{productOption.Id}', '{productOption.ProductId}', '{productOption.Name}', '{productOption.Description}')";
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Updte Option
		/// </summary>
		/// <param name="productOption"></param>
		/// <returns></returns>
		public void Update(ProductOption productOption)
		{
			using var conn = new SqliteConnection(_strConn);
			conn.Open();
			var cmd = conn.CreateCommand();
			cmd.CommandText = $"update productoptions set name = '{productOption.Name}', description = '{productOption.Description}' where id = '{productOption.Id}' collate nocase and productid = '{productOption.ProductId}' collate nocase";
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Delete Option
		/// </summary>
		/// <param name="productid"></param>
		/// <param name="id"></param>
		/// <returns></returns>
		public void Delete(Guid productid, Guid id)
		{
			using var conn = new SqliteConnection(_strConn);
			conn.Open();
			var cmd = conn.CreateCommand();
			cmd.CommandText = $"delete from productoptions where id = '{id}' collate nocase and productid = '{productid}' collate nocase";
			cmd.ExecuteNonQuery();
		}
	}
}
