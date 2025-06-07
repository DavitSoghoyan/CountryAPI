namespace CountryAPI.Models
{
    public class Country
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required int Population {  get; set; }
        public required string Capital {  get; set; }
        public string? Religion {  get; set; }
        public required int Area { get; set; }
        public int? GDPTotal { get; set; }
        public int? GDPPerCapita { get; set; }
        // public List<language> OfficialLanguages {  get; set; }
        //public List<Cities> Cities { get; set; }
        //public string LargistCity {  get; set; }
    }
}
