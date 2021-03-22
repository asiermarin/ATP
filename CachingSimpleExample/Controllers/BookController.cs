namespace CachingSimpleExample.Controllers
{
    using CachingSimpleExample.CacheRepositories.Abstractions;
    using CachingSimpleExample.Models;
    using Microsoft.AspNetCore.Mvc;

    public class BookController : ControllerBase
    {
        private readonly IBookRepository bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        [HttpGet]
        [Route("/v1.0/books")]
        public IActionResult GetBooks()
        {
            var result = this.bookRepository.GetAllExistingBook();

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("/v1.0/books")]
        public IActionResult GetBook([FromQuery] string id)
        {
            var result = this.bookRepository.GetExistingBook(id);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("/v1.0/books")]
        public IActionResult CreateOrUpdateBook([FromBody]Book book)
        {
            var result = this.bookRepository.InsertOrUpdateExistingBook(book);

            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("/v1.0/books")]
        public IActionResult RemoveBook([FromBody] Book book)
        {
            var result = this.bookRepository.InsertOrUpdateExistingBook(book);

            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
