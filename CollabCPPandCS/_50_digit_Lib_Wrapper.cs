using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace CollabCPPandCS
{
    class _50_digit_Lib_Wrapper
    {
        [DllImport(@"C:\Users\ktuser\Desktop\abhamid\CollabCPPandCS\Debug\CPPHelper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void invert_obj(int[] a);

        [DllImport(@"C:\Users\ktuser\Desktop\abhamid\CollabCPPandCS\Debug\CPPHelper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void print_obj(int[] a);

        [DllImport(@"C:\Users\ktuser\Desktop\abhamid\CollabCPPandCS\Debug\CPPHelper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void add_obj(int[] a, int[] b, int[] c);

        [DllImport(@"C:\Users\ktuser\Desktop\abhamid\CollabCPPandCS\Debug\CPPHelper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void sub_obj(int[] a, int[] b, int[] c);

        [DllImport(@"C:\Users\ktuser\Desktop\abhamid\CollabCPPandCS\Debug\CPPHelper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void diminish_obj(int[] a);

        [DllImport(@"C:\Users\ktuser\Desktop\abhamid\CollabCPPandCS\Debug\CPPHelper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void swap_clone_obj(int[] a, int[] b);

        [DllImport(@"C:\Users\ktuser\Desktop\abhamid\CollabCPPandCS\Debug\CPPHelper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int greater_obj(int[] a, int[] b);

        [DllImport(@"C:\Users\ktuser\Desktop\abhamid\CollabCPPandCS\Debug\CPPHelper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int smaller_obj(int[] a, int[] b);

        [DllImport(@"C:\Users\ktuser\Desktop\abhamid\CollabCPPandCS\Debug\CPPHelper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int equal_obj(int[] a, int[] b);

        [DllImport(@"C:\Users\ktuser\Desktop\abhamid\CollabCPPandCS\Debug\CPPHelper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int is_zero_obj(int[] a);

        [DllImport(@"C:\Users\ktuser\Desktop\abhamid\CollabCPPandCS\Debug\CPPHelper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int mul_obj(int[] a, int[] b, int[] c);

        [DllImport(@"C:\Users\ktuser\Desktop\abhamid\CollabCPPandCS\Debug\CPPHelper.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int div_obj(int[] a, int[] b, int[] c);


        public static string ToString_obj(int[] a)
        {
            diminish_obj(a);

            if (a[0] == -1)
                return "0";

            string ret = "";

            for (int i = 0; a[i] != -1; i++)
            {
                ret += a[i].ToString();
            }

            return ret;
        }

        public static int[] cast_obj(int[] input)
        {
            int[] a = new int[100];

            for (int i = 0; i < input.Length; i++)
                a[i] = input[i];

            a[input.Length] = -1;

            return a;
        }

        public static int[] cast_obj(string s = "")
        {
            int[] ret = new int[100];

            int i = 0;
            for (i = 0; i < s.Length; i++)
                ret[i] = int.Parse(s[i].ToString());
            ret[i] = -1;

            return ret;
        }

        public static void Debug_obj(int[] a)
        {
            for (int i = 0; i < 100; i++)
                Console.Write(a[i]);
            Console.WriteLine();
        }
    }
}
