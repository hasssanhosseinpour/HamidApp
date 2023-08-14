using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColorsController : ControllerBase
    {
        private readonly DataContext _context;
        public ColorsController(DataContext context)
        {
            _context = context;
            
        }
        [HttpGet]
        public ActionResult<AppColor> GetColor(){
            var colors = _context.Colors.ToList();

            // Create a Random instance
            Random random = new Random();

            // Generate a random index within the range of the list
            int randomIndex = random.Next(0, colors.Count);

            // Get the random value from the list
            var randomName = colors.Where(c=>c.Id == randomIndex).FirstOrDefault();

            Console.WriteLine($"Random name: {randomName}");

            return randomName;
        }
        [HttpGet ("{id}")]
        public ActionResult<AppColor> GetColor(int id){
            var color = _context.Colors.Find(id);
            return color;
        }

    }
}