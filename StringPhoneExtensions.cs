using System;
using System.Text.RegularExpressions;

public static class PhoneExtensions
{
    public static string ToPrivatFormat(this string phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
            return string.Empty;

        // Залишаємо лише цифри
        string digits = Regex.Replace(phone, @"\D", "");

        // Якщо номер починається з 0 або 80 — додаємо код країни +38
        if (digits.StartsWith("0"))
            digits = "38" + digits;
        else if (digits.StartsWith("80"))
            digits = "3" + digits;
        else if (!digits.StartsWith("380"))
            digits = "380" + digits;

        // Перевірка довжини
        if (digits.Length != 12)
            return phone; // повертає оригінал, якщо не підходить

        // Форматування +38 (XXX) XXX-XX-XX
        return $"+{digits.Substring(0, 2)} ({digits.Substring(2, 3)}) {digits.Substring(5, 3)}-{digits.Substring(8, 2)}-{digits.Substring(10, 2)}";
    }
}
