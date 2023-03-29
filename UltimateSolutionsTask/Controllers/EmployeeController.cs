using BusinessLayer_.Abstract;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace UltimateSolutionsTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _employeemanager;
        public EmployeeController(IEmployeeService employeemanager, ILogger<EmployeeController> logger)
        {
            _employeemanager= employeemanager;
            _logger = logger;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return _employeemanager.EmployeeGetList().ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(short id)
        {
            if (id < 1)
                return BadRequest();

            if (_employeemanager.EmployeeGetByID(id)==null)    
                return NotFound();
            else
            { 
                try
                {
                    _logger.LogInformation("Retrieving order data with ID {OrderId}.", id);
                    return _employeemanager.EmployeeGetByID(id);  
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error retrieving order data with ID {OrderId}.", id);
                    return BadRequest(ex.Message);
                }
            }
        }
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Employee employee)
        {
            _employeemanager.EmployeeAdd(employee);
            _logger.LogInformation("Submitted order data {@Product}", employee);
             return Ok(employee);

        }
        [HttpPut("{id}")]
        public ActionResult<List<Employee>> Put(short id, Employee employee)
        {
            _employeemanager.EmployeeUpdate(employee);
            var updatedData = _employeemanager.EmployeeGetList();
            _logger.LogInformation("Updated order data with ID {OrderId}.", id);
            return Ok(updatedData);
        }
        [HttpDelete("{id}")]
        public ActionResult<List<Employee>> Delete(short id)
        {
            _employeemanager.EmployeeDeleteByID(id);
            _logger.LogInformation("Deleted order data with ID {OrderId}.", id);
            return Ok();
        }


    }

 
}
