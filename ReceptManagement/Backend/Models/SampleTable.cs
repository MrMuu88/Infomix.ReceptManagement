namespace Backend.Models
{
    public class SampleTable
    {
        public int SampleTableId { get; set; }
        public string Name { get; set; }

        public ICollection<SampleTableElement> SampleTableElements { get; set; }
    }
}
