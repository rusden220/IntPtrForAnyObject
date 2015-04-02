using System;

namespace IntPtrForAnyObject
{

	class Program
	{
		static void Main(string[] args)
		{
			string str = "Hello, World!";		
			Pointer pointer = new Pointer(str);
			IntPtr intPtr = pointer.GetPointer();
			unsafe //if you any problem try need enable an unsafe code in the project properties
			{
				int* x = (int*)pointer.IntPtr.ToInt32();
				x++;
				x++;//double increment because type of the variable is the reference type
				Console.WriteLine((char)*x);
				int num = int.MaxValue;
				int* y = (int *)pointer.GetPointer(num);
				y++;//one increment because type of the variable is the value type
				Console.WriteLine(*y);
			}

			Console.WriteLine("How it looks like inside");
			new Offset();
			Console.WriteLine("Press any key");
			Console.ReadKey();
		}
	}
}
