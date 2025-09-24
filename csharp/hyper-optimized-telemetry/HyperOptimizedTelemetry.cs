using System;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        // Determine type and size
        byte prefix;
        byte[] payload;

        if (reading >= 0 && reading <= ushort.MaxValue)
        {
            prefix = 2; // ushort
            payload = BitConverter.GetBytes((ushort)reading);
        }
        else if (reading >= 2147483648 && reading <= uint.MaxValue)
        {
            prefix = 4; // uint
            payload = BitConverter.GetBytes((uint)reading);
        }
        else if (reading >= 4294967296 && reading <= 9223372036854775807)
        {
            prefix = (byte) (256 - 8); // long
            payload = BitConverter.GetBytes(reading);
        }
        else if (reading >= -32768 && reading <= -1)
        {
            prefix = (byte)(256 - 2); // short
            payload = BitConverter.GetBytes((short)reading);
        }
        else if (reading >= -2147483648 && reading <= -32769)
        {
            prefix = (byte)(256 - 4); // int
            payload = BitConverter.GetBytes((int)reading);
        }
         else if (reading >= 65536 && reading <= 2147483647)
        {
            prefix = (byte)(256 - 4); // int
            payload = BitConverter.GetBytes((int)reading);
        }
        else if (reading >= -9223372036854775808 && reading <= -2147483649)
        {
            prefix = (byte)(256 - 8); // long
            payload = BitConverter.GetBytes(reading);
        }
        else
        {
            // Out of range
            return new byte[9];
        }

        // Build buffer
        var buffer = new byte[9];
        buffer[0] = prefix;
        Array.Copy(payload, 0, buffer, 1, payload.Length);
        // Remaining bytes are zero by default
        return buffer;
    }

    public static long FromBuffer(byte[] buffer)
    {
        if (buffer == null || buffer.Length != 9)
            return 0;

        byte prefix = buffer[0];

        if (prefix == 2)
            return BitConverter.ToUInt16(buffer, 1);
        if (prefix == 4)
            return BitConverter.ToUInt32(buffer, 1);
        if (prefix == 8)
            return BitConverter.ToInt64(buffer, 1);
        if (prefix == 254) // 256 - 2
            return BitConverter.ToInt16(buffer, 1);
        if (prefix == 252) // 256 - 4
            return BitConverter.ToInt32(buffer, 1);
        if (prefix == 248) // 256 - 8
            return BitConverter.ToInt64(buffer, 1);

        return 0; // Unexpected prefix
    }
}