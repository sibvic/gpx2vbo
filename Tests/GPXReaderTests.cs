using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BMIRussian.GPX2VBO.Tests;

[TestClass]
public class GPXReaderTests
{
    [TestMethod]
    public void Parse()
    {
        var data = GPXReader.Read(System.IO.Path.Combine("data", "sample.gpx")).ToList();
        Assert.AreEqual(2, data.Count);

        Assert.AreEqual(54.9728487, data[0].Latitude);
        Assert.AreEqual(73.3642732, data[0].Longitude);
        Assert.AreEqual(41.174, data[0].Height);
        Assert.AreEqual(new System.DateTime(2021, 03, 14, 10, 35, 21, 985), data[0].Time);
        Assert.AreEqual(131, data[0].HDOP);
        Assert.AreEqual(7.222, data[0].SpeedMS);

        Assert.AreEqual(54.9728521, data[1].Latitude);
        Assert.AreEqual(73.3642726, data[1].Longitude);
        Assert.AreEqual(41.175, data[1].Height);
        Assert.AreEqual(new System.DateTime(2021, 03, 14, 10, 35, 22, 040), data[1].Time);
        Assert.AreEqual(131, data[1].HDOP);
        Assert.AreEqual(7.119, data[1].SpeedMS);
    }
}