using System;

class Program
{
    static void Main()
    {


        string rawPhone = "0671234567";
        string formatted = rawPhone.ToPrivatFormat();
        Console.WriteLine(formatted);  // +38 (067) 123-45-67

        string raw2 = "380991112233";
        Console.WriteLine(raw2.ToPrivatFormat());  // +38 (099) 111-22-33

        string invalid = "123";
        Console.WriteLine(invalid.ToPrivatFormat());  // 123 (неформатований)
    }
}
