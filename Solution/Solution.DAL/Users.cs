using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.DAL
{
    public class Users : ICRUD<data.Users>
    {
        private Repository<data.Users> _repo = null;
        public Users(SolutionDbContext context) 
        {
            _repo = new Repository<data.Users>(context);
        }
        public void Delete(data.Users entity)
        {
            _repo.Delete(entity);
            _repo.Commit();
        }

        public IEnumerable<data.Users> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Users GetById(int id)
        {
            return _repo.GetById(id);
        }

        public void Insert(data.Users entity)
        {
            _repo.Insert(entity);
            _repo.Commit();
        }

        public void Update(data.Users entity)
        {
            _repo.Update(entity);
            _repo.Commit();
        }
    }
}
