using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.InputEncoding = System.Text.Encoding.UTF8; // Підтримка українських символів у консолі
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string imageUrl = "https://raw.githubusercontent.com/github/explore/main/topics/csharp/csharp.png";
        string base64 = await imageUrl.ToBase64ImageAsync();
        Console.WriteLine(base64);


        try
        {
            string base64Image = await imageUrl.ToBase64ImageAsync();
            Console.WriteLine(base64Image); // Виведе Base64 у консоль
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка: " + ex.Message);
        }
    }
}
