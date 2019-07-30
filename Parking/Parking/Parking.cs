using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Parking
{
    public class Parking : IEnumerable
    {
        private List<Car> _cars = new List<Car>(); 
        private const int MAX_CARS = 100;

        public Car this[string number]
        {
            get
            {
                var car = _cars.FirstOrDefault(c => c.Number == number);
                return car;
            }
        }

        public Car this[int position]
        {
            get
            {
                if (position < _cars.Count)
                {
                    return _cars[position];
                }

                return null;
            }
            
            set
            {
                if (position < _cars.Count)
                {
                    _cars[position] = value;
                }
            }

        }
        
        public string Name { get; set; }
        public int Count => _cars.Count;

        //Въезд автомобиля на парковку
        public int Add(Car car)
        {
            if(car == null)
            {
                throw new ArgumentNullException(nameof(car), "Car is null");
            }
            if(_cars.Count < MAX_CARS)
            {
                _cars.Add(car);
                Console.WriteLine($"Въехал новый автомобиль: {car.Name}, номер {car.Number}");
                Console.WriteLine();
                return _cars.Count - 1;
            }
            return -1;
        }

        // Выезд автомобиля из парковки
        public void GoOut(Car car)
        {
            if(car == null)
            {
                throw new ArgumentNullException(nameof(car.Number), "Car is null");
            }
            if(car != null)
            {
                Console.WriteLine($"Выехал автомобиль: {car.Name} номер {car.Number}");
                Console.WriteLine();
                _cars.Remove(car);
                
            }
            
        }
        
        public IEnumerator GetEnumerator()
        {
            foreach(var car in _cars)
            {
                yield return car;
            }

        }

        public IEnumerable GetNames()
        {
            foreach(var car in _cars)
            {
                yield return car.Name;
            }

        }

        //Машины на парковке
        public static void CarsOnParking(Parking parking)
        {
        
            Console.WriteLine($"Машины на парковке");
            Console.WriteLine($"Всего машин: {parking.Count} ед.");
            foreach (var car in parking)
            {
                Console.WriteLine($"{car} ");
            }
            Console.WriteLine();
        }

        //Поиск машины на парковке по номеру
        public static bool SeachCarOnParking(Parking parking, string carNum)
        {
            if (parking[carNum]?.Number != null)
            {
                return true;
            }
            else
            {
                Console.WriteLine($"Автомобиля с номером {carNum} на парковке нет!");
                Console.WriteLine();
                return false;
            }
        }

        public class ParkingEnumerator
        {
            public object Current => throw new NotImplementedException();

            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
}