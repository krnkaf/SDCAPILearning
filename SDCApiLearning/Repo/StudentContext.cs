using Npgsql;
using SDCApiLearning.Data;
using System.Collections.Generic;
using Dapper;
using System.Linq;

namespace SDCApiLearning.Repo
{
    public class StudentContext
    {
        public Dictionary<string,object> LoadAllData()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            using (var connection = CreateConnection())
            {
                //Gender
                //Subject
                var reader=connection.QueryMultiple(@"
select * from subject;

select * from gender;
");

                var subject_data = reader.Read<SubjectData>().ToList();
                var gender_data = reader.Read<GenderData>().ToList();

                data.Add("subject",subject_data);
                data.Add("gender",gender_data);

            }
            return data;
        }
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

        public void InsertIntoStudent(StudentData data)
        {
            using (var connection = CreateConnection())
            {
                connection.Execute(@"
INSERT INTO public.student(
	id, name)
	VALUES (@id, @name);
", data);
            }
        }

        public void UpdateStudent(StudentData data)
        {
            using (var connection = CreateConnection())
            {
                connection.Execute(@"
UPDATE public.student
	SET  name=@name
	WHERE id=@id;
", data);
            }
        }

        public NpgsqlConnection CreateConnection()
        {
            var conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=sdc;User Id=postgres;Password=12345;");
            conn.Open();
            return conn;
        }
    }
}
