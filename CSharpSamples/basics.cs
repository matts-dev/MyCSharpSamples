using System;

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

			Console.WriteLine("Chars are 2 bytes for unicode", sizeof(char)); //notice that sizeof works in c# too

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
			


#pragma warning restore CS0219 // Variable is assigned but its value is never used
		}
	}
}
