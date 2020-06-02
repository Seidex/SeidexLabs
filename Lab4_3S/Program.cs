using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4_3S
{
    public class Music
    {
        public string Name { get; set; }
        public string Performer { get; set; }
        public string Album{ get; set; }
        public string Date { get; set; }
        public int Duration { get; set; }
    }
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string path = "";
            List<Music> goods = new List<Music>();
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            path = file.FileName;
            try
            {
                goods = ReadData(path);
            }
            catch
            {
                path = "Data.txt";
            }

            while (true)
            {
                Console.Clear();
                ShowTable(goods);
                var press = Console.ReadKey().Key;
                if (press.ToString() == "Enter")
                {
                    
                }
                if (press.ToString() == "P")
                {
                    Console.WriteLine();
                    ChangeData(goods);
                    SaveData(goods, path);
                }
                if (press.ToString() == "N")
                {
                    Console.WriteLine();
                    Seach(goods);
                    SaveData(goods, path);
                }
                if (press.ToString() == "D")
                {
                    Console.WriteLine();
                    AddNew(goods);
                    SaveData(goods, path);
                }
                if (press.ToString() == "S")
                {
                    Console.WriteLine();
                    Sort(goods);
                    SaveData(goods, path);
                }
                //C:/Users/Макс/Desktop/Data.txt
            }
        }
        static string PS(int count)
        {
            string s = "";
            for (int i = 0; i < count; i++)
            {
                s += " ";
            }
            return s;
        }
        static void ShowTable(List<Music> Music)
        {
            int MaxI = 10;
            int MaxN = 17;
            int MaxW = 7;
            int MaxC = 12;
            int MaxD = 12;
            Console.WriteLine("|   Name   |    Performer    | Album |    Date    |  Duration  |");
            foreach (Music g in Music)
            {
                int ni = MaxI - g.Name.Length;
                int nn = MaxN - g.Performer.Count();
                int nw = MaxW - g.Album.Length;
                int nc = MaxC - g.Date.Length;
                int nd = MaxD - Convert.ToString(g.Duration).Length;
                Console.WriteLine("|" + g.Name + PS(ni) + "|" + g.Performer + PS(nn) + "|" +
                    g.Album + PS(nw) + "|" + g.Date + PS(nc) + "|" + g.Duration + PS(nd) + "|");
            }
            Console.WriteLine(" p - Edit/Delete,\n d - Create\n s- Sort by name \n n - search,\n Enter - exit");
        }
        static List<Music> ReadData(string path)
        {
            List<Music> g = new List<Music>();
            string text = "";
            using (StreamReader sr = new StreamReader(path))
            {
                text = sr.ReadToEnd();
            }
            string[] Dates = text.Split('/');
            foreach (string s in Dates)
            {
                string[] MetaDete = s.Split('|');
                if (MetaDete.Length > 3)
                {
                    Music d = new Music
                    {
                        Name = MetaDete[0].Trim(),
                        Performer = MetaDete[1],
                        Album = MetaDete[2],
                        Date = MetaDete[3],
                        Duration = Convert.ToInt32(MetaDete[4]),
                    };
                    g.Add(d);
                }
            }
            return g;
        }
        static void SaveData(List<Music> Data, string path)
        {
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                foreach (Music g in Data)
                {

                    sw.WriteLine(g.Name + "|" + g.Performer + "|" + g.Album + "|" + g.Date+ "|" + g.Duration + "/");

                }
            }
        }
        static void ChangeData(List<Music> Data)
        {
            Console.WriteLine("Enter Name of song that`s need to change");
            string Nam = Console.ReadLine();
            Music Choosen = new Music();
            foreach (Music g in Data)
            {
                if (g.Name == Nam)
                {
                    Choosen = g;
                }
            }
            if (Choosen.Name != "")
            {
                Console.WriteLine();
                Console.WriteLine("1)Change Name\n2)Change Performer\n3)Change Album\n4)Change Date\n5)Duration\n6)Delete");
                char key = Console.ReadKey().KeyChar;
                Console.WriteLine("Enter new value");
                try
                {
                    if (key == '1')
                    {

                        Choosen.Name = Console.ReadLine();
                    }
                    if (key == '2')
                    {

                        Choosen.Performer = Console.ReadLine();
                    }
                    if (key == '3')
                    {

                        Choosen.Album = Console.ReadLine();
                    }
                    if (key == '4')
                    {
                        Choosen.Date = Console.ReadLine();
                    }
                    if (key == '5')
                    {
                        Choosen.Duration = Convert.ToInt32(Console.ReadLine());
                    }
                    if(key == '6')
                    {
                        Data.Remove(Choosen);
                    }
                }
                catch
                {
                    Console.WriteLine("New value is incorrect");
                }

            }
            else
            {
                Console.WriteLine("Music Not found");
            }

        }
        static void AddNew(List<Music> Data)
        {
            Console.WriteLine("Enter Name");
            Music neww = new Music();
            neww.Name = Console.ReadLine();
            Console.WriteLine("Enter Performer");
            neww.Performer= Console.ReadLine();
            Console.WriteLine("Enter Album");
            neww.Album = Console.ReadLine();
            Console.WriteLine("Enter Date");
            neww.Date= Console.ReadLine();
            Console.WriteLine("Enter Duration");
            neww.Duration = Convert.ToInt32(Console.ReadLine());
            Data.Add(neww);
        }
        static void Seach(List<Music> Data)
        {
            int MaxI = 10;
            int MaxN = 17;
            int MaxW = 7;
            int MaxC = 12;
            int MaxD = 12;
            Console.Clear();
            Console.WriteLine("Enter performer of music that`s you want to find");
            string s = Console.ReadLine();
            foreach (Music g in Data)
            {

                if (g.Performer == s)
                {
                    Console.WriteLine("|   Name   |    Performer    | Album |    Date    |  Duration  |");
                    int ni = MaxI - g.Name.Length;
                    int nn = MaxN - g.Performer.Count();
                    int nw = MaxW - g.Album.Length;
                    int nc = MaxC - g.Date.Length;
                    int nd = MaxD - Convert.ToString(g.Duration).Length;
                    Console.WriteLine("|" + g.Name + PS(ni) + "|" + g.Performer + PS(nn) + "|" +
                        g.Album + PS(nw) + "|" + g.Date + PS(nc) + "|" + g.Duration + PS(nd) + "|");
                }
            }
            Console.WriteLine("Press any key to back into table");
            Console.ReadLine();
        }
        static void Sort(List<Music> Data)
        {
            for (int i = 0; i < Data.Count; i++)
            {
                for (int k = 0; k < Data.Count; k++)
                {
                    if (Data[i].Name[0] < Data[k].Name[0])
                    {
                        Music temp = Data[k];
                        Data[k] = Data[i];
                        Data[i] = temp;
                    }
                }
            }
        }
    }
}
