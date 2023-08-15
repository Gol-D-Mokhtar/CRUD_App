using CRUD_App.Data;
using CRUD_App.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmbData : Controller
    {
        private readonly ED_APIContext dbContext;
        public EmbData(ED_APIContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetEmpData()
        {
            return Ok(await dbContext.EmployeeData.ToListAsync()); 
        }
        [HttpGet]
        [Route("{ID:guid}")]
        public async Task<IActionResult> GetEmpData([FromRoute]Guid ID)
        {
            var employeeData = await dbContext.EmployeeData.FindAsync(ID);
            if (employeeData == null)
            {
                return NotFound();
            }
            return Ok(employeeData);
        }
        [HttpPost]
        public async Task<IActionResult> AddEmpData(AddEmpDataRequest addEmpDataRequest)
        {
            var employeeData = new EmployeeData()
            {
                ID = Guid.NewGuid(),
                Name = addEmpDataRequest.Name,
                NationalId = addEmpDataRequest.NationalId,
                DateOfBirth = addEmpDataRequest.DateOfBirth,
                age = addEmpDataRequest.age,
                Account = addEmpDataRequest.Account,
                LineOfBuisness = addEmpDataRequest.LineOfBuisness,
                Language = addEmpDataRequest.Language,
                LanguageLevel = addEmpDataRequest.LanguageLevel,
            };
            await dbContext.EmployeeData.AddAsync(employeeData);
            await dbContext.SaveChangesAsync();
            return Ok(employeeData);
        }
        [HttpPut]
        [Route("{ID:guid}")]
        public async Task<IActionResult> UpdateEmpData([FromRoute]Guid ID, UpdateEmpDataRequest updateEmpDataRequest)
        {
            var employeeData = await dbContext.EmployeeData.FindAsync(ID);
            if (employeeData!=null)
            {
                employeeData.Name = updateEmpDataRequest.Name;
                employeeData.DateOfBirth = updateEmpDataRequest.DateOfBirth;
                employeeData.Account = updateEmpDataRequest.Account;
                employeeData.LineOfBuisness=updateEmpDataRequest.LineOfBuisness;
                employeeData.Language = updateEmpDataRequest.Language;
                employeeData.LanguageLevel = updateEmpDataRequest.LanguageLevel;
                await dbContext.SaveChangesAsync();
                return Ok(employeeData);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("{ID:guid}")]
        public async Task<IActionResult> DeleteEmpData([FromRoute] Guid ID)
        {
            var employeeData = await dbContext.EmployeeData.FindAsync(ID);
            if (employeeData != null)
            {
                dbContext.Remove(employeeData);
                await dbContext.SaveChangesAsync();
                return Ok(employeeData);
            }
            else
            {
                return NotFound();
            }
        }
    }

}
