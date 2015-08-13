using System;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class CalendarViewModel
    {
        public DateGen.IntervalEnum type { get; set; }

        [Range(0, 60)]
        [Display(Name = "number")]
        public int num { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "starts")]
        public string dt { get; set; }

        [Range(1, 60)]
        public int occurrence { get; set; }

        public CalendarViewModel()
        {
            // defaults
            type = DateGen.IntervalEnum.Week;
            num = 1;
            dt = DateTime.UtcNow.ToString("yyyy-MM-dd");
            occurrence = 53;
        }
    }
}