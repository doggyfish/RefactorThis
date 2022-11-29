using Microsoft.Data.Sqlite;
using RefactorThis.Infrastructure.Interfaces;
using RefactorThis.Models;
using System.Data;

namespace RefactorThis.Infrastructure
{
	public class ProductRepository : BaseRepository, IProductRepository<Product>
	{
		public ProductRepository(string strConn) : base(strConn)
		{
		}

		/// <summary>
		/// Get a list of products
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public List<Product> GetList(string? name = "")
		{
			var items = new List<Product>();
			string where = "";
			if (!string.IsNullOrWhiteSpace(name))
			{
				where = $"where lower(name) like '%{name.ToLower()}%'";
			}
			using var conn = new SqliteConnection(_strConn);
			conn.Open();
			var cmd = conn.CreateCommand();
			cmd.CommandText = $"select * from Products {where}";

			var rdr = cmd.ExecuteReader();
			while (rdr.Read())
			{
				Guid id = Guid.Parse(rdr["Id"].ToString());
				string? pName = rdr["Name"].ToString();
				string? description = rdr["Description"].ToString();
				decimal price = decimal.Parse(rdr["Price"].ToString() ?? "0");
				decimal deliveryPrice = decimal.Parse(rdr["DeliveryPrice"].ToString() ?? "0");

				var productNew = CreateProduct(id, pName, description, price, deliveryPrice);
				items.Add(productNew);
			}

			return items;
		}

		private Product CreateProduct(Guid id, string? name, string? description, decimal price, decimal deliveryPrice)
		{
			var product = new Product();
			product.Id = id;
			product.Name = name;
			product.Description = description;
			product.Price = price;
			product.DeliveryPrice = deliveryPrice;
			return product;
		}

		/// <summary>
		/// Get product detail
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Product GetById(Guid id)
		{
			using var conn = new SqliteConnection(_strConn);
			conn.Open();
			var cmd = conn.CreateCommand();
			cmd.CommandText = $"select * from Products where id = '{id}' collate nocase";

			var rdr = cmd.ExecuteReader();
			if (!rdr.Read())
				return new Product();

			var pName = rdr.IsDBNull("Name") ? null : rdr.GetString("Name");
			var description = rdr.IsDBNull("Description") ? null : rdr.GetString("Description");
			var price = decimal.Parse(rdr["Price"].ToString() ?? "0");
			var deliveryPrice = decimal.Parse(rdr["DeliveryPrice"].ToString() ?? "0");
			var productNew = CreateProduct(id, pName, description, price, deliveryPrice);

			return productNew;
		}

		/// <summary>
		/// Add product
		/// </summary>
		/// <param name="product"></param>
		/// <returns></returns>
		public void Add(Product product)
		{
			using var conn = new SqliteConnection(_strConn);
			conn.Open();

			var cmd = conn.CreateCommand();

			cmd.CommandText = $"insert into Products (id, name, description, price, deliveryprice) values ('{product.Id}', '{product.Name}', '{product.Description}', {product.Price}, {product.DeliveryPrice})";
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// Update product
		/// </summary>
		/// <param name="product"></param>
		/// <returns></returns>
		public void Update(Product product)
		{
			using var conn = new SqliteConnection(_strConn);
			conn.Open();

			var cmd = conn.CreateCommand();

			cmd.CommandText = $"update Products set name = '{product.Name}', description = '{product.Description}', price = {product.Price}, deliveryprice = {product.DeliveryPrice} where id = '{product.Id}' collate nocase";
			cmd.ExecuteNonQuery();
		}

		/// <summary>
		/// deletes product and it's options.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public void Delete(Guid id)
		{
			using var conn = new SqliteConnection(_strConn);
			conn.Open();

			var cmdOptions = conn.CreateCommand();
			cmdOptions.CommandText = $"delete from productoptions where productid = '{id}' collate nocase";
			cmdOptions.ExecuteNonQuery();

			var cmd = conn.CreateCommand();
			cmd.CommandText = $"delete from Products where id = '{id}' collate nocase";
			cmd.ExecuteNonQuery();
		}
	}
}
