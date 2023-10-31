﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Zapravka(double top)

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

        public void Move(int speed, double distance)
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


        public void Tormozhenie()
        {
            Console.WriteLine("Автомобиль замедляется.");
            skorost = 0.0;
        }

        public void Razgon(int additionalSpeed)
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

        public bool CheckDTP(int roadDistance, double totalDistance)
        {
            if (totalDistance >= roadDistance)
            {
                return true;
            }
            return false;
        }

        private void proydennoerast(int distance)
        {
            this.probeg += distance;
        }

        private double Ostatok()
        {
            return ostatokTopliva;
        }
    }
}