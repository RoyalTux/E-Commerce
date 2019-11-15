namespace WebAPI.Models
{
    public class WebApiFilterCriteria
    {
        public string Name { get; set; }

        public string Album { get; set; }

        public string Artist { get; set; }

        public double[] TrackDuration { get; set; }
    }
}