using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Konsole;
using Konsole.Drawing;
using Konsole.Internal;
using Konsole.Layouts;
using Konsole.Menus;

namespace TestPackage.V3._0._3
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = new Random();
            var pbs = Enumerable.Range(1, 300).Select(i =>
            {
                var pb = new ProgressBar(10);
                pb.Refresh(1, TestData.RandomName);
                return pb;
            }).ToArray();

            for (int i = 0; i < 600; i++)
            {
                int pb1 = r.Next(300);
                Thread.Sleep(r.Next(200));
                pbs[pb1].Next(TestData.RandomName);
            }
            Console.WriteLine("DONE");
            Console.ReadLine();
        }

        static void WindowDemo()
        {
            var w = Window.Open(10, 10, 80, 20, "Single line progress bar demo");
            var t = w.SplitTop("game");
            var b = w.SplitBottom("players");
            t.WriteLine("extracting...");
            FakeExtractWithProgress(t, "sounds     ", 10);
            FakeExtractWithProgress(t, "characters ", 5);
            ProgressBarPerItem(b, "skins      ", 30);
            b.WriteLine("done. ");
            new Keyboard().WaitForKeyPress();
        }


        public static void FakeExtractWithProgress(IConsole window, string packageName, int numItems)
        {
            var pb = new ProgressBar(window, numItems, 25);
            var fakePackageParts = TestData.MakeObjectNames(numItems);
            for (int i = 0; i < numItems; i++) {
                Thread.Sleep(new Random().Next(100));
                var part = fakePackageParts[i];
                pb.Refresh(i+1, $"{packageName} : {part}");
            }
        }

        public static void ProgressBarPerItem(IConsole window, string packageName, int cnt)
        {
            var r = new Random();
            var pbs = Enumerable.Range(1, cnt).Select(i =>
            {
                var pb = new ProgressBar(window, r.Next(200) + 1);
                pb.Refresh(1,TestData.RandomName);
                return pb;
            }).ToArray();

            return;
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(r.Next(50));
                pbs[i].Next(TestData.RandomName);
            }
        }
    }

}
