
using LAB_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LAB_3.Sevices
{
    public class FoodService
    {
        // Создаем список для хранения данных из источника
        List<Country> foodList = new();

        // Метод GetFood() служит для извлечения и сруктурирования данных
        // в соответсвии с существующей моделью данных
        public async Task<IEnumerable<Country>> GetFood()
        {
            // Если список содержит какие-то элементы
            // то вернется последовательность с содержимым этого списка
            if (foodList?.Count > 0)
                return foodList;

            // В данном блоке кода осуществляется подключение, чтение
            // и дессериализация файла - источника данных
            using var stream = await FileSystem.OpenAppPackageFileAsync("country.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            foodList = JsonSerializer.Deserialize<List<Country>>(contents);

            return foodList;
        }
    }
}

