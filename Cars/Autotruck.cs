using avto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    class Autotruck : Avto
    {
        private byte cargoсount;

        public Autotruck(string nom, double bak, double ras, byte initcargoсount) : base(nom, bak, ras)
        {
            cargoсount = initcargoсount;
        }

        public override void Out()
        {
            base.Out();
            Console.WriteLine($"Груза в фуре = {cargoсount} ");
        }

        public void Load_Cargo(byte cargo)
        {
            if (cargo > 0)
            {
                if (cargo + cargoсount <= 30)
                {
                    cargo += cargo;
                    if (cargo < 7)
                    {
                        skorost -= 1.5;
                        rashodTopliva += 0.15;
                    }
                    else if (cargo >= 7 && cargo < 15)
                    {
                        skorost -= 2.5;
                        rashodTopliva += 0.25;
                    }
                    else if (cargo >= 15 && cargo < 25)
                    {
                        skorost -= 3.5;
                        rashodTopliva += 0.35;
                    }
                    else if (cargo >= 25 && cargo < 30)
                    {
                        skorost -= 5.5;
                        rashodTopliva += 0.55;
                    }
                    Console.WriteLine($"Добавлено груза = {cargoсount} тонн. Всего груза = {cargo} тонн. Скорость и расход изменены.");
                }
                else
                {
                    Console.WriteLine("Перебор.");
                }
            }
        }

        public void Unload_Cargo(byte cargo)
        {
            if (cargo > 0 && cargo <= cargoсount)
            {
                cargo -= cargo;
                if (cargo + cargoсount <= 30)
                {
                    cargo += cargo;
                    if (cargo < 7)
                    {
                        skorost += 5.5;
                        rashodTopliva -= 0.55;
                    }
                    else if (cargo >= 7 && cargo < 15)
                    {
                        skorost += 3.5;
                        rashodTopliva -= 0.35;
                    }
                    else if (cargo >= 15 && cargo < 25)
                    {
                        skorost += 2.5;
                        rashodTopliva -= 0.25;
                    }
                    else if (cargo >= 25 && cargo < 30)
                    {
                        skorost += 1.5;
                        rashodTopliva -= 0.15;
                    }
                    Console.WriteLine($"Выгружено груза = {cargoсount} тонн. Всего груза = {cargo} тонн. Скорость и расход изменены.");
                }
                else
                {
                    Console.WriteLine("Перебор.");
                }
            }
        }
    }
}

