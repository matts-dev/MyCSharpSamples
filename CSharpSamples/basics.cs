using System;
using BasicSyntaxNamespace;

namespace BasicSyntaxNamespace
{
	class ExampleClass
	{
		public double MyPublicDouble = 2.0;
		protected double MyProtectedDouble = 3.0;
		private double MyExplicitPrivateDouble = 4.0;
		double MyPrivateDouble = 1.0;

		void LogValues_Private()
		{
			Console.WriteLine("Logging the class variables.");
			Console.WriteLine(MyPublicDouble);
			Console.WriteLine(MyProtectedDouble);
			Console.WriteLine(MyPrivateDouble);
			Console.WriteLine(MyExplicitPrivateDouble);
		}
		public void LogValues_Public()
		{
			LogValues_Private();
		}
	}

	class BaseClass
	{

	}

	class ChildClass : BaseClass
	{
		public void print() { Console.WriteLine("Child Print"); }
	}
}


namespace CSharpSamples
{
	class CSharpBasicsClass
	{
		// the compiler complains if we try to make a free standing funtion, like we can in c++. :(  hence the static funcion.
		static public void TheBasics()
		{
			// the data types 
			// These are called Value Types, derived System.ValueType, in c#. (except for string, which is a reference type)
			// value types appear to be like stackvariables in c++, which are fast to use. 
			// structs are value types (and have value semantics), while classes are reference types. https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/struct
			// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-types
			// boxing/unboxing is wrapping/unwrapping a valuetype in a referencetype. MS usees "stack/heap" terminology in this page, so things appear to be like c++  https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/boxing-and-unboxing
			// by default valuetypes are copied when passed to/returned from functions.
#pragma warning disable CS0219 // Variable is assigned but its value is never used
			byte MyByte = 1;
			short MyShort = 2;
			int MyInt = -3;
			uint MyUnsignedInt = 3;
			long MyLong = 4;
			float MyFloat = 1.0f;
			double MyDouble = 2.0d; //d optional
			decimal MyDecimal = 3.0m; //can captialize M
			char MyTwoByteChar = 'd';
			bool MyBool = false;

			Console.WriteLine("Chars are 2 bytes for unicode: {0}", sizeof(char)); //notice that sizeof works in c# too

			string MyString = "this is a unicode string.";

			Console.WriteLine(MyString);

			//c# has an auto keyword, but it is called var instead.
			var MyBool2 = true;
			var MyChar2 = 'd';

			//c# formatted strings and ranges of float shown in 1
			Console.WriteLine("floats go from {0} {1}", float.MinValue, float.MaxValue); //floats go from -3.402823E+38 3.402823E+38
			Console.WriteLine("doubles go from {0} {1}", double.MinValue, double.MaxValue);//doubles go from -1.79769313486232E+308 1.79769313486232E+308
																						   // note, decimal is not IEEE754 https://stackoverflow.com/questions/9079225/decimal-type-in-c-sharp-vs-ieee-754-standard
																						   //		The decimal type is a 128 - bit data type suitable for financial and monetary calculations
																						   //		
			Console.WriteLine("decimal go from {0} {1}", decimal.MinValue, decimal.MaxValue);//decimal go from -79228162514264337593543950335 79228162514264337593543950335

			const float MY_CONST_VALUE = 5.0f;

			//explicit casting and explicit casting. it appears dynamic/polymorphic casts are done with "as" and "is" operators.
			byte SomeByte = 4;
			int SomeInt = SomeByte;
			byte CannotImplicitCast = (byte)SomeInt;
			float SomeFloat = SomeInt;
			int AnotherInt = (int)SomeFloat;

			string StringNumber = "123";
			int IntFromParse = int.Parse(StringNumber); // IMO this seems cooler that calling convert
			int IntFromConvert = Convert.ToInt32(StringNumber);

			BasicSyntaxNamespace.ExampleClass Obj = new BasicSyntaxNamespace.ExampleClass();
			Console.WriteLine("public variable is: {0}", Obj.MyPublicDouble);
			//can't access these as as they're private/protected
			//Console.WriteLine(Obj.MyProtectedDouble);
			//Console.WriteLine(Obj.MyPrivateDouble);
			//Console.WriteLine(Obj.MyExplicitPrivateDouble);
			Obj.LogValues_Public();
			//Obj.LogValues_Private(); //private method

			//c# has much of the c/c++ syntax.
#pragma warning disable CS0168 // Variable is declared but never used
			int ii, jj, kk;
			float AnLValue = /*AnRValue*/54.0f;
#pragma warning restore CS0168 // Variable is declared but never used

			Console.Write("Enter a number ");
			int UsersNumber = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("You picked: {0}", UsersNumber);

			//examples of syntax for literals
			uint ui32_a = 100;      //read that this is an alias of UInt32 https://www.includehelp.com/dot-net/difference-between-uint-UInt16-UInt32-and-UInt64-in-c-sharp.aspx
			UInt32 ui32_b = 100u;
			int int32_a = 0xdeed;
			long int64_a = 0xDEEDL; //longs are 64bits, can end with L to make it a long
			ulong uint64_a = 99ul; //can uppercase UL
			//Int32 int32_a = 100u; compile error :)

			float a_float = 3.1415f;
			float another_float = 31415E-4f;

			char vertical_tab = '\v';
			char horizontal_tab = '\t';

			//string examplea = "string"" literals" " don't work like c" "in some ways";
			string exampleb = @"test @ string literal";
			string examplec = "plain old string";

			const int MyConstInt = 66;
			//MyConstInt = 3; //cannot do this, just like c/c++
			const string MyConstString = "An immutable string!";
			//MyConstString = "SomethingElse"; // error CS0131: The left-hand side of an assignment must be a variable, property or indexer

			// is and as keywords allow for RTTI, `as` is like a dynamic cast; `is` is also like a dynamic ast, but the assignment reads odd.
			BaseClass BaseRef = new ChildClass();
			if (BaseRef is ChildClass ChildRef)
			{
				ChildRef.print();
				Console.WriteLine("cast succeeded");

				//can also just use is, or as keyword
				ChildClass ChildRef2 = BaseRef as ChildClass;

			}
			else
			{
				Console.WriteLine("cast failed");
			}

			unsafe //requires compiling with unsafe
			{
				int* IntPtr = &MyInt;
				Console.WriteLine("Printing from a dereferenced pointer: {0}", *IntPtr);
			}

			Console.WriteLine("typeof operator on ChildClass: {0}", typeof(ChildClass));
			//Console.WriteLine("sizeof operator on ChildClass: {0}", sizeof(ChildClass)); compile error


#pragma warning restore CS0219 // Variable is assigned but its value is never used
		}
	}
}
