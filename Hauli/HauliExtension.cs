using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hauli
{
    /// <summary>
    /// Lisää List-luokkaan sekoitusfunktion. Käyttää Fisher–Yates -sekoitusta.
    /// </summary>
    public static class HauliExtension
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            Random random = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
