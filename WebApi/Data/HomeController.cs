using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;

namespace WebApi.Data;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{

    private readonly DataContext _context;

    public HomeController(DataContext context)
    {
        _context = context;

    }
    [HttpGet]
    public ActionResult<bool> ProbarConec()
    {

        try {

            _context.Database.CanConnect();
            
        }catch (Exception ex) {
            Console.WriteLine("Error al conectar a Oracle:"); 
            Console.WriteLine(ex.Message);
            return NotFound();
        }
        return Ok();
    }
}
