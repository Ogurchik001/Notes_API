using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Notes_API_34.DTO;
using Notes_API_34.Models;


namespace Notes_API_34.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        FurnitureManufacturingContext context = new FurnitureManufacturingContext();
        //В методе GetNotes определяем параметр для реализации обработки кода 400
        [HttpGet]
        public async Task<IActionResult> GetNotes([FromQuery] string? noteId)
        {
            try
            {

                //Копия оргинального списка
                List<Note> notes = context.Notes.Include(n => n.IdUserNavigation).ToList();

                //Обработка кода 400
                if (!string.IsNullOrWhiteSpace(noteId))
                {
                    if (int.TryParse(noteId, out int id))
                    {
                        notes = notes.Where(n => n.Id == id).ToList();
                    }
                    else
                    {
                        return BadRequest(new { error = "Сервер не может обработать запрос из-за ошибки клиента. Неправильный тип данных у параметра noteId" });
                    }
                }

                //Список для формирования ответа
                List<NotesDTO> notesQuery = notes.Select(n => new NotesDTO()
                {
                    Id = n.Id.ToString(),
                    TitleUser = $"{n.Title} - {n.IdUserNavigation.Login}",
                    Content = n.Content,
                    FormattedDate = n.CreatedAt.ToString("dd.MM.yyyy")
                }).ToList();

                //Обработка статуса 200
                return Ok(notesQuery);
            }
            catch (Exception exeption)
            {
                //Обработка статуса 500

                return StatusCode(500, new { error = "Ошибка подключения к базе данных" });
            }
        }
    }

}
