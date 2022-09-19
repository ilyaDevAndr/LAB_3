using LAB_3.Models;
using LAB_3.Sevices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LAB_3.ViewModels
{
    public class CountryViewModel : BindableObject
    {
        // Переменная для хранения состояния
        // выбранного элемента коллекции
        private Country _selectedItem;
        // Объект с логикой по извлечению данных
        // из источника
        FoodService countryService = new();

        // Коллекция извлекаемых объектов
        public ObservableCollection<Country> Foods { get; } = new();

        // Конструктор с вызовом метода
        // получения данных
        public CountryViewModel()
        {
            GetFoodsAsync();
        }

        // Публичное свойство для представления
        // описания выбранного элемента из коллекции
        public string Desc { get; set; }

        // Свойство для представления и изменения
        // состояния выбранного объекта
        public Country SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                Desc = value?.Description;
                // Метод отвечает за обновление данных
                // в реальном времени
                OnPropertyChanged(nameof(Desc));
            }
        }

        // Команда для добавления нового элемента
        // в коллекцию
        public ICommand AddItemCommand => new Command(() => AddNewItem());

        // Метод для создания нового элемента
        private void AddNewItem()
        {
            Foods.Add(new Country
            {
                Id = Foods.Count + 1,
                Name = "Title " + Foods.Count,
                Description = "Description",
                
            });
        }

        // Метод получения коллекции объектов
        async Task GetFoodsAsync()
        {
            try
            {
                var country = await countryService.GetFood();

                if (Foods.Count != 0)
                    Foods.Clear();

                foreach (var food in country)
                {
                    Foods.Add(food);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Ошибка!",
                    $"Что-то пошло не так: {ex.Message}", "OK");
            }
        }
    }
}


