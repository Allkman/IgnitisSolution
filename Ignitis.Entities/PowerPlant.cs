namespace Ignitis.Entities
{
    public class PowerPlant
    {
        public Guid Id { get; set; }
        public string Owner { get; set; } = string.Empty;
        public decimal Power { get; set; }
        public DateTimeOffset ValidFrom { get; set; }
        public DateTimeOffset? ValidTo { get; set; }
    }
}
