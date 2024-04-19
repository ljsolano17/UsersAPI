using Microsoft.AspNetCore.Mvc;
using Solution.DAL.EF;
using data = Solution.DO.Objects;

namespace Solution.Users.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SolutionDbContext _context;

        public UsersController(SolutionDbContext context)
        {
            this._context = context;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.Users>>> GetUsers()
        {
            try
            {
                return new BS.Users(_context).GetAll().ToList();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.Users>> Get(int id)
        {
            try
            {
                return new BS.Users(_context).GetById(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<data.Users>> Post([FromBody] data.Users user)
        {
            try
            {
                if (user != null)
                {
                    new BS.Users(_context).Insert(user);
                    return CreatedAtAction("GetUsers", new {id = user.Id}, user);
                }
                else
                {
                    return StatusCode(500, "Err procesing");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<data.Users>> Put(int id, [FromBody] data.Users user)
        {
            try
            {
                if(id!=null && user != null)
                {
                    new BS.Users(_context).Update(user);
                    
                }
                else
                {
                    return BadRequest();
                }
            }catch(Exception ex)
            {
                if (!userExists(id))
                {
                    return NotFound();
                }
                return StatusCode(500, ex.Message);
            }
            return NoContent();
        }
       

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.Users>> Delete(int id)
        {
            try
            {
                if(userExists(id))
                {
                    var user = new BS.Users(_context).GetById(id);
                    new BS.Users(_context).Delete(user);
                }
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return NoContent();
        }

        private bool userExists(int id)
        {
            return (new BS.Users(_context).GetById(id) != null);
        }
    }
}
