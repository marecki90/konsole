using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Konsole.Drawing;
using Konsole.Forms;
using Konsole.Internal;
using Konsole.Layouts;
using Konsole.Menus;
using Konsole.Sample.Demos;

namespace Konsole.Sample
{


    class Program
    {
        
        private static void RandomStuff(IConsole con)
        {
            var pb = new ProgressBar(con, PbStyle.DoubleLine, 50);
            pb.Refresh(25,"cats");
            Console.ReadKey(true);
            pb.Max = 40;
            Console.ReadKey(true);
        }

        private static void Main(string[] args)
        {
            SixtyProgressBars();
            //var con = new Window();
            //var right = con.SplitRight();
            //var left = con.SplitLeft();
            //var menu = new Menu(left, "Samples", ConsoleKey.Escape, 30,

            //    new MenuItem('f', "Forms", ()=> FormDemos.Run(right)),
            //    new MenuItem('b', "Boxes", ()=> BoxeDemos.Run(right)),
            //    new MenuItem('s', "Scrolling", ()=> WindowDemo.Run2(right)),
            //    new MenuItem('p', "ProgressBar 1 line demo", ()=> ProgressBarDemos.ParallelDemo(right)),
            //    new MenuItem('q', "ProgressBar 2 line demo", () => ProgressBarDemos.ParallelDemo(right)),
            //    new MenuItem('t', "Test data", () => TestDataDemo.Run(right)),
            //    new MenuItem('c', "clear screen", () => con.Clear()),
            //    new MenuItem('r', "RANDOM", () => RandomStuff(right))

            //);

            //menu.OnBeforeMenuItem += (i) => right.Clear();
            //menu.Run();
        }

        private static void SixtyProgressBars()
        {
            var con = new Window();
            var left = con.SplitLeft("Entities");
            var right = con.SplitRight("Validations");
            var t1 = Task.Run(()=> DoTheThingToTheDbWithTheStuff(left, 30));
            var t2 = Task.Run(() => DoTheThingToTheDbWithTheStuff(right, 30));
            Task.WaitAll(t1, t2);
            Console.WriteLine("All done");
        }


        private static void DoTheThingToTheDbWithTheStuff(IConsole window, int cnt)
        {
            var r = new Random();
            var pbs = Enumerable.Range(1, cnt).Select(i =>
            {
                var pb = new ProgressBar(window, r.Next(200) + 1);
                pb.Refresh(1, TestData.RandomName);
                return pb;
            }).ToArray();

            for (int i = 0; i < cnt * 100; i++)
            {
                Thread.Sleep(r.Next(200));
                i = r.Next(cnt);
                var pb = pbs[i];
                if(pb.Current<100) pb.Next(TestData.RandomName);
            }
        }

    }
}

