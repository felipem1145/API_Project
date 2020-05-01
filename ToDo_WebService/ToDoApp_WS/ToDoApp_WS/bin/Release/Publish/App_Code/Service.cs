using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
	public string GetData(int value)
	{
		return string.Format("You entered: {0}", value);
	}

	public CompositeType GetDataUsingDataContract(CompositeType composite)
	{
		if (composite == null)
		{
			throw new ArgumentNullException("composite");
		}
		if (composite.BoolValue)
		{
			composite.StringValue += "Suffix";
		}
		return composite;
	}

	//GET INFO OF THE TASKS



	string connectStr = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
	


	public List<Tasks> GetTaskByDueDate(int year, int month, int day)
	{
		DateTime dueDate = new DateTime(year, month, day);
		List<Tasks> TasksList = new List<Tasks>();

		using (SqlConnection myConnection = new SqlConnection(connectStr))
		{
			string sqlCommand;
			myConnection.Open();
			sqlCommand = "SELECT * FROM Tasks WHERE DueDate = '" + dueDate.ToString("yyyy-MM-dd") + "'";
			SqlCommand myCommand = new SqlCommand(sqlCommand, myConnection);
			SqlDataReader myReader = myCommand.ExecuteReader(); ;

			while (myReader.Read())
			{
				Tasks tempTask = new Tasks();
				tempTask.TaskId = Convert.ToInt32(myReader["TaskId"]);
				tempTask.Title = myReader["Title"].ToString();
				tempTask.DueDate = Convert.ToDateTime(myReader["DueDate"].ToString());
				tempTask.Place = myReader["Place"].ToString();
				tempTask.Category = myReader["Category"].ToString();
				tempTask.Description = myReader["Description"].ToString();
				tempTask.TaskDone = Convert.ToBoolean(myReader["TaskDone"].ToString());

				TasksList.Add(tempTask);

			}
			myReader.Close();
			myConnection.Close();
		}
		return TasksList;
	}

	public List<Tasks> GetTaskById(int taskId)
	{
		List<Tasks> TasksList = new List<Tasks>();

		using (SqlConnection myConnection = new SqlConnection(connectStr))
		{
			string sqlCommand;
			myConnection.Open();
			sqlCommand = "SELECT * FROM Tasks WHERE TaskId = " + taskId;
			SqlCommand myCommand = new SqlCommand(sqlCommand, myConnection);
			SqlDataReader myReader = myCommand.ExecuteReader(); ;

			while (myReader.Read())
			{
				Tasks tempTask = new Tasks();
				tempTask.TaskId = Convert.ToInt32(myReader["TaskId"]);
				tempTask.Title = myReader["Title"].ToString();
				tempTask.DueDate = Convert.ToDateTime(myReader["DueDate"].ToString());
				tempTask.Place = myReader["Place"].ToString();
				tempTask.Category = myReader["Category"].ToString();
				tempTask.Description = myReader["Description"].ToString();
				tempTask.TaskDone = Convert.ToBoolean(myReader["TaskDone"].ToString());

				TasksList.Add(tempTask);

			}
			myReader.Close();
			myConnection.Close();
		}
		return TasksList;

	}

	public List<Tasks> GetTasksDone()
	{
		List<Tasks> TasksList = new List<Tasks>();

		using (SqlConnection myConnection = new SqlConnection(connectStr))
		{
			string sqlCommand;
			myConnection.Open();
			sqlCommand = "SELECT * FROM Tasks WHERE TaskDone = " + 1;
			SqlCommand myCommand = new SqlCommand(sqlCommand, myConnection);
			SqlDataReader myReader = myCommand.ExecuteReader(); ;

			while (myReader.Read())
			{
				Tasks tempTask = new Tasks();
				tempTask.TaskId = Convert.ToInt32(myReader["TaskId"]);
				tempTask.Title = myReader["Title"].ToString();
				tempTask.DueDate = Convert.ToDateTime(myReader["DueDate"].ToString());
				tempTask.Place = myReader["Place"].ToString();
				tempTask.Category = myReader["Category"].ToString();
				tempTask.Description = myReader["Description"].ToString();
				tempTask.TaskDone = Convert.ToBoolean(myReader["TaskDone"].ToString());

				TasksList.Add(tempTask);

			}
			myReader.Close();
			myConnection.Close();
		}
		return TasksList;
	}
}
