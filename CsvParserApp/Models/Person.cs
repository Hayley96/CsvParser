using System.ComponentModel.DataAnnotations.Schema;

namespace CsvParserApp.Models
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string? first_name { get; set; }
        public string? last_name { get; set; }
        public string? company_name { get; set; }
        public string? address { get; set; }
        public string? city { get; set; }
        public string? county { get; set; }
        public string? postal { get; set; }
        public string? phone1 { get; set; }
        public string? phone2 { get; set; }
        public string? email { get; set; }
        public string? web { get; set; }
    }
}