using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5_2S
{
    interface inf
    {
        void ShowTable(List<Visiting> Visiting);
        void AddNew(List<Visiting> Date);
    }
    public abstract class Site
    {
        public string Name { get; set; }
        public string URL { get; set; }

        public abstract int MaxCountOfDownload(List<Visiting> lst);
        public abstract void AvarageHosts(List<Visiting> lst);
        public abstract void AvaregeUpper(List<Visiting> lst);
        //--------------------------------------------------------------------
        
    }
    public class Visiting : Site,inf
    {
        public int UnicalHosts { get; set; }
        public string Date { get; set; }
        public int CountOfDownload { get; set; }

        public void AddNew(List<Visiting> Date)
        {
            Console.WriteLine("Enter UnicalHosts");
            Visiting neww = new Visiting();
            neww.UnicalHosts = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Date");
            neww.Date = Console.ReadLine();
            Console.WriteLine("Enter CountOfDownload");
            neww.CountOfDownload = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Group Name");
            neww.Name = Console.ReadLine();
            Console.WriteLine("Enter Head Name");
            neww.URL = Console.ReadLine();
            Date.Add(neww);
        }
        public void ShowTable(List<Visiting> Visiting)
        {
            int MaxI = 15;
            int MaxN = 12;
            int MaxW = 19;
            int MaxC = 10;
            int MaxL = 5;
            Console.WriteLine("|  UnicalHosts  |    Date    | Count Of Download |   Name   | URL |");
            foreach (Visiting g in Visiting)
            {
                int ni = MaxI - Convert.ToString(g.UnicalHosts).Length;
                int nn = MaxN - g.Date.Count();
                int nw = MaxW - Convert.ToString(g.CountOfDownload).Length;
                int nc = MaxC - Convert.ToString(g.Name).Length;
                int nl = MaxL - Convert.ToString(g.URL).Length;
                Console.WriteLine("|" + Convert.ToString(g.UnicalHosts) + PS(ni) + "|" + g.Date + PS(nn) + "|" +
                 Convert.ToString(g.CountOfDownload) + PS(nw) + "|" + Convert.ToString(g.Name) + PS(nc) + "|"
                 + Convert.ToString(g.URL) + PS(nl) + "|");
            }
            Console.WriteLine(" p - Edit/Delete,\n d - Create\n n - Avarage Hosts,\n m - Most Count Of Download\n t - Upper than Hosts/Downloads\nEnter - exit");
        }
        //-------------------------------------------------------------------
        public override int MaxCountOfDownload(List<Visiting> lst)
        {
            Console.Clear();
            int IndexMax = 0;
            foreach (Visiting gs in lst)
            {
                if (gs.CountOfDownload > lst[IndexMax].CountOfDownload)
                {
                    IndexMax = lst.IndexOf(gs);
                }
            }
            Visiting g = lst[IndexMax];
            int MaxI = 15;
            int MaxN = 12;
            int MaxW = 19;
            int MaxC = 10;
            int MaxL = 5;
            Console.WriteLine("|  UnicalHosts  |    Date    | Count Of Download |   Name   | URL |");
            int ni = MaxI - Convert.ToString(g.UnicalHosts).Length;
            int nn = MaxN - g.Date.Count();
            int nw = MaxW - Convert.ToString(g.CountOfDownload).Length;
            int nc = MaxC - Convert.ToString(g.Name).Length;
            int nl = MaxL - Convert.ToString(g.URL).Length;
            Console.WriteLine("|" + Convert.ToString(g.UnicalHosts) + PS(ni) + "|" + g.Date + PS(nn) + "|" +
             Convert.ToString(g.CountOfDownload) + PS(nw) + "|" + Convert.ToString(g.Name) + PS(nc) + "|"
             + Convert.ToString(g.URL) + PS(nl) + "|");
            return g.CountOfDownload;
        }
        public static string PS(int count)
        {
            string s = "";
            for (int i = 0; i < count; i++)
            {
                s += " ";
            }
            return s;
        }
        public override void AvarageHosts(List<Visiting> lst)
        {
            Console.Clear();
            float av = 0;
            foreach (Visiting gs in lst)
            {
                av += gs.UnicalHosts;
            }
            av /= lst.Count();
            Console.WriteLine("Avarage count of hosts = " + av + "\nPress any key to return into table");
            Console.ReadKey();
        }
        public override void AvaregeUpper(List<Visiting> lst)
        {
            Console.Clear();
            Console.WriteLine("Enter a num");
            
            float av;
            if (!float.TryParse(Console.ReadLine(), out av))
            {
                Console.WriteLine("Not a valid float");
            }
            else
            {
                Console.WriteLine(av);
            }
            List<Visiting> lst2 = new List<Visiting>();
            foreach (Visiting gs in lst)
            {
                if ((float)gs.UnicalHosts / (float)gs.CountOfDownload > av)
                {
                    lst2.Add(gs);
                }

            }
            ShowTable(lst2);
            Console.WriteLine("\nPress any key to return into table");
            Console.ReadKey();
        }
    }

    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string path = "";
            List<Visiting> vis = new List<Visiting>();
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            path = file.FileName;
            vis = ReadDate(path);
            try
            {
                vis = ReadDate(path);
            }
            catch
            {
                path = "Data.txt";
            }
            while (true)
            {
                Console.Clear();
                Visiting d = new Visiting();
                d.ShowTable(vis);
                Visiting s = new Visiting();
                var press = Console.ReadKey().Key;
                if (press.ToString() == "Enter")
                {
                    Environment.Exit(0);
                }
                if (press.ToString() == "P")
                {
                    Console.WriteLine();
                    ChangeDate(vis);
                    SaveDate(vis, path);
                }
                if (press.ToString() == "D")
                {
                    Console.WriteLine();
                    d.AddNew(vis);
                    SaveDate(vis, path);
                }
                if (press.ToString() == "M")
                {
                    Console.WriteLine();
                    if (vis.Count > 0)
                    {
                        s.MaxCountOfDownload(vis);
                        Console.WriteLine("Press any key to return into table");
                        Console.ReadKey();
                    }
                    SaveDate(vis, path);
                }
                if (press.ToString() == "T")
                {
                    Console.WriteLine();
                    if (vis.Count > 0)
                    {
                        s.AvaregeUpper(vis);
                    }
                    SaveDate(vis, path);
                }
                if (press.ToString() == "N")
                {
                    Console.WriteLine();
                    if (vis.Count > 0)
                    {
                        s.AvarageHosts(vis);
                    }
                    SaveDate(vis, path);
                }

            }
        }
        
        public static string PS(int count)
        {
            string s = "";
            for (int i = 0; i < count; i++)
            {
                s += " ";
            }
            return s;
        }
        public static List<Visiting> ReadDate(string path)
        {
            List<Visiting> g = new List<Visiting>();
            string text = "";
            using (StreamReader sr = new StreamReader(path))
            {
                text = sr.ReadToEnd();
            }
            string[] Dates = text.Split('/');
            foreach (string s in Dates)
            {
                string[] MetaDete = s.Split('|');
                if (MetaDete.Length == 5)
                {
                    Visiting d = new Visiting
                    {
                        UnicalHosts = Convert.ToInt16(MetaDete[0]),
                        Date = MetaDete[1],
                        CountOfDownload = Convert.ToInt32(MetaDete[2]),
                        Name = MetaDete[3],
                        URL = MetaDete[4]
                    };
                    g.Add(d);
                }
            }
            return g;
        }
        public static void SaveDate(List<Visiting> Date, string path)
        {
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                foreach (Visiting g in Date)
                {

                    sw.WriteLine(g.UnicalHosts + "|" + g.Date + "|" + g.CountOfDownload + "|" + g.Name + "|" + g.URL + "/");

                }
            }
        }
        public static void ChangeDate(List<Visiting> Date)
        {
            Console.WriteLine("Enter Date of trip that`s need to change");
            string Nam = Console.ReadLine();
            Visiting Choosen = new Visiting();
            Choosen.Name = "";
            foreach (Visiting g in Date)
            {
                if (g.Date == Nam)
                {
                    Choosen = g;
                    break;
                }
            }
            if (Choosen.Name != "")
            {
                Console.WriteLine();
                Console.WriteLine("1)Change UnicalHosts\n2)Change Date\n3)Change CountOfDownload\n4)Change Name\n5)Change Head Name\n6)Delete");
                char key = Console.ReadKey().KeyChar;
                Console.WriteLine("Enter new value");
                try
                {
                    if (key == '1')
                    {
                        Choosen.UnicalHosts = Convert.ToInt32(Console.ReadLine());
                    }
                    if (key == '2')
                    {

                        Choosen.Date = Console.ReadLine();
                    }
                    if (key == '3')
                    {
                        Choosen.CountOfDownload = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(Choosen.CountOfDownload);

                    }
                    if (key == '4')
                    {
                        Choosen.Name = Console.ReadLine();
                    }
                    if (key == '5')
                    {
                        Choosen.URL = Console.ReadLine();
                    }
                    if (key == '6')
                    {
                        Date.Remove(Choosen);
                    }
                }
                catch
                {
                    Console.WriteLine("New value is incorrect");
                }
                //Lviv|29.03.2019|7|Great Pistols|Ridme/
            }
            else
            {
                Console.WriteLine("Visiting Not found");
            }

        }
        

    }

}
