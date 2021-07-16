using System;

namespace CSharpSamples
{
	class CSharpBasicsClass
	{
		// the compiler complains if we try to make a free standing funtion, like we can in c++. :(  hence the static funcion.
		static public void TheBasics()
		{
			//the data types
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


#pragma warning restore CS0219 // Variable is assigned but its value is never used
		}
	}
}
