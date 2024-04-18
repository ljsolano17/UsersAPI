using Solution.DAL.EF;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;


namespace Solution.BS
{
    public class Users : ICRUD<data.Users>
    {
        private SolutionDbContext context;
        public Users(SolutionDbContext context)
        {
            this.context = context;
        }
        public void Delete(data.Users entity)
        {
            new DAL.Users(context).Delete(entity);
        }

        public IEnumerable<data.Users> GetAll()
        {
            return new DAL.Users(context).GetAll();
        }

        public data.Users GetById(int id)
        {
            return new DAL.Users(context).GetById(id);   
        }

        public void Insert(data.Users entity)
        {
            new DAL.Users(context).Insert(entity);
        }

        public void Update(data.Users entity)
        {
            new DAL.Users(context).Update(entity);
        }
    }
}
