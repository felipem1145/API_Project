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
    public class CommentsController : ApiController

    {
		[HttpGet]
        public List<Comments> GetCommentsByProductId(int productId)
        {
			string connectStr = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
			List<Comments> CommentsList = new List<Comments>();

			using (SqlConnection myConnection = new SqlConnection(connectStr))
			{
				string sqlCommand;
				myConnection.Open();
				sqlCommand = "SELECT * FROM Comment WHERE CommentId = " + productId;
				SqlCommand myCommand = new SqlCommand(sqlCommand, myConnection);
				SqlDataReader myReader = myCommand.ExecuteReader(); ;

				while (myReader.Read())
				{
					Comments tempComment = new Comments();
					tempComment.commentId = Convert.ToInt32(myReader["CommentId"]);
					tempComment.customerId = Convert.ToInt32(myReader["CustomerId"]);
					tempComment.productId = Convert.ToInt32(myReader["ProductId"]);
					tempComment.rating = Convert.ToInt32(myReader["Rating"]);
					tempComment.comment = myReader["CommentMessage"].ToString();

					CommentsList.Add(tempComment);

				}
				myReader.Close();
				myConnection.Close();
			}
			return CommentsList;
		}
	}
     
}
