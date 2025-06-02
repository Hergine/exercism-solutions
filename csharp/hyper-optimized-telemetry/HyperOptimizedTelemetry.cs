using System;
using System.Runtime.InteropServices;

public static class TelemetryBuffer
{
    public static Type GetTypeOfInteger(long value)
    {
        if (value >= -32768 && value <= -1) return typeof(short);
        else if (value >= 0 && value <= 65535) return typeof(ushort);
        else if (value >= 65536 && value <= 2_147_483_647 || value >= -2147483648 && value <= -32769) return typeof(int);
        else if (value >= 2147483648 && value <= 4294967295) return typeof(uint);
        else return typeof(long);
    }
    public static byte[] ToBuffer(long reading)
    {
        // Allocate a buffer of 9 bytes (1 byte for the type, 8 bytes for the long)
        byte[] buffer = new byte[9];

        //Get the type of the number
        Type numberType = GetTypeOfInteger(reading);


        //Determine the byte size of the number and assign it to the first byte of the buffer
        int byteSize = Marshal.SizeOf(numberType);
        if (reading < 0)
        {
            buffer[0] = (byte)(256 - byteSize);
        }
        else
        {
            buffer[0] = (byte)byteSize;
        }


        //Convert the number to bytes and copy it to the buffer
        if (numberType == typeof(byte))
        {
            buffer[1] = (byte)reading;
        }
        else if (numberType == typeof(short))
        {
            short number = (short)reading;
            byte[] numberBytes = BitConverter.GetBytes(number);
            Buffer.BlockCopy(numberBytes, 0, buffer, 1, byteSize);
        }
        else if (numberType == typeof(ushort))
        {
            ushort number = (ushort)reading;
            byte[] numberBytes = BitConverter.GetBytes(number);
            Buffer.BlockCopy(numberBytes, 0, buffer, 1, byteSize);
        }
        else if (numberType == typeof(int))
        {
            int number = (int)reading;
            byte[] numberBytes = BitConverter.GetBytes(number);
            Buffer.BlockCopy(numberBytes, 0, buffer, 1, byteSize);
        }
        else if (numberType == typeof(uint))
        {
            uint number = (uint)reading;
            byte[] numberBytes = BitConverter.GetBytes(number);
            Buffer.BlockCopy(numberBytes, 0, buffer, 1, byteSize);
        }
        else
        {
            long number = reading;
            byte[] numberBytes = BitConverter.GetBytes(number);
            Buffer.BlockCopy(numberBytes, 0, buffer, 1, byteSize);
        }

        return buffer;
    }

    public static long FromBuffer(byte[] buffer)
    {
        Array.Reverse(buffer);
        return BitConverter.ToInt64(buffer, 1);
    }
}
