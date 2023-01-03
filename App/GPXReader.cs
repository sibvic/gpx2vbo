using System.Globalization;
using System.Xml;

namespace BMIRussian.GPX2VBO;
public class GPXReader
{
    public static IEnumerable<GPXData> Read(string fileName)
    {
        var dataFile = new XmlDocument();
        dataFile.Load(fileName);
        foreach (var trackPoint in GetTrackPoints(dataFile.ChildNodes))
        {
            yield return ParseData(trackPoint);
        }
    }

    private static IEnumerable<XmlNode> GetTrackPoints(XmlNodeList nodes)
    {
        for (int i = 0; i < nodes.Count; ++i)
        {
            foreach (var point in GetTrackPoints(nodes[i].ChildNodes))
            {
                yield return point;
            }
            if (nodes[i].Name == "trkpt")
            {
                yield return nodes[i];
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="trackPoint"></param>
    /// <exception cref="InvalidFormatException"></exception>
    /// <returns></returns>
    private static GPXData ParseData(XmlNode trackPoint)
    {
        return new GPXData(GetLatitude(trackPoint), 
            GetLongitude(trackPoint),
            GetHeight(trackPoint),
            GetTime(trackPoint),
            GetHDOP(trackPoint),
            GetSpeedMS(trackPoint));
    }

    private static string Extract2DSpeed(string str)
    {
        var records = str.Split(';');
        foreach (var record in records)
        {
            var pair = record.Split(':');
            if (pair.Length != 2)
            {
                throw new InvalidFormatException();
            }
            if (pair[0] != "2dSpeed")
            {
                continue;
            }
            return pair[1].Trim();
        }
        throw new InvalidFormatException();
    }

    private static double GetSpeedMS(XmlNode trackPoint)
    {
        var node = FindChild(trackPoint, "cmt");
        if (node == null || node.InnerText == null)
        {
            throw new InvalidFormatException();
        }
        var speed2d = Extract2DSpeed(node.InnerText);    
        if (!double.TryParse(speed2d, NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
        {
            throw new InvalidFormatException();
        }
        return value;
    }

    private static XmlNode? FindChild(XmlNode trackPoint, string name)
    {
        if (trackPoint.ChildNodes == null)
        {
            return null;
        }
        for (int i = 0; i < trackPoint.ChildNodes.Count; ++i)
        {
            if (trackPoint.ChildNodes[i].Name == name)
            {
                return trackPoint.ChildNodes[i];
            }
        }
        return null;
    }

    private static int GetHDOP(XmlNode? trackPoint)
    {
        var node = FindChild(trackPoint, "hdop");
        if (node == null)
        {
            throw new InvalidFormatException();
        }
        if (!int.TryParse(node.InnerText, out var value))
        {
            throw new InvalidFormatException();
        }
        return value;
    }

    private static DateTime GetTime(XmlNode? trackPoint)
    {
        var node = FindChild(trackPoint, "time");
        if (node == null)
        {
            throw new InvalidFormatException();
        }
        if (!DateTime.TryParse(node.InnerText, out var value))
        {
            throw new InvalidFormatException();
        }
        return value.ToUniversalTime();
    }

    private static double GetHeight(XmlNode? trackPoint)
    {
        var node = FindChild(trackPoint, "ele");
        if (node == null)
        {
            throw new InvalidFormatException();
        }
        if (!double.TryParse(node.InnerText, NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
        {
            throw new InvalidFormatException();
        }
        return value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="trackPoint"></param>
    /// <exception cref="InvalidFormatException"></exception>
    /// <returns></returns>
    private static double GetLongitude(XmlNode trackPoint)
    {
        var attribute = FindAttribute(trackPoint, "lon");
        if (attribute == null)
        {
            throw new InvalidFormatException();
        }
        if (!double.TryParse(attribute.Value, NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
        {
            throw new InvalidFormatException();
        }
        return value;
    }

    private static double GetLatitude(XmlNode trackPoint)
    {
        var attribute = FindAttribute(trackPoint, "lat");
        if (attribute == null)
        {
            throw new InvalidFormatException();
        }
        if (!double.TryParse(attribute.Value, NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
        {
            throw new InvalidFormatException();
        }
        return value;
    }

    private static XmlAttribute? FindAttribute(XmlNode trackPoint, string name)
    {
        if (trackPoint.Attributes == null)
        {
            throw new InvalidFormatException();
        }
        for (int i = 0; i < trackPoint.Attributes.Count; ++i)
        {
            if (trackPoint.Attributes[i].Name == name)
            {
                return trackPoint.Attributes[i];
            }
        }
        return null;
    }
}