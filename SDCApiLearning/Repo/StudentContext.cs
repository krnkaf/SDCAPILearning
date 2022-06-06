using SDCApiLearning.Data;
using System.Collections.Generic;

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
    }
}
