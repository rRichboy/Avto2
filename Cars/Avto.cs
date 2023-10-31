using System;

namespace avto
{
    class Avto
    {
        protected string nomerAvto;
        protected double rashodTopliva;
        protected double ostatokTopliva;
        protected double skorost;
        protected double probeg;

        public Avto(string nom, double bak, double ras)
        {
            nomerAvto = nom;
            rashodTopliva = ras;
            ostatokTopliva = bak;
            skorost = 0.0;
            probeg = 0.0;
        }

        public void Info(string nom, double bak, double ras)
        {
            nomerAvto = nom;
            rashodTopliva = ras;
            ostatokTopliva = bak;
            skorost = 0.0;
            probeg = 0.0;
        }

        public virtual void Out()
        {
            Console.WriteLine($"Номер авто: {nomerAvto}");
            Console.WriteLine($"Количество бензина в баке: {Math.Round(ostatokTopliva, 2)} л");
            Console.WriteLine($"Расход топлива на 100 км: {rashodTopliva} л/100км");
            Console.WriteLine($"Текущая скорость: {skorost} км/ч");
            Console.WriteLine($"Ваш пробег: {probeg} км");
        }

        protected void Zapravka(double top)
        {
            if (top <= 0)
            {
                Console.WriteLine("Количество топлива должно быть больше нуля.");
            }
            if (top + ostatokTopliva >= 80)
            {
                Console.WriteLine("Больше бензина залить нельзя");
                ostatokTopliva = 80;
            }
            else
            {
                ostatokTopliva += top;
                Console.WriteLine($"Заправлено {top:F2} литров топлива. В баке теперь {ostatokTopliva:F2} литров топлива.");
            }
        }

        protected void Move(int speed, double distance)
        {
            if (speed <= 0)
            {
                Console.WriteLine("Скорость должна быть больше нуля.");
                return;
            }

            if (speed > 190)
            {
                Console.WriteLine("Скорость не может превышать 190 км/ч. Скорость установлена на максимум (190 км/ч).");
                speed = 190;
            }

            double time = distance / speed;
            double rashodToplivaNaKm = rashodTopliva / 100;
            double rashod = distance * rashodToplivaNaKm;

            if (ostatokTopliva >= rashod)
            {
                ostatokTopliva -= rashod;
                probeg += distance;
                Console.WriteLine($"Проехано {distance} км со скоростью {speed} км/ч c временем {time:F2} ч. Остаток топлива: {ostatokTopliva:F2} л");
                skorost = speed;
            }
            else
            {
                double maxDistance = ostatokTopliva / rashodToplivaNaKm;

                if (maxDistance > 0)
                {
                    Console.WriteLine($"Недостаточно топлива для поездки на всю дистанцию {distance} км.");
                    Console.WriteLine($"Машина проедет {maxDistance} км со скоростью {speed} км/ч.");
                    probeg += maxDistance;
                    Console.WriteLine("Машина проехала максимальное расстояние с текущим количеством топлива.");

                    double neededFuel = rashod - ostatokTopliva;
                    Console.WriteLine($"Для дозаправки требуется {neededFuel:F2} литров топлива.");

                    Console.Write("Желаете дозаправить машину? (Да/Нет): ");
                    string choice = Console.ReadLine();
                    if (choice.ToLower() == "да")
                    {
                        Console.Write("Введите желаемое количество топлива для дозаправки: ");
                        double topUpAmount = double.Parse(Console.ReadLine());

                        if (topUpAmount > 0)
                        {
                            if (topUpAmount >= neededFuel)
                            {
                                ostatokTopliva = topUpAmount;
                                Console.WriteLine($"Заправлено {neededFuel:F2} литров топлива. В баке теперь {ostatokTopliva:F2} литров топлива.");
                            }
                            else
                            {
                                Console.WriteLine($"Введенное количество топлива недостаточно для полной дозаправки.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неправильное количество топлива. Введите положительное число.");
                        }

                        Move(speed, distance - maxDistance);
                    }
                }
                else
                {
                    Console.WriteLine("Недостаточно топлива для поездки.");
                }
            }
        }

        protected void Tormozhenie()
        {
            Console.WriteLine("Автомобиль замедляется.");
            skorost = 0.0;
        }

        protected void Razgon(int additionalSpeed)
        {
            if (ostatokTopliva >= 1.0)
            {
                skorost += additionalSpeed;
                rashodTopliva += 0.5;
                ostatokTopliva -= 1.0;
                Console.WriteLine($"Автомобиль разгоняется до скорости {skorost} км/ч. Расход топлива увеличен.");
            }
            else
            {
                Console.WriteLine("Недостаточно топлива для разгона.");
            }
        }

        protected bool CheckDTP(int roadDistance, double totalDistance)
        {
            if (totalDistance >= roadDistance)
            {
                return true;
            }
            return false;
        }

        protected void Proydennoerast(int distance)
        {
            this.probeg += distance;
        }

        protected double Ostatok()
        {
            return ostatokTopliva;
        }

        public void PerformAction(string action, int param1, double param2, double param3)
        {
            switch (action.ToLower())
            {
                case "info":
                    Info(nomerAvto, ostatokTopliva, rashodTopliva);
                    break;
                case "out":
                    Out();
                    break;
                case "zapravka":
                    Zapravka(param3);
                    break;
                case "move":
                    Move(param1, param2);
                    break;
                case "tormozhenie":
                    Tormozhenie();
                    break;
                case "razgon":
                    Razgon(param1);
                    break;
                case "checkdtp":
                    CheckDTP(param1, param2);
                    break;
                case "proydennoerast":
                    Proydennoerast(param1);
                    break;
                case "ostatok":
                    Ostatok();
                    break;
                default:
                    Console.WriteLine("Такое.");
                    break;
            }
        }
    }
}
