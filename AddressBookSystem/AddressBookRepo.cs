using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    class AddressBookRepo
    {
        //SqlServer Connection String
        public static string connectionString = "Data Source=SAURAVSHARMA;Initial Catalog=AddressBookServiceDB;Persist Security Info=True;User ID=saurav;Password=Saurav78#$";
        readonly SqlConnection connection = new SqlConnection(connectionString);
        //Get All Records from DB.
        public void GetAllRecords()
        {
            try
            {
                ContactModel model = new ContactModel();
                using (this.connection)
                {
                    //Sql Query
                    string query = @"select c.Firstname, c.Lastname, c.City, c.Phone_no, b.BkName, b.BkType 
                                 from Contact c inner join BookNameType b on c.BookId = b.BookId WHERE LOWER(c.FirstName)='saurav';";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    //Open Connection of Database
                    this.connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        //Read Records from DB Rows Wise.
                        while (reader.Read())
                        {
                            model.Firstname = reader.GetString(0);
                            model.Lastname = reader.GetString(1);
                            model.City = reader.GetString(2);
                            model.Phone = reader.GetInt64(3);
                            model.B_Name = reader.GetString(4);
                            model.B_Type = reader.GetString(5);
                            Console.WriteLine(model.Firstname + " " + model.Lastname + " " + model.City + " " + model.Phone + " " + model.B_Name + " " + model.B_Type);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Rows doesn't exist!");
                    }
                    reader.Close();                
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);             
            }
            finally
            {
                connection.Close();
            }
        }
        //add new field as startdate to contact table
        public void AddDateField()
        {
            try
            {
                using (this.connection)
                {
                    string query = "ALTER TABLE Contact ADD StartDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP; ";
                    SqlCommand command = new SqlCommand(query, connection);
                    this.connection.Open();
                    command.ExecuteReader();
                    this.connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        //retrieve by city or state
        public void RetrieveByCityOrState()
        {           
            ContactModel model = new ContactModel();
            try
            {
                using (this.connection)
                {
                    this.connection.Open();
                    string query = "select * from Contact where city = 'patna' or state = 'Bihar';";
                    SqlCommand command = new SqlCommand(query, this.connection);               
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.Firstname = reader.GetString(1);
                            model.Lastname = reader.GetString(2);
                            model.City = reader.GetString(4);
                            model.Phone = reader.GetInt64(7);
                            Console.WriteLine(model.Firstname + " " + model.Lastname + " " + model.City + " " + model.Phone);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No contacts match the City or State");
                    }
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        // add new Contact to database
        public void AddNewContact()
        {
            string query = "INSERT INTO Contact (FirstName,LastName,Address,City,State,Zip,Phone_no,Email,BookId) VALUES('Vikash','Singh','whitefield','bangalore','karnataka',560084,999887765,'dhjhfj@gmail.com','BK3');";                    
            try
            {
                using (this.connection)
                {
                    this.connection.Open();
                    SqlCommand command = new SqlCommand(query, this.connection);                 
                    //Executes Sql statement to Update in Db.
                    var rows = command.ExecuteNonQuery();
                    //Close Connection of database
                    this.connection.Close();
                    if (rows != 0)
                        Console.WriteLine("Contact Added in Db");
                    else
                        Console.WriteLine(rows);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        //update Contact with State
        public void UpdateContactToDatabase()
        {
            string query = "update Contact set State = 'Bihar' where FirstName = 'vikash';";
            try
            {
                using (this.connection)
                {
                    this.connection.Open();
                    SqlCommand command = new SqlCommand(query, this.connection);
                    //Executes Sql statement to Update in Db.
                    var rows = command.ExecuteNonQuery();
                    //Close Connection of database
                    this.connection.Close();
                    if (rows != 0)
                        Console.WriteLine("Updated in Db");
                    else
                        Console.WriteLine(rows);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}