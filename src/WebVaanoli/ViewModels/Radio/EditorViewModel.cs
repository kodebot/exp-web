using Microsoft.AspNet.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebVaanoli.ViewModels.Radio
{
    public class EditorViewModel
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string StreamUrl { get; set; }
        public string StreamQuality { get; set; }
        public string Genre { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }

        public List<SelectListItem> StreamQualities { get; set; }
        public List<SelectListItem> Genres { get; set; }
    }
}
