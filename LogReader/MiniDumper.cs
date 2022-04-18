﻿using System.Runtime.InteropServices;

namespace LogReader
{
    // Credits Jochen Kalmbach @ http://blog.kalmbach-software.de/2008/12/13/writing-minidumps-in-c/
	// Credits Don Dumitru @ http://blogs.msdn.com/b/dondu/archive/2010/10/24/writing-minidumps-in-c.aspx
	// Credits Teoman Soygul @ http://nbug.codeplex.com/
    static class MiniDumper
    {
        [Flags]
        public enum Typ : uint
        {
            // From dbghelp.h:
            MiniDumpNormal = 0x00000000,
            MiniDumpWithDataSegs = 0x00000001,
            MiniDumpWithFullMemory = 0x00000002,
            MiniDumpWithHandleData = 0x00000004,
            MiniDumpFilterMemory = 0x00000008,
            MiniDumpScanMemory = 0x00000010,
            MiniDumpWithUnloadedModules = 0x00000020,
            MiniDumpWithIndirectlyReferencedMemory = 0x00000040,
            MiniDumpFilterModulePaths = 0x00000080,
            MiniDumpWithProcessThreadData = 0x00000100,
            MiniDumpWithPrivateReadWriteMemory = 0x00000200,
            MiniDumpWithoutOptionalData = 0x00000400,
            MiniDumpWithFullMemoryInfo = 0x00000800,
            MiniDumpWithThreadInfo = 0x00001000,
            MiniDumpWithCodeSegs = 0x00002000,
            MiniDumpWithoutAuxiliaryState = 0x00004000,
            MiniDumpWithFullAuxiliaryState = 0x00008000,
            MiniDumpWithPrivateWriteCopyMemory = 0x00010000,
            MiniDumpIgnoreInaccessibleMemory = 0x00020000,
            MiniDumpValidTypeFlags = 0x0003ffff,
        };

        //typedef struct _MINIDUMP_EXCEPTION_INFORMATION {
        //    DWORD ThreadId;
        //    PEXCEPTION_POINTERS ExceptionPointers;
        //    BOOL ClientPointers;
        //} MINIDUMP_EXCEPTION_INFORMATION, *PMINIDUMP_EXCEPTION_INFORMATION;
        [StructLayout(LayoutKind.Sequential, Pack = 4)]  // Pack=4 is important! So it works also for x64!
        struct MiniDumpExceptionInformation
        {
            public uint ThreadId;
            public IntPtr ExceptionPointers;
            [MarshalAs(UnmanagedType.Bool)]
            public bool ClientPointers;
        }

        static class NativeMethods
        {
            // Overload requiring MiniDumpExceptionInformation 
            [DllImport("dbghelp.dll", EntryPoint = "MiniDumpWriteDump", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]
            public static extern bool MiniDumpWriteDump(IntPtr hProcess, uint processId, IntPtr hFile, uint dumpType, ref MiniDumpExceptionInformation expParam, IntPtr userStreamParam, IntPtr callbackParam);

            // Overload supporting MiniDumpExceptionInformation == NULL 
            [DllImport("dbghelp.dll", EntryPoint = "MiniDumpWriteDump", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]
            public static extern bool MiniDumpWriteDump(IntPtr hProcess, uint processId, IntPtr hFile, uint dumpType, IntPtr expParam, IntPtr userStreamParam, IntPtr callbackParam);

            [DllImport("kernel32.dll", EntryPoint = "GetCurrentThreadId", ExactSpelling = true)]
            public static extern uint GetCurrentThreadId();

            [DllImport("kernel32.dll", EntryPoint = "GetCurrentProcess", ExactSpelling = true)]
            public static extern IntPtr GetCurrentProcess();

            [DllImport("kernel32.dll", EntryPoint = "GetCurrentProcessId", ExactSpelling = true)]
            public static extern uint GetCurrentProcessId();
        }

        internal static bool Write(string fileName)
        {
            return Write(fileName, Typ.MiniDumpWithFullMemory);
        }
        internal static bool Write(string fileName, Typ dumpTyp)
        {
            using (var fs = new System.IO.FileStream(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None))
            {
                MiniDumpExceptionInformation exp;
                exp.ThreadId = NativeMethods.GetCurrentThreadId();
                exp.ClientPointers = false;
                exp.ExceptionPointers = System.Runtime.InteropServices.Marshal.GetExceptionPointers();
                bool bRet = false;
				// If program runs as x86 on a x64 machine, then Marshall.GetExceptionPointers can return IntPtr.Zero
                if (exp.ExceptionPointers == IntPtr.Zero)
                {
                    bRet = NativeMethods.MiniDumpWriteDump(NativeMethods.GetCurrentProcess(), NativeMethods.GetCurrentProcessId(), fs.SafeFileHandle.DangerousGetHandle(), (uint)dumpTyp, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
                }
                else
                {
                    bRet = NativeMethods.MiniDumpWriteDump(NativeMethods.GetCurrentProcess(), NativeMethods.GetCurrentProcessId(), fs.SafeFileHandle.DangerousGetHandle(), (uint)dumpTyp, ref exp, IntPtr.Zero, IntPtr.Zero);                    
                }
                return bRet;
            }
        }
    }
}
