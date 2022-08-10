namespace BMIRussian.GPX2VBO
{
    public record GPXData(double Latitude, double Longitude, double Height, DateTime Time, int HDOP, double SpeedMS);
    public class GPXReader
    {
        public static IEnumerable<GPXData> Read(string fileName)
        {
            yield break;
        }
    }
}