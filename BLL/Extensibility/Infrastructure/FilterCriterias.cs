// ReSharper disable IdentifierTypo
namespace BLL.Extensibility.Infrastructure
{
    public class FilterCriterias
    {
        public string Name { get; set; }

        public string Album { get; set; }

        public string Artist { get; set; }

        public double[] TrackDuration { get; set; }

        public int MinPrice { get; set; }

        public int MaxPrice { get; set; }
    }
}
