using avto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    class Bus : Avto
    {
        private byte passсount;

        public Bus(string nom, double bak, double ras, byte initpassсount) : base(nom, bak, ras)
        {
            passсount = initpassсount;
        }

        public override void Out()
        {
            base.Out();
            Console.WriteLine($"Пассажиров в автобусе = {passсount} ");
        }

        public void Load_Pass(byte pass)
        {
            if (pass > 0)
            {
                if (pass + passсount <= 30)
                {
                    passсount += pass;

                    if (passсount < 7)
                    {
                        skorost -= 1.5;
                        rashodTopliva += 0.15;
                    }
                    else if (passсount >= 7 && passсount < 15)
                    {
                        skorost -= 2.5;
                        rashodTopliva += 0.25;
                    }
                    else if (passсount >= 15 && passсount < 25)
                    {
                        skorost -= 3.5;
                        rashodTopliva += 0.35;
                    }
                    else if (passсount >= 25 && passсount < 30)
                    {
                        skorost -= 5.5;
                        rashodTopliva += 0.55;
                    }
                    Console.WriteLine($"Добавлено пассажиров = {pass} чел. Всего пассажиров = {passсount} чел. Скорость и расход изменены.");
                }
                else
                {
                    Console.WriteLine("Перебор.");
                }
            }
        }

        public void Unload_Pass(byte pass)
        {
            if (pass > 0 && pass <= passсount)
            {
                passсount -= pass;

                if (passсount < 7)
                {
                    skorost += 1.5;
                    rashodTopliva -= 0.15;
                }
                else if (passсount >= 7 && passсount < 15)
                {
                    skorost += 2.5;
                    rashodTopliva -= 0.25;
                }
                else if (passсount >= 15 && passсount < 25)
                {
                    skorost += 3.5;
                    rashodTopliva -= 0.35;
                }
                else if (passсount >= 25 && passсount < 30)
                {
                    skorost += 5.5;
                    rashodTopliva -= 0.55;
                }
                Console.WriteLine($"Выгружено пассажиров = {pass} чел. Всего пассажиров = {passсount} чел. Скорость и расход изменены.");
            }
            else
            {
                Console.WriteLine("Перебор.");
            }
        }
    }
}