using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_2S
{
    interface cil
    {
        void sort(List<Client> s);
    }
    public class Client:cil
    {
        public string Date { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int CashMove { get; set; }
        public int NoCashMove { get; set; }
        public Client(string Date, string Name, string LastName,int CashMove, int NoCashMove)
        {
            this.Date = Date;
            this.Name = Name;
            this.LastName = LastName;
            this.CashMove = CashMove;
            this.NoCashMove = NoCashMove;
        }
        public Client()
        {
            this.Date = "";
            this.Name = "Name";
            this.LastName = LastName + "LastName";
        }
        public void sort(List<Client> Days)
        {
            for (int i = 0; i < Days.Count; i++)
            {
                for (int k = 0; k < Days.Count; k++)
                {
                    if (Days[i].NoCashMove > Days[k].NoCashMove)
                    {
                        Client Temp = Days[k];
                        Days[k] = Days[i];
                        Days[i] = Temp;

                    }
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Client Day5 = new Client("23.05.2020","Dima","Seidex" ,160, 737);
            Client Day4 = new Client("19.05.2020","Jojo","Reference",190, 730);
            Client Day3 = new Client("16.05.2020","Capitalism","Pobedil", 160, 748);
            Client Day1 = new Client("21.05.2020","Name","Skychno", 170, 747);
            Client Day2 = new Client("14.05.2020","Sakura","Naruto", 140, 740);
            Client Day6 = new Client("30.05.2020","Figna","Popova", 100, 737);
            Client Day7 = new Client("11.05.2020", "Potchi","Dodelal",110, 730);
            Client Day8 = new Client("05.05.2020","Labo" ,"Robot",340, 707);
            Client Day9 = new Client("10.05.2020","Seidex","Super",150, 732);
            Client Day10 = new Client("01.05.2020","Rich","Man", 200, 750);
            List<Client> Days = new List<Client>();
            Days.Add(Day1); Days.Add(Day2); Days.Add(Day3); Days.Add(Day4); Days.Add(Day5);
            Days.Add(Day6); Days.Add(Day7); Days.Add(Day8); Days.Add(Day9); Days.Add(Day10);
            //Sorting
            Client Most = Day1;
            Client Less = Day1;
            Day1.sort(Days);
            Console.WriteLine("Name | Last Name | Date | Cash | Cashless | ");
            for (int i = 0; i < Days.Count; i++)
            {
                Console.WriteLine(Days[i].Name + "|" + Days[i].LastName + "|" + Days[i].Date + "|" + Days[i].CashMove + "|" + Days[i].NoCashMove);
            }
            Console.ReadKey();

        }
    }
}
