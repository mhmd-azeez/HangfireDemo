using Hangfire;

using HangfireDemo.Jobs;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HangfireDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IBackgroundJobClient _backgroundJobClient;

        public IndexModel(IBackgroundJobClient backgroundJobClient)
        {
            _backgroundJobClient = backgroundJobClient;
        }

        [BindProperty]
        public int Count { get; set; }

        public void OnGet()
        {
            
        }

        public void OnPost()
        {
            _backgroundJobClient.Enqueue<SendEmailsJob>(job => job.Execute(Count));
        }
    }
}
