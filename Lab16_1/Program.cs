using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.IO;


namespace Lab_16
{
    class Tovar
    {


        //1.Необходимо разработать программу для записи информации о товаре в текстовый файл в формате json.
        //Разработать класс для моделирования объекта «Товар». Предусмотреть члены класса «Код товара» (целое число), «Название товара» (строка), «Цена товара» (вещественное число).
        //Создать массив из 5 - ти товаров, значения должны вводиться пользователем с клавиатуры.
        //Сериализовать массив в json-строку, сохранить ее программно в файл «Products.json».
        //2.Необходимо разработать программу для получения информации о товаре из json - файла.
        //Десериализовать файл «Products.json» из задачи 1.Определить название самого дорогого товара

        private int code; //«Код товара» (целое число)
        private string name; //«Название товара»
        private double price; //«Цена товара
        public int CODE
        { get { return code; } set { code = value; } }
        public string NAME
        { get { return name; } set { name = value; } }
        public double PRICE
        { get { return price; } set { price = value; } }

        public Tovar(int kod, string name, double price)
        {
            this.code = kod;
            this.name = name;
            this.price = price;
        }
    }
    class Products
    {
        private List<Tovar> list;
        public Products()
        {
            list = new List<Tovar>();
        }
        public void Add(Tovar obj)
        {
            list.Add(obj);
        }
        public void Max()
        {
            double maxPrice = list.Min(p => p.PRICE);
            Console.WriteLine(maxPrice.ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Tovars[] tovarsArray = new Tovars[5];
            for (int i = 0; i < tovarsArray.Length; i++)
            {
                Console.WriteLine("Vvedite Name {0}, Code {0},Price {0}",i);
                tovarsArray[i] = new Tovars()
                {
                    Name = Console.ReadLine(),
                    Code = Convert.ToInt32(Console.ReadLine()),
                    Price = Convert.ToDouble(Console.ReadLine())
                };

            }
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonstring = JsonSerializer.Serialize(tovarsArray, options);
            Console.WriteLine(jsonstring);
            string path = "Tovars.json";
            StreamWriter sw = new StreamWriter(path);
            sw.Write(jsonstring);
            sw.Close();
            Console.ReadKey();

        }
    }
    class Tovars
    {
        public int Code { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
    }
}

