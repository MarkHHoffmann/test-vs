using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace git_test_vs.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public string blah { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            blah = "This is from branch 1.";
            string s = "";
            foreach (TimeZoneInfo zoneID in TimeZoneInfo.GetSystemTimeZones())
            {
                if (zoneID.DisplayName.Contains("London"))
                {
                    s = zoneID.Id.ToString();
                    break;
                }
            }
            //s = "GMT Standard Time"
            DateTime serverTime = DateTime.Now;
            DateTime _localTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(serverTime, TimeZoneInfo.Local.Id, "Mountain Standard Time");
            DateTime _localTime2 = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(serverTime, TimeZoneInfo.Local.Id, s);

            blah = $"server: {serverTime} | Mountain: {_localTime} | London: {_localTime2} <br>{s}";
            
            return Page();
        }
    }
}
