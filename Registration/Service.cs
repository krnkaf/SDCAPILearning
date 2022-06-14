using System;
using System.Collections.Generic;
using System.Text;

namespace Registration
{
    public class Service : IService
    {
        IRepo repo;
        public Service(IRepo repo)
        {
            this.repo= repo;
        }
        public string Insert()
        {
            repo.Insert();
            return "From Service";
        }
    }
}
