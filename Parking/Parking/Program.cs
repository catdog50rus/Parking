using System;
using System.Collections.Generic;

namespace Parking
{
    class Program
    {
        public static void Main(string[] args)
        {
            var cars = new List<Car>()
            {
                new Car() {Name = "Ford", Number = "E003KM150"},
                new Car() {Name = "Suzuki", Number = "E886KP190"}
            };

            var parking = new Parking();
            foreach (var car in cars)
            {
                parking.Add(car);
            }

            Parking.CarsOnParking(parking);//Машины на парковке


            //Марки машин на парковке
            foreach (var carName in parking.GetNames())
            {
                Console.WriteLine($"{carName} ");
            }

            Console.WriteLine();

            //Поиск машины на парковке по номеру

            Console.WriteLine("Введите номер искомого автомобиля");
            var seachNum = Console.ReadLine();
            if (Parking.SeachCarOnParking(parking, seachNum))
            {
                Console.WriteLine($"На парковке есть автомобиль: {parking[seachNum].Name} номер {parking[seachNum].Number}");
                Console.WriteLine();
            }


            //Выезд автомобиля
            Console.WriteLine("Введите номер выезжающего автомобиля");
            var outNum = Console.ReadLine();
            if (Parking.SeachCarOnParking(parking, outNum))
            {
                parking.GoOut(parking[outNum]);
            }

            Parking.CarsOnParking(parking); //Машины на парковке


            //Въезд нового автомобиля
            Console.WriteLine("Введите номер нового автомобиля");
            var num = Console.ReadLine();
            Console.WriteLine("Введите марку нового автомобиля");
            var name = Console.ReadLine();
            Console.WriteLine();

            //parking[parking.Count - 1] = new Car() { Name = name, Number = num };
            parking.Add(new Car() { Name = name, Number = num });
            Console.WriteLine($"Въехал новый автомобиль: {parking[parking.Count - 1]}");
            Console.WriteLine();



            Parking.CarsOnParking(parking); //Машины на парковке


        }

        //private static bool SeachCarOnParking(Parking parking, string carNum)
        //{
        //    //var outNum = Console.ReadLine();
        //    if(parking[carNum]?.Number != null)
        //    {
        //        //parking.GoOut(parking[carNum]);
        //        return true;
        //    }
        //    else
        //    {
        //        Console.WriteLine ($"Автомобиля с номером {carNum} на парковке нет!");
        //        Console.WriteLine();
        //        return false;
        //    }


        //    //return Console.ReadLine();
        //}

    }
}

