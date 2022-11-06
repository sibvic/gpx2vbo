namespace BMIRussian.GPX2VBO;

public record struct VBOData(DateTime Time, double Latitude, double Longitude, double Height, double HDoP,
    int Satellites, double VelocityKmh, double Heading, double Accel_Lon, double Accel_Lat, 
    double Accel_Alt, double GyroX, double GyroY, double GyroZ, double Yaw, double Slip,
    int OBDII_Revs, int OBDII_Temp, int ODBII_Throttle, int OBDII_Load);