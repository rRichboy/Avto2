using avto;
using Cars;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите расстояние дороги (в км): ");
        int roadDistance = int.Parse(Console.ReadLine());
        double totalDistance = 0;

        Avto selectedVehicle = null;

        while (totalDistance < roadDistance)
        {
            if (selectedVehicle == null)
            {
                Console.WriteLine("Выберите тип автотранспорта:");
                Console.WriteLine("1 - Автобус");
                Console.WriteLine("2 - Фура");
                int vehicleChoice = int.Parse(Console.ReadLine());

                if (vehicleChoice == 1)
                {
                    selectedVehicle = new Bus("Bus", 80, 15.0, 0);
                }
                else if (vehicleChoice == 2)
                {
                    selectedVehicle = new Autotruck("Autotruck", 80, 20.0, 0);
                }
                else
                {
                    Console.WriteLine("Неверный выбор автотранспорта. Попробуйте снова.");
                    continue;
                }
            }

            Console.WriteLine($"Выбран автотранспорт: {selectedVehicle.GetType().Name}");

            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1 - Поехать");
            Console.WriteLine("2 - Разогнать автомобиль");
            Console.WriteLine("3 - Тормозить");
            Console.WriteLine("4 - Заправить автомобиль");
            Console.WriteLine("5 - Вывести информацию");
            Console.WriteLine("6 - Загрузить пассажиров или груз");
            Console.WriteLine("7 - Высадить пассажиров или разгрузить груз");
            Console.WriteLine("8 - Выбрать другой автотранспорт");
            Console.WriteLine("9 - Выход");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Введите скорость для поездки (в км/ч): ");
                    int speed = int.Parse(Console.ReadLine());
                    Console.Write("Введите расстояние: ");
                    double distance = double.Parse(Console.ReadLine());
                    selectedVehicle.Move(speed, distance);
                    totalDistance += distance;
                    break;

                case 2:
                    Console.Write("Введите скорость для разгона (в км/ч): ");
                    int additionalSpeed = int.Parse(Console.ReadLine());
                    selectedVehicle.Razgon(additionalSpeed);
                    break;

                case 3:
                    selectedVehicle.Tormozhenie();
                    break;

                case 4:
                    Console.Write("Введите количество бензина для заправки (в литрах): ");
                    double top = double.Parse(Console.ReadLine());
                    selectedVehicle.Zapravka(top);
                    break;

                case 5:
                    selectedVehicle.Out();
                    break;

                case 6:
                    if (selectedVehicle is Bus)
                    {
                        Console.Write("Введите количество пассажиров для загрузки: ");
                        byte passToLoad = byte.Parse(Console.ReadLine());
                        ((Bus)selectedVehicle).Load_Pass(passToLoad);
                    }
                    else if (selectedVehicle is Autotruck)
                    {
                        Console.Write("Введите количество груза для загрузки: ");
                        byte cargoToLoad = byte.Parse(Console.ReadLine());
                        ((Autotruck)selectedVehicle).Load_Cargo(cargoToLoad);
                    }
                    else
                    {
                        Console.WriteLine("Выбран неподходящий тип транспорта для загрузки.");
                    }
                    break;

                case 7:
                    if (selectedVehicle is Bus)
                    {
                        Console.Write("Введите количество пассажиров для высадки: ");
                        byte passToUnload = byte.Parse(Console.ReadLine());
                        ((Bus)selectedVehicle).Unload_Pass(passToUnload);
                    }
                    else if (selectedVehicle is Autotruck)
                    {
                        Console.Write("Введите количество груза для разгрузки: ");
                        byte cargoToUnload = byte.Parse(Console.ReadLine());
                        ((Autotruck)selectedVehicle).Unload_Cargo(cargoToUnload);
                    }
                    else
                    {
                        Console.WriteLine("Выбран неподходящий тип транспорта для высадки.");
                    }
                    break;

                case 8:
                    selectedVehicle = null;
                    break;

                case 9:
                    Console.WriteLine("Программа завершена.");
                    return;

                default:
                    Console.WriteLine("Неверный выбор. Повторите попытку.");
                    break;
            }

            if (selectedVehicle != null)
            {
                if (selectedVehicle.CheckDTP(roadDistance, totalDistance))
                {
                    Console.WriteLine("Авария!");
                    return;
                }
            }
        }
    }
}
