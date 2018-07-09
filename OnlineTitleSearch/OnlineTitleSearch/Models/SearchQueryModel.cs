using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTitleSearch.Models
{

    public class SearchQueryModel
    {
        [DisplayName("KeyWord to Search")]
        [Required(ErrorMessage = "{0} is required")]
        public string KeyWord { get; set; } = "online title search";
        [Url]
        [DisplayName("Website to find in result")]
        [Required(ErrorMessage = "{0} is required")]
        public string Website { get; set; } = "https://www.infotrack.com.au";

        [Range(10, 10000)]
        [Required(ErrorMessage = "Results to search in required")]
        [DisplayName("Number of Results")]
        public int ResultSetCount { get; set; } = 100;

        public string Result { get; set; }

    }

}
