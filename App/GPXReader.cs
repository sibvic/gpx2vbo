using System.Xml;

namespace BMIRussian.GPX2VBO;
public record GPXData(double Latitude, double Longitude, double Height, DateTime Time, int HDOP, double SpeedMS);
public class GPXReader
{
    public static IEnumerable<GPXData> Read(string fileName)
    {
        var dataFile = new XmlDocument();
        dataFile.Load(fileName);
        var trackPoints = dataFile.SelectNodes("//trkpt");
        if (trackPoints == null)
        {
            yield break;
        }
        for (int i = 0; i < trackPoints.Count; ++i)
        {
            yield return ParseData(trackPoints[i]);
        }
    }

    private static GPXData ParseData(XmlNode? trackPoint)
    {
        return new GPXData(GetLatitude(trackPoint), 
            GetLongitude(trackPoint),
            GetHeight(trackPoint),
            GetTime(trackPoint),
            GetHDOP(trackPoint),
            GetSpeedMS(trackPoint));
    }

    private static double GetSpeedMS(XmlNode? trackPoint)
    {
        throw new NotImplementedException();
    }

    private static int GetHDOP(XmlNode? trackPoint)
    {
        throw new NotImplementedException();
    }

    private static DateTime GetTime(XmlNode? trackPoint)
    {
        throw new NotImplementedException();
    }

    private static double GetHeight(XmlNode? trackPoint)
    {
        throw new NotImplementedException();
    }

    private static double GetLongitude(XmlNode? trackPoint)
    {
        throw new NotImplementedException();
    }

    private static double GetLatitude(XmlNode? trackPoint)
    {
        throw new NotImplementedException();
    }
}