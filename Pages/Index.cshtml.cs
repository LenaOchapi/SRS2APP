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

        // ����� ��� ��������� GET-������� (����������� �����)
        public void OnGet()
        {
        }

        // ����� ��� ��������� POST-������� (�������� ������ � ������)
        public IActionResult OnPost()
        {


            // ���� ������������ � ����� ������� � ������� � ���� ������
            HashPassword hasher = new HashPassword();
            string hashedPassword = hasher.Hash(Password);
            // ���� ������������ � ����� ������� � ������� � ���� ������
            var user = _context.Users.FirstOrDefault(u => u.Login.ToLower() == Login.ToLower() && u.Password == hashedPassword);
            if (user != null)
            {
                // ���� ������������ ������, �������������� �� �������� ��������
                return RedirectToPage("/HomePage");
            }
            else
            {
                // ���� ������������ �� ������, ��������� ������ � ModelState
                ModelState.AddModelError(string.Empty, "������������ ����� ��� ������.");
                return Page(); // ���������� �� �� �������� � �������
            }
        }

    }
}
