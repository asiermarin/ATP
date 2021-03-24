namespace CachingSimpleExample.Controllers
{
    using CachingSimpleExample.CacheRepositories.Abstractions;
    using CachingSimpleExample.Models;
    using Microsoft.AspNetCore.Mvc;

    public class BookController : ControllerBase
    {
        private readonly IBookRepository<Book> bookRepository;

        public BookController(IBookRepository<Book> bookRepository)
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
        [Route("/v1.0/book")]
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
        [Route("/v1.0/createbook")]
        public IActionResult PostBook([FromBody] Book modelBook)
        {
            var book = MapBook(modelBook);
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

        [HttpDelete]
        [Route("/v1.0/removebook")]
        public IActionResult DeleteBook([FromQuery] string id)
        {
            var result = this.bookRepository.RemoveExistingBook(id);

            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        private Book MapBook(Book modelBook)
        {
            return new Book
            {
                Id = modelBook.Id,
                Isbn = modelBook.Isbn,
                Pages = modelBook.Pages,
            };
        }
    }
}
