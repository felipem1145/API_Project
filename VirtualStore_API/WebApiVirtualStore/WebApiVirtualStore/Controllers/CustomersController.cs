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
    public class CustomersController : ApiController
    {
		[HttpGet]
		public List<Customers> GetCustomers()
		{
			string connectStr = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
			List<Customers> CustomersList = new List<Customers>();

			using (SqlConnection myConnection = new SqlConnection(connectStr))
			{
				string sqlCommand;
				myConnection.Open();
				sqlCommand = "SELECT * FROM Customer";
				SqlCommand myCommand = new SqlCommand(sqlCommand, myConnection);
				SqlDataReader myReader = myCommand.ExecuteReader(); ;

				while (myReader.Read())
				{
					Customers tempCustomer = new Customers();
					tempCustomer.customerId = Convert.ToInt32(myReader["CustomerId"]);
					tempCustomer.username = myReader["Username"].ToString();
					tempCustomer.password = myReader["CustomerPass"].ToString();
					tempCustomer.email = myReader["Email"].ToString();
					tempCustomer.fullName = myReader["Fullname"].ToString();
					tempCustomer.customerAddress = myReader["CustomerAddress"].ToString();
					tempCustomer.phoneNumber = myReader["Phone"].ToString();
					tempCustomer.gender = myReader["Gender"].ToString();
					tempCustomer.birthDate = myReader["BirthDate"].ToString();


					CustomersList.Add(tempCustomer);

				}
				myReader.Close();
				myConnection.Close();
			}
			return CustomersList;
		}

	}
}
