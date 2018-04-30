using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
//using System.Data.SQLite;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;

namespace Dip_Assignment
{
    class DataStoreAccess:IDataStoreAccess
    {
        //  private SQLiteConnection _sqLiteConnection;
        private SqlConnection _sqLiteConnection;


        public DataStoreAccess(String databasePath)
        {
            //_sqLiteConnection = new SQLiteConnection(String.Format("Data Source={0};Version=3;",databasePath));
            _sqLiteConnection = new SqlConnection("Data Source=CSUFLAPTOP-242\\SQLEXPRESS;Initial Catalog=hello;User Id=akash;Password=akash1234;");
        }
        public String SaveFace(string username, Byte[] faceBlob)
        {
            try
            {
                var exisitingUserId = GetUserId(username);
                if (exisitingUserId == 0) exisitingUserId = GenerateUserId();
                _sqLiteConnection.Open();
                var insertQuery = "INSERT INTO faces(username, faceSample, userId) VALUES(@username,@faceSample,@userId)";
                //var cmd = new SQLiteCommand(insertQuery, _sqLiteConnection);
                var cmd = new SqlCommand(insertQuery, _sqLiteConnection);
                cmd.Parameters.AddWithValue("username", username);
                cmd.Parameters.AddWithValue("userId", exisitingUserId);
                //cmd.Parameters.Add("faceSample", DbType.Binary, faceBlob.Length).Value = faceBlob;
                cmd.Parameters.Add("faceSample", SqlDbType.Image, faceBlob.Length).Value = faceBlob;
                var result = cmd.ExecuteNonQuery();
                return String.Format("{0} face(s) saved successfully", result);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                _sqLiteConnection.Close();
            }
           
        }

        public List<Face> CallFaces(string username)
        {
            var faces = new List<Face>();
            try
            {
               _sqLiteConnection.Open();
                var query = username.ToLower().Equals("ALL_USERS".ToLower()) ? "SELECT * FROM faces" : "SELECT * FROM faces WHERE username=@username";
                //var cmd = new SQLiteCommand(query, _sqLiteConnection);
                var cmd = new SqlCommand(query, _sqLiteConnection);
                if (!username.ToLower().Equals("ALL_USERS".ToLower())) cmd.Parameters.AddWithValue("username", username);
                var result = cmd.ExecuteReader();
                if (!result.HasRows) return null;
                
                while (result.Read())
                {
                    var face = new Face
                    {
                        Image = (byte[]) result["faceSample"],
                        Id = Convert.ToInt32(result["id"]),
                        Label = (String) result["username"],
                        UserId = Convert.ToInt32(result["userId"])
                    };
                    faces.Add(face);
                }
                faces = faces.OrderBy(f => f.Id).ToList();
                
                

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                _sqLiteConnection.Close();
            }
            return faces;
        }


        public int GetUserId(string username)
        {
            var userId = 0;
            try
            {
                _sqLiteConnection.Open();
                var selectQuery = "SELECT TOP 1 userId FROM faces WHERE username=@username";
                //var cmd = new SQLiteCommand(selectQuery, _sqLiteConnection);
                var cmd = new SqlCommand(selectQuery, _sqLiteConnection);
                cmd.Parameters.AddWithValue("username", username);
                var result = cmd.ExecuteReader();
                if (!result.HasRows) return 0;
                while (result.Read())
                {
                    userId = Convert.ToInt32(result["userId"]);
                    
                }
            }
            catch(Exception e)
            {
                string s = e.Message;
                return userId;
            }
            finally
            {
                _sqLiteConnection.Close();
            }
            return userId; ;
        }

        public string GetUsername(int userId)
        {
            var username = "";
            try
            {
                _sqLiteConnection.Open();
                var selectQuery = "SELECT username FROM faces WHERE userId=@userId";
                //var cmd = new SQLiteCommand(selectQuery, _sqLiteConnection);
                var cmd = new SqlCommand(selectQuery, _sqLiteConnection);
                cmd.Parameters.AddWithValue("userId", userId);
                var result = cmd.ExecuteReader();
                if (!result.HasRows) return username;
                while (result.Read())
                {
                    username = (String)result["username"];

                }
            }
            catch
            {
                return username;
            }
            finally
            {
                _sqLiteConnection.Close();
            }
            return username; ;
        }

        public List<string> GetAllUsernames()
        {
            var usernames = new List<string>();
            try
            {
                _sqLiteConnection.Open();
                var cmd = new SqlCommand("SELECT DISTINCT uname FROM student where course_number=(select course_number from course where course_id=@courseid);", _sqLiteConnection);
                cmd.Parameters.Add(new SqlParameter("@courseid", Convert.ToInt32(Global.Courseid)));
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    usernames.Add(dr["uname"].ToString());
                }
                dr.Close();
                usernames.Sort();
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                _sqLiteConnection.Close();
            }
            return usernames;
        }


        public void DeleteUser(string username)
        {
            try
            {
                _sqLiteConnection.Open();
                var cmd = new SqlCommand("DELETE FROM student WHERE uname=@username and course_number=(select course_number from course where course_id=@courseid);", _sqLiteConnection);
                cmd.Parameters.Add(new SqlParameter("@username",username));
                cmd.Parameters.Add(new SqlParameter("@courseid", Convert.ToInt32(Global.Courseid)));
                var result = cmd.ExecuteNonQuery();
                var cmd1 = new SqlCommand("DELETE FROM registered WHERE uname=@username and course_id=@courseid;", _sqLiteConnection);
                cmd1.Parameters.Add(new SqlParameter("@username", username));
                cmd1.Parameters.Add(new SqlParameter("@courseid", Convert.ToInt32(Global.Courseid)));
                var result1 = cmd1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                _sqLiteConnection.Close();
            }
        }

        public int GenerateUserId()
        {
            var date = DateTime.Now.ToString("MMddHHmmss");
            return Convert.ToInt32(date);
        }

        public bool IsUsernameValid(string username)
        {
            throw new NotImplementedException();
        }

        public string SaveAdmin(string username, string password)
        {
            throw new NotImplementedException();
        }
        public int CheckWithCourse(string username)
        {
            _sqLiteConnection.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from student where uname=@name and course_number=(select course_number from course where course_id=@courseid)",_sqLiteConnection);
            cmd.Parameters.Add(new SqlParameter("@name",username));
            cmd.Parameters.Add(new SqlParameter("@courseid", Convert.ToInt32(Global.Courseid)));
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            _sqLiteConnection.Close();
            return count;
        }
        public int CheckIfAlreadyExists(string username)
        {
            _sqLiteConnection.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from registered where uname=@name and course_id=@courseid and date=@date;", _sqLiteConnection);
            cmd.Parameters.Add(new SqlParameter("@name", username));
            cmd.Parameters.Add(new SqlParameter("@courseid", Convert.ToInt32(Global.Courseid)));
            cmd.Parameters.Add(new SqlParameter("@date", System.DateTime.Now.Date));
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            _sqLiteConnection.Close();
            return count;
        }
        public string MarkAttendance(string username)
        {
            try
            {
                _sqLiteConnection.Open();
                SqlCommand cmd = new SqlCommand("insert into registered values(@courseid,@name,@date);", _sqLiteConnection);
                cmd.Parameters.Add(new SqlParameter("@name", username));
                cmd.Parameters.Add(new SqlParameter("@courseid", Convert.ToInt32(Global.Courseid)));
                cmd.Parameters.Add(new SqlParameter("@date", System.DateTime.Now.Date));
                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("select course_number from course where course_id=@courseid;",_sqLiteConnection);
                cmd1.Parameters.Add(new SqlParameter("@courseid", Convert.ToInt32(Global.Courseid)));
                string course_number = cmd1.ExecuteScalar().ToString();
                _sqLiteConnection.Close();


                // Send Email containing password

                string emailto = username + "@csu.fullerton.edu";
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("adityashahhabit@gmail.com");
                    mail.To.Add(emailto);
                    mail.Subject = "Attendance Updates for " + username;
                    mail.Body = "Your attendance is marked as present for course - " + course_number + " on date - " + System.DateTime.Now.Date.ToString("dd MMM yyyy");
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("adityashahhabit@gmail.com", "adityashah123");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }


                return "successful";
            }
            catch(Exception e)
            {
                return "error";
            }
        }
    }
}
