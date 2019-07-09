namespace WebVaanoli.Domain
{
    public class Genre:Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }
    }
}
