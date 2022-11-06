namespace BMIRussian.GPX2VBO;

public class VBOSerializer
{
    public static void Serialize(IEnumerable<VBOData> data, Stream stream)
    {
        var text = new StreamWriter(stream);
        WriteHeader(text);
        text.WriteLine("");
        WriteColumnNames(text);
        text.WriteLine("");
        WriteData(text, data);
    }

    private static void WriteData(TextWriter text, IEnumerable<VBOData> data)
    {
        text.WriteLine("[data]");
        foreach (var record in data)
        {
            WriteRecord(text, record);
        }
    }

    private static void WriteRecord(TextWriter text, VBOData data)
    {
        // 035634,90 +3305,14092000 -4380,10890000 +0093,500000 001,01 009 000,00 +00,00 -0,02 -0,13 -0,97 -0,42 -0,18 -0,02 +360,00 +0,00 00000 000 +00 000
    }

    private static void WriteColumnNames(TextWriter text)
    {
        text.WriteLine("[column names]");
        text.WriteLine("Time");
        text.WriteLine("latitude");
        text.WriteLine("longitude");
        text.WriteLine("height");
        text.WriteLine("HDoP");
        text.WriteLine("satellites");
        text.WriteLine("velocity kmh");
        text.WriteLine("heading");
        text.WriteLine("Accel_Lon");
        text.WriteLine("Accel_Lat");
        text.WriteLine("Accel_Alt");
        text.WriteLine("GyroX");
        text.WriteLine("GyroY");
        text.WriteLine("GyroZ");
        text.WriteLine("Yaw");
        text.WriteLine("slip");
        text.WriteLine("OBDII_Revs");
        text.WriteLine("OBDII_Temp");
        text.WriteLine("OBDII_Throttle");
        text.WriteLine("OBDII_Load");
    }

    private static void WriteHeader(TextWriter text)
    {
        text.WriteLine("[header]");
        text.WriteLine("time");
        text.WriteLine("latitude");
        text.WriteLine("longitude");
        text.WriteLine("height");
        text.WriteLine("HDoP");
        text.WriteLine("satellites");
        text.WriteLine("velocity kmh");
        text.WriteLine("heading");
        text.WriteLine("Accel_Lon");
        text.WriteLine("Accel_Lat");
        text.WriteLine("Accel_Alt");
        text.WriteLine("GyroX");
        text.WriteLine("GyroY");
        text.WriteLine("GyroZ");
        text.WriteLine("Yaw");
        text.WriteLine("Slip Angle");
        text.WriteLine("OBDII_Revs");
        text.WriteLine("OBDII_Temp");
        text.WriteLine("OBDII_Throttle");
        text.WriteLine("OBDII_Load");
    }
}