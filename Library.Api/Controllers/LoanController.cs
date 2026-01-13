using Library.Application.DTOs.CreateDTOs;
using Library.Application.DTOs.UpdateDTOs;
using Library.Application.Interfaces.InterfaceService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;
        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllLoans()
        {
            try
            {
                var loans = await _loanService.GetAllAsync();
                return Ok(loans);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetLoanById(int id)
        {
            try
            {
                var loan = await _loanService.GetByLoanIdAsync(id);
                if (loan == null)
                {
                    return NotFound();
                }
                return Ok(loan);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data: {ex.Message}");
            }
        }
        [HttpGet("user/{userId}")]
        public async Task<ActionResult> GetLoansByUserId(int userId)
        {
            try
            {
                var loans = await _loanService.GetByUserIdAsync(userId);
                return Ok(loans);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<ActionResult> CreateLoan([FromBody] LoanCreateDTO loanDTO)
        {
            try
            {
                var result = await _loanService.CreateAsync(loanDTO);
                if (result)
                {
                    return Created();
                }
                return BadRequest("Could not create the loan.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating data: {ex.Message}");
            }

        }
        [HttpPut]
        public async Task<ActionResult> UpdateLoan([FromBody] LoanUpdateDTO loanDTO)
        {
            try
            {
                var result = await _loanService.UpdateAsync(loanDTO);
                if (result)
                {
                    return NoContent();
                }
                return BadRequest("Could not update the loan.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating data: {ex.Message}");
            }
        }

        [HttpPut("return/{id}")]
        public async Task<ActionResult> ReturnBook(int id)
        {
            try
            {
                var result = await _loanService.ReturnBookAsync(id);
                if (result > 0)
                {
                    return Ok($"Book returned successfully. Fine ammount: {result}");
                }
                if (result == 1)
                {
                    return Ok("Book returned successfully. No fine ammount.");
                }
                return BadRequest("Could not return the book.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error returning book: {ex.Message}");
            }
        }
        [HttpPut("extendLoan/{id}")]
        public async Task<ActionResult> ExtendLoan(int id)
        {
            try
            {
                var result = await _loanService.ExtendLoan(id);
                if (result)
                {
                    return Ok("Loan extended successfully 7 days were added.");
                }
                return BadRequest("Could not extend the loan.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error extending loan: {ex.Message}");
            }
        }
    }
}
