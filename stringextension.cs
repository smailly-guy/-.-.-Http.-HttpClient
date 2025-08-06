using System;
using System.Net.Http;
using System.Threading.Tasks;

public static class StringExtensions
{
    public static async Task<string> ToBase64ImageAsync(this string imageUrl)
    {
        if (string.IsNullOrWhiteSpace(imageUrl))
            throw new ArgumentException("URL не може бути порожнім.");

        using (HttpClient client = new HttpClient())
        {
            try
            {
                var imageBytes = await client.GetByteArrayAsync(imageUrl);

                string extension = GetImageExtension(imageUrl); // jpg, png тощо
                string base64 = Convert.ToBase64String(imageBytes);
                return $"data:image/{extension};base64,{base64}";
            }
            catch (Exception ex)
            {
                throw new Exception($"Помилка при завантаженні або конвертації зображення: {ex.Message}");
            }
        }
    }

    private static string GetImageExtension(string url)
    {
        var uri = new Uri(url);
        string path = uri.AbsolutePath;
        string ext = System.IO.Path.GetExtension(path).TrimStart('.').ToLower();

        return string.IsNullOrWhiteSpace(ext) ? "jpeg" : ext;
    }
}
