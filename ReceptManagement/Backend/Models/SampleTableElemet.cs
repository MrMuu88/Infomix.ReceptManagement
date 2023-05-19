namespace Backend.Models
{
    public class SampleTableElement
    {
        public int SampleTableElementId { get; set; }
        public string Description { get; set; }

        public int SampleTableId { get; set; }
        public SampleTable SampleTable { get; set; }
    }
}
