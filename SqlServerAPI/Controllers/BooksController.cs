using Core.Abstracts.IServices;
using Core.Concretes.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SqlServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IShelfService service;

        public BooksController(IShelfService service)
        {
            this.service = service;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public async Task<IActionResult> GetAysnc()
        {
            var data = await service.GetBooks();
            if (data.Any())
            {
                return Ok(data);
            }
            else
            {
                return NotFound();
            }

        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAysnc(int id)
        {
            var data = await service.GetBook(id);
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Book book)
        {
            try
            {
                await service.CreateBook(book);
                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Book book)
        {
            try
            {
                await service.UpdateBook(id, book);
                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await service.DeleteBook(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

        }
    }
}
