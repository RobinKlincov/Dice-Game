using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgramA
{
    class Program
    {
        static void Main(string[] args)
        {

            var separator = " ";
            int die_1 = 0;
            int die_2 = 0;
            var numbers= Console.ReadLine();

            String[] strlist = numbers.Split(separator);
            for (int i = 0; i < strlist.Length; i++)
            {
                if (i == 0)
                {
                    int.TryParse(strlist[i], out die_1);
                }
                else {
                    int.TryParse(strlist[i], out die_2);
                }
            }
        


            var sum = CalcPermutations(new List<int>(), die_1, die_2); 
            var most = sum.GroupBy(i => i).OrderByDescending(grp => grp.Count())
                .Select(grp => new { Number = grp.Key, Occurences = grp.Count() }).ToList();
            int maximum = most.Max(x => x.Occurences);
            most.Where(y => y.Occurences == maximum)
                .ToList()
                .ForEach(o => Console.WriteLine(o.Number));  

        }
        public static List<int> CalcPermutations(List<int> listOfSum, int die_1, int die_2)  
        {
            for (int i = 1; i <= die_1; i++)
            {
                for (int x = 1; x <= die_2; x++)
                {
                    int y = i + x;
                    listOfSum.Add(y);
                }
            }

            return listOfSum;
        }

    }
}


