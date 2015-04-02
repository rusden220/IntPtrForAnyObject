using System;
using System.Runtime.InteropServices;

namespace IntPtrForAnyObject
{
	[StructLayout(LayoutKind.Explicit)]
	public class Offset
	{
		/// <summary>
		/// just wrapper
		/// </summary>
		public class Field
		{
			public object _int;
		}
		[FieldOffset(0)]
		public Field _field;//field for test

		[FieldOffset(0)]
		public int[] array;//showing ram damp

		public Offset()
		{
			int len = 12;
			array = new int[len];
			_field = new Field();
			_field._int = int.MaxValue;

			Pointer pointer = new Pointer(_field._int);
			IntPtr intPtr = pointer.GetPointer();

			Console.WriteLine("pointer for object " + intPtr.ToString());
			Console.WriteLine("memory damp");
			for (int i = 0; i < len; i++)
			{
				if (array[i] == intPtr.ToInt32())//if use the reference type
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine(i.ToString() + " " + array[i].ToString());
					Console.ForegroundColor = ConsoleColor.Gray;
				}
				else if (array[i] == (int)_field._int)//if use the value type
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine(i.ToString() + " " + array[i].ToString());
					Console.ForegroundColor = ConsoleColor.Gray;
				}
				else
				{ Console.WriteLine(i.ToString() + " " + array[i].ToString()); }
			}

		}
	}


}
