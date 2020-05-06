using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiVirtualStore.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApiVirtualStore.Controllers
{
	public class ProductsController : ApiController
	{
		string connectStr = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

		[HttpGet]
		public List<Products> GetProducts()
		{
			List<Products> ProductsList = new List<Products>();

			using (SqlConnection myConnection = new SqlConnection(connectStr))
			{
				string sqlCommand;
				myConnection.Open();
				sqlCommand = "SELECT * FROM Product";
				SqlCommand myCommand = new SqlCommand(sqlCommand, myConnection);
				SqlDataReader myReader = myCommand.ExecuteReader(); ;

				while (myReader.Read())
				{
					Products tempProduct = new Products();
					tempProduct.productId = Convert.ToInt32(myReader["ProductId"]);
					tempProduct.productName = myReader["ProductName"].ToString();
					tempProduct.productDescription = myReader["ProductDescription"].ToString();
					tempProduct.price = Convert.ToInt32(myReader["Price"].ToString());
					tempProduct.stock = Convert.ToInt32(myReader["Stock"].ToString());

					ProductsList.Add(tempProduct);

				}
				myReader.Close();
				myConnection.Close();
			}
			return ProductsList;

		}
	}


	
}
