using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Generator.Classes
{
    public static class Extension
    {
        public static string RemovePunctuation(this string str)
        {
            return str.Replace(".", "").Replace("?", "").Replace("!", "")
                      .Replace(":", "").Replace(";", "");
        }

        public static string RemovePunctuationRegex(this string str)
        {
            return Regex.Replace(str, "\\p{P}", string.Empty);
        }
    }

    public class Temp
    {
        Stopwatch watch;
        string text;

        public Temp(string text)
        {
            this.watch = new Stopwatch();
            this.text = text;
        }

        public void Test()
        {
            watch.Start();
            var result = text.RemovePunctuation();
            watch.Stop();

            MessageBox.Show(watch.ElapsedMilliseconds.ToString());
            watch.Reset();
        }

        public void TestRegex()
        {
            watch.Start();
            var result = text.RemovePunctuationRegex();
            watch.Stop();

            MessageBox.Show(watch.ElapsedMilliseconds.ToString());
            watch.Reset();
        }
    }
}
