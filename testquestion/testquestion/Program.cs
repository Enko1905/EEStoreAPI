using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testquestion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program pr = new Program();
            int[] ts = { 3,3 };
            int[] sonuc = pr.TwoSum(ts, 6);

            foreach (int i in sonuc)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();

        }
        public int[] TwoSum(int[] nums, int target)
        {
            int[] sonuc = { 0, 0 };
            bool bulundu = false;
            for (int i = 0; i < nums.Length ; i++)
            {
                bulundu = false;
                for (int j = 0; j < nums.Length ; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        bulundu = true;
                        sonuc = new int[] { i, j };
                        break;
                    }
                }
            }
            return sonuc;
        }
    }
}
