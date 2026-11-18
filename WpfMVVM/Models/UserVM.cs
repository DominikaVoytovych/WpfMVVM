using Bogus; 
using System; 
using System.Collections.Specialized; 
using System.ComponentModel; 
using System.Text; 

namespace WpfMVVM.Models; 

public class UserVM : INotifyPropertyChanged // клас користувача, який повідомляє таблицю про зміну своїх полів
{
    public int Id { get; set; } // унікальний номер користувача

    private string _name = null!; // приховане поле для зберігання імені
    private string _image = null!; // приховане поле для зберігання посилання на фото
    private string _phone = null!; // приховане поле для зберігання номера телефону

    public string Name // публічна властивість імені, до якої прив'язана таблиця
    {
        get { return _name; } // повертаємо поточне значення імені
        set // спрацьовує при зміні імені
        {
            if (_name != value) // перевіряємо, чи нове ім'я відрізняється від старого
            {
                _name = value; // записуємо нове ім'я у приховане поле
                NotifyPropertyChanged(nameof(Name)); // повідомляємо інтерфейс, що ім'я оновилося
            }
        }
    }

    public string Image // публічна властивість фото, до якої прив'язана таблиця
    {
        get { return _image; } // повертаємо поточне посилання на фото
        set // спрацьовує при зміні фото
        {
            if (_image != value) // перевіряємо, чи нове посилання відрізняється від старого
            {
                _image = value; // записуємо нове посилання у приховане поле
                NotifyPropertyChanged(nameof(Image)); // повідомляємо інтерфейс, що фото оновилося
            }
        }
    }

    public string Phone // публічна властивість телефону, до якої прив'язана таблиця
    {
        get { return _phone; } // повертаємо поточний номер телефону
        set // спрацьовує при зміні телефону
        {
            if (_phone != value) // перевіряємо, чи новий номер відрізняється від старого
            {
                _phone = value; // записуємо новий номер у приховане поле
                NotifyPropertyChanged(nameof(Phone)); // повідомляємо інтерфейс, що телефон оновився
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged; // подія, на яку підписується wpf для відстеження змін

    public void NotifyPropertyChanged(string propName) // метод для запуску сповіщення про зміну властивості
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName)); // якщо є підписники, передаємо їм назву зміненого поля
    }

    public static UserVM CreateRandom(int id) // метод для створення одного випадкового користувача через bogus
    {
        var faker = new Faker<UserVM>("uk") // налаштовуємо генератор для моделі UserVM українською мовою
            .RuleFor(u => u.Id, id) // задаємо переданий порядковий номер
            .RuleFor(u => u.Name, f => f.Name.FullName()) // генеруємо випадкове ім'я та прізвище
            .RuleFor(u => u.Phone, f => f.Phone.PhoneNumber("+38(0##) ### ## ##")) // генеруємо випадковий номер телефону за шаблоном
            .RuleFor(u => u.Image, f => $"https://i.pravatar.cc/300?img={f.Random.Number(1, 70)}"); // підставляємо випадкове фото за номером від 1 до 70

        return faker.Generate(); // створюємо та повертаємо готового користувача
    }
}