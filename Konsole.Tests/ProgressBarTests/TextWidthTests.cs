using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Konsole.Tests.ProgressBarTests
{
    public class ProgressBarTextWidthTests
    {
        [Test]
        public void when_text_is_wider_than_the_window()
        {
            var console = new MockConsole(40, 20);
            var pb = new ProgressBar(console, PbStyle.DoubleLine, 20);
            pb.Refresh(2, "this line of text will overflow the window by a little bit");
            var expected1 = new[]
            {
                "Item 2     of 20   . (10 %) #           ",
                "this line of text will overflow the wind"
            };

            Assert.AreEqual(expected1, console.BufferWritten);
        }

        // todo
        // add in some manual tests with and without windows
        // so that I can manually test without using mock console.
    }
}
