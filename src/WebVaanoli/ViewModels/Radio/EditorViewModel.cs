namespace WebVaanoli.ViewModels.Radio
{
    public class EditorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string StreamUrl { get; set; }
        public string StreamQuality { get; set; }
        public string Genre { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }
    }
}
