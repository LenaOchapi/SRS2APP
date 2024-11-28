using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Linq;
using SRS2APP.Data;
using SRS2APP.Models;




namespace SRS2APP.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public string Login { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // Метод для обработки GET-запроса (отображение формы)
        public void OnGet()
        {
        }

        // Метод для обработки POST-запроса (проверка логина и пароля)
        public IActionResult OnPost()
        {


            // Ищем пользователя с таким логином и паролем в базе данных
            HashPassword hasher = new HashPassword();
            string hashedPassword = hasher.Hash(Password);
            // Ищем пользователя с таким логином и паролем в базе данных
            var user = _context.Users.FirstOrDefault(u => u.Login.ToLower() == Login.ToLower() && u.Password == hashedPassword);
            if (user != null)
            {
                // Если пользователь найден, перенаправляем на домашнюю страницу
                return RedirectToPage("/HomePage");
            }
            else
            {
                // Если пользователь не найден, добавляем ошибку в ModelState
                ModelState.AddModelError(string.Empty, "Неправильный логин или пароль.");
                return Page(); // Возвращаем ту же страницу с ошибкой
            }
        }

    }
}
