using Npgsql;
using SDCApiLearning.Data;
using System.Collections.Generic;
using Dapper;
using System.Linq;

namespace SDCApiLearning.Repo
{
    public class StudentContext
    {
        public List<StudentData> GetStudentList()
        {
            //DB Connect
            //Query
            StudentData s1 = new StudentData { 
                id=1,
                name="Ram",
                subject_name="",
            };

            StudentData s2 = new StudentData
            {
                id = 2,
                name = "Shyam",
                subject_name = "",
            };

            List<StudentData> list=new List<StudentData>();
            list.Add(s1);
            list.Add(s2);

            return list;
        }

        public List<StudentData> GetStudentDatasFromDB(int id)
        {
            
            List <StudentData> Data=new List<StudentData>();


            using (var connection = CreateConnection())
            {
                if(id==0)
                    Data=connection.Query<StudentData>("select * from student").ToList();
                else
                    Data = connection.Query<StudentData>("select * from student where id=@something", new {
                        something = id
                    }).ToList();
            }

            return Data;
        }

        public NpgsqlConnection CreateConnection()
        {
            var conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=sdc;User Id=postgres;Password=12345;");
            conn.Open();
            return conn;
        }
    }
}
