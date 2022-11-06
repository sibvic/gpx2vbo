using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace BMIRussian.GPX2VBO.Tests;

[TestClass]
public class VBOSerializerTests
{
    [TestMethod]
    public void Serialize()
    {
        var items = new List<VBOData>
        {
            new VBOData(new System.DateTime(2022, 06, 01, 1, 2, 3, 129),
                3305.14092000, -4380.10890000, 0093.500000, 001.01,
                009, 0, 0, 0.02, 0.13, -0.97, -0.42, -0.18, -0.02, 360.00, 0, 0, 0, 0, 0),
            new VBOData(new System.DateTime(2022, 06, 01, 1, 2, 3, 547),
                3305.14091, -4380.10891, 93.5, 1.01,
                9, 0, 0, -0.03, -0.14, -0.98, -0.02, -0.03, -0.18, 360.00, 0, 0, 0, 0, 0)
        };

        var stream = new MemoryStream();
        VBOSerializer.Serialize(items, stream);
        var reader = new StreamReader(stream);
        var savedLines = reader.ReadToEnd().Split('\n');
        var referenceLines = File.ReadAllLines(Path.Combine("data", "reference.vbo"));
        Assert.AreEqual(savedLines.Length, referenceLines.Length);
        for (int i = 0; i < savedLines.Length; ++i)
        {
            Assert.AreEqual(savedLines[i], referenceLines[i]);
        }
    }
}
