using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace GF.Encoder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private void Encoding_Click_1(object sender, RoutedEventArgs e)
        {
            string z = Type.Text;
            string c = Lang.Text;
            if (z == "Зашифровать" && c == "Русский")
            {
                string g = Encod.Text;
                if (g == "Виженера")
                {
                    string m = Enc.Text;
                    string k = Key.Text;

                    int nomer; // Номер в алфавите
                    int d; // Смещение
                    string s; //Результат
                    int j, f; // Переменная для циклов
                    int t = 0; // Преременная для нумерации символов ключа.

                    char[] massage = m.ToCharArray(); // Превращаем сообщение в массив символов.
                    char[] key = k.ToCharArray(); // Превращаем ключ в массив символов.

                    char[] alfavit = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я', 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О',
                'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я'};

                    // Перебираем каждый символ сообщения
                    for (int i = 0; i < massage.Length; i++)
                    {
                        // Ищем индекс буквы
                        for (j = 0; j < alfavit.Length; j++)
                        {
                            if (massage[i] == alfavit[j])
                            {
                                break;
                            }
                        }

                        if (j != 66) // Если j равно 66, значит символ не из алфавита
                        {
                            nomer = j; // Индекс буквы

                            // Ключ закончился - начинаем сначала.
                            if (t > key.Length - 1) { t = 0; }

                            // Ищем индекс буквы ключа
                            for (f = 0; f < alfavit.Length; f++)
                            {
                                if (key[t] == alfavit[f])
                                {
                                    break;
                                }
                            }

                            t++;

                            if (f != 66) // Если f равно 66, значит символ не из алфавита
                            {
                                d = nomer + f;
                            }
                            else
                            {
                                d = nomer;
                            }

                            // Проверяем, чтобы не вышли за пределы алфавита
                            if (d > 65)
                            {
                                d = d - 66;
                            }

                            massage[i] = alfavit[d]; // Меняем букву
                        }
                    }

                    s = new string(massage); // Собираем символы обратно в строку.
                    Dec.Text = s; // Записываем результат в textBox.
                }
                else if(g == "Цезаря")
                {
                    string m = Enc.Text;
                    string k = Key.Text;
                    char[] mas = m.ToCharArray();
                    int key = Convert.ToInt32(k);
                    string en; //результат

                    int p; //переменная в цикле
                    int n; //номер в алфавите
                    int d; //смещение
                    char[] alfavit = {'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О',
                'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я', 'а', 'б',
                'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м',
                'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я'};
                    //перебираем каждый символ сообщения
                    for (int i = 0; i < mas.Length; i++)
                    {
                        for (p = 0; p < alfavit.Length; p++)//поиск индекса буквы
                        {
                            if (mas[i] == alfavit[p])
                            {
                                break;
                            }
                        }
                        if (p != 66)
                        {
                            n = p; //индекс буквы
                            d = n + key; //делаем смещение по ключу 
                                         //Если вышли за пределы алфавита
                            if (d > 65)
                            {
                                d = d - 66;
                            }
                            mas[i] = alfavit[d]; //меняем букву
                        }
                    }
                    en = new string(mas); //собираем в одну строку
                    Dec.Text = en; // выводит на консоль
                }
            }
            else if (z == "Дешифровать" && c =="Русский")
            {
                string g = Encod.Text;
                if (g == "Виженера")
                {
                    string m = Enc.Text;
                    string k = Key.Text;

                    int nomer; // Номер в алфавите
                    int d; // Смещение
                    string s; //Результат
                    int j, f; // Переменная для циклов
                    int t = 0; // Преременная для нумерации символов ключа.

                    char[] massage = m.ToCharArray(); // Превращаем сообщение в массив символов.
                    char[] key = k.ToCharArray(); // Превращаем ключ в массив символов.

                    char[] alfavit = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м',
                'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я',
                'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О',
                'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я'};

                    // Перебираем каждый символ сообщения
                    for (int i = 0; i < massage.Length; i++)
                    {
                        // Ищем индекс буквы
                        for (j = 0; j < alfavit.Length; j++)
                        {
                            if (massage[i] == alfavit[j])
                            {
                                break;
                            }
                        }

                        if (j != 66) // Если j равно 66, значит символ не из алфавита
                        {
                            nomer = j; // Индекс буквы

                            // Ключ закончился - начинаем сначала.
                            if (t > key.Length - 1) { t = 0; }

                            // Ищем индекс буквы ключа
                            for (f = 0; f < alfavit.Length; f++)
                            {
                                if (key[t] == alfavit[f])
                                {
                                    break;
                                }
                            }

                            t++;

                            if (f != 66) // Если f равно 66, значит символ не из алфавита
                            {
                                d = nomer - f;
                            }
                            else
                            {
                                d = nomer;
                            }

                            // Проверяем, чтобы не вышли за пределы алфавита
                            if (d < 0)
                            {
                                d = d + 65;
                            }

                            massage[i] = alfavit[d]; // Меняем букву
                        }
                    }

                    s = new string(massage); // Собираем символы обратно в строку.
                    Dec.Text = s; // Записываем результат в textBox.
                }
                else if (g == "Цезаря")
                {
                    string m = Enc.Text;
                    string k = Key.Text;
                    char[] text = m.ToCharArray();
                    int key = Convert.ToInt32(k);
                    string pa; //результат
                    int p; //переменная в цикле

                    int n; //номер в алфавите
                    int d; //смещение
                    char[] alfavit = {'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О',
                'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я', 'а', 'б',
                'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м',
                'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я'};
                    //перебираем каждый символ сообщения
                    for (int l = 0; l < text.Length; l++)
                    {
                        for (p = 0; p < alfavit.Length; p++)//поиск индекса буквы
                        {
                            if (text[l] == alfavit[p])
                            {
                                break;
                            }
                        }
                        if (p != 66)
                        {
                            n = p; //индекс буквы
                            d = n - key; //делаем смещение по ключу 
                                         //Если вышли за пределы алфавита
                            if (d < 0)
                            {
                                d = d + 66;
                            }
                            text[l] = alfavit[d]; //меняем букву
                        }
                    }
                    pa = new string(text); //собираем в одну строку
                    Dec.Text = pa; // выводит на консоль; 
                }
            }
            
            if (z == "Зашифровать" && c == "Английский")
            {
                string g = Encod.Text;
                if (g == "Виженера")
                {
                    string m = Enc.Text;
                    string k = Key.Text;
                    int nomer; // Номер в алфавите
                    int d; // Смещение
                    string s; //Результат
                    int j, f; // Переменная для циклов
                    int t = 0; // Преременная для нумерации символов ключа.

                    char[] massage = m.ToCharArray(); // Превращаем сообщение в массив символов.
                    char[] key = k.ToCharArray(); // Превращаем ключ в массив символов.

                    char[] alfavit = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

                    // Перебираем каждый символ сообщения
                    for (int i = 0; i < massage.Length; i++)
                    {
                        // Ищем индекс буквы
                        for (j = 0; j < alfavit.Length; j++)
                        {
                            if (massage[i] == alfavit[j])
                            {
                                break;
                            }
                        }

                        if (j != 52) // Если j равно 52, значит символ не из алфавита
                        {
                            nomer = j; // Индекс буквы

                            // Ключ закончился - начинаем сначала.
                            if (t > key.Length - 1) { t = 0; }

                            // Ищем индекс буквы ключа
                            for (f = 0; f < alfavit.Length; f++)
                            {
                                if (key[t] == alfavit[f])
                                {
                                    break;
                                }
                            }

                            t++;

                            if (f != 52) // Если f равно 52, значит символ не из алфавита
                            {
                                d = nomer + f;
                            }
                            else
                            {
                                d = nomer;
                            }

                            // Проверяем, чтобы не вышли за пределы алфавита
                            if (d > 51)
                            {
                                d = d - 52;
                            }

                            massage[i] = alfavit[d]; // Меняем букву
                        }
                    }
                    s = new string(massage); // Собираем символы обратно в строку.
                    Dec.Text = s; // Записываем результат в textBox.
                }
                else if (g == "Цезаря")
                {
                    string m = Enc.Text;
                    string k = Key.Text;
                    char[] mas = m.ToCharArray();
                    int key = Convert.ToInt32(k);
                    string en; //результат

                    int p; //переменная в цикле
                    int n; //номер в алфавите
                    int d; //смещение
                    char[] alfavit = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
                    //перебираем каждый символ сообщения
                    for (int i = 0; i < mas.Length; i++)
                    {
                        for (p = 0; p < alfavit.Length; p++)//поиск индекса буквы
                        {
                            if (mas[i] == alfavit[p])
                            {
                                break;
                            }
                        }
                        if (p != 52)
                        {
                            n = p; //индекс буквы
                            d = n + key; //делаем смещение по ключу 
                                         //Если вышли за пределы алфавита
                            if (d > 51)
                            {
                                d = d - 52;
                            }
                            mas[i] = alfavit[d]; //меняем букву
                        }
                    }
                    en = new string(mas); //собираем в одну строку
                    Dec.Text = en; // выводит на консоль
                }

            }
            else if(z == "Дешифровать" && c == "Английский")
            {
                string g = Encod.Text;
                if (g == "Виженера")
                {
                    string m = Enc.Text;
                    string k = Key.Text;

                    int nomer; // Номер в алфавите
                    int d; // Смещение
                    string s; //Результат
                    int j, f; // Переменная для циклов
                    int t = 0; // Преременная для нумерации символов ключа.

                    char[] massage = m.ToCharArray(); // Превращаем сообщение в массив символов.
                    char[] key = k.ToCharArray(); // Превращаем ключ в массив символов.

                    char[] alfavit = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

                    // Перебираем каждый символ сообщения
                    for (int i = 0; i < massage.Length; i++)
                    {
                        // Ищем индекс буквы
                        for (j = 0; j < alfavit.Length; j++)
                        {
                            if (massage[i] == alfavit[j])
                            {
                                break;
                            }
                        }

                        if (j != 52) // Если j равно 52, значит символ не из алфавита
                        {
                            nomer = j; // Индекс буквы

                            // Ключ закончился - начинаем сначала.
                            if (t > key.Length - 1) { t = 0; }

                            // Ищем индекс буквы ключа
                            for (f = 0; f < alfavit.Length; f++)
                            {
                                if (key[t] == alfavit[f])
                                {
                                    break;
                                }
                            }

                            t++;

                            if (f != 52) // Если f равно 52, значит символ не из алфавита
                            {
                                d = nomer - f;
                            }
                            else
                            {
                                d = nomer;
                            }

                            // Проверяем, чтобы не вышли за пределы алфавита
                            if (d < 0)
                            {
                                d = d + 51;
                            }

                            massage[i] = alfavit[d]; // Меняем букву
                        }
                    }

                    s = new string(massage); // Собираем символы обратно в строку.
                    Dec.Text = s; // Записываем результат в textBox.
                }
                else if (g == "Цезаря")
                {
                    string m = Enc.Text;
                    string k = Key.Text;
                    char[] text = m.ToCharArray();
                    int key = Convert.ToInt32(k);
                    string pa; //результат
                    int p; //переменная в цикле

                    int n; //номер в алфавите
                    int d; //смещение
                    char[] alfavit = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
                    //перебираем каждый символ сообщения
                    for (int l = 0; l < text.Length; l++)
                    {
                        for (p = 0; p < alfavit.Length; p++)//поиск индекса буквы
                        {
                            if (text[l] == alfavit[p])
                            {
                                break;
                            }
                        }
                        if (p != 52)
                        {
                            n = p; //индекс буквы
                            d = n - key; //делаем смещение по ключу 
                                         //Если вышли за пределы алфавита
                            if (d < 0)
                            {
                                d = d + 51;
                            }
                            text[l] = alfavit[d]; //меняем букву
                        }
                    }
                    pa = new string(text); //собираем в одну строку
                    Dec.Text = pa; // выводит на консоль;
                }
            }
        }
       
    }
}
