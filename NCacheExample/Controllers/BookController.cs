namespace NCacheExample.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using NCacheExample.CacheRepositories.Abstractions;
    using NCacheExample.Models;

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

        [HttpGet]
        [Route("/v1.0/removebook")]
        public IActionResult DeleteBook([FromBody] Book book)
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

        private Book MapBook(Book modelBook)
        {
            return new Book
            {
                Id = modelBook.Id,
                Isbn = modelBook.Isbn,
                Pages = modelBook.Pages
            };
        }
    }
}
