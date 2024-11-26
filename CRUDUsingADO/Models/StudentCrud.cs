﻿using Microsoft.Data.SqlClient;
namespace CRUDUsingADO.Models
{
    public class StudentCrud
    {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dr;
            IConfiguration configuration;
            public StudentCrud(IConfiguration configuration)
            {
                this.configuration = configuration;
                con = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
            }

            // get all emp
            public List<Student> GetStudents()
            {
                List<Student> students = new List<Student>();
                cmd = new SqlCommand("select * from student", con);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                    Student student = new Student();
                    student.StudId = Convert.ToInt32(dr["stuid"]);
                    student.Name = dr["name"].ToString();
                    student.Branch = dr["branch"].ToString();
                    student.Percentage = Convert.ToDouble(dr["marks"]);
                    students.Add(student);
                    }
                }
                con.Close();
                return students;
            }
            public Student GetStudentById(int id)
            {
                Student student = new Student();
                cmd = new SqlCommand("select * from student where stuid=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                    student.StudId = Convert.ToInt32(dr["stuid"]);
                    student.Name = dr["name"].ToString();
                    student.Branch = dr["branch"].ToString();
                    student.Percentage = Convert.ToDouble(dr["marks"]);

                }
                }
                con.Close();
                return student;
            }

            public int AddStudent(Student stud)
            {
                int result = 0;
                string qry = "insert into student values(@name,@branch,@marks)";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@name", stud.Name);
                cmd.Parameters.AddWithValue("@branch", stud.Branch);
                cmd.Parameters.AddWithValue("@marks", stud.Percentage);
                con.Open();
                result = cmd.ExecuteNonQuery();
                con.Close();
                return result;
            }
            public int UpdateStudent(Student stud)
            {
                int result = 0;
                string qry = "update student set name=@name,branch=@branch,marks=@marks where stuid=@id";
                cmd = new SqlCommand(qry, con);

                cmd.Parameters.AddWithValue("@id", stud.StudId);
                cmd.Parameters.AddWithValue("@name", stud.Name);
                cmd.Parameters.AddWithValue("@branch", stud.Branch);
                cmd.Parameters.AddWithValue("@marks", stud.Percentage);
                con.Open();
                result = cmd.ExecuteNonQuery();
                con.Close();
                return result;
        }
            public int DeleteStudent(int id)
            {
                int result = 0;
                string qry = "delete from student where stuid=@id";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                result = cmd.ExecuteNonQuery();
                con.Close();
                return result;
            }
        }
    }


