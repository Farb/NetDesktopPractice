namespace ConsoleAppDemo.BitCompute
{
    class BitDemo
    {
        //剑指 Offer 56 - I. 数组中数字出现的次数
        public int[] SingleNumbers(int[] nums)
        {
            //核心思路：将2个不同的数字分配到2个不同的子数组，每个子数组的异或值就是那个不同的数字
            //那么分配策略呢？既然是不同的数字，那么二进制异或之后肯定有一个1，找到这个1的最低位代表的数
            //用每个数字和这个特殊的数做与运算即可分成2个子数组（该位为1和不为1的两组数）
            int a = 0, b = 0,m=0;
            foreach (var n in nums)
            {
                m ^= n;
            }
            //int k = 1;
            //while ((m&k)==0)
            //{
            //    k <<= 1;//左移一位
            //}
            int k = m & (-m);
            foreach (var n in nums)
            {
                if ((n & k) != 0)//a组
                    a ^= n;
                else
                    b ^= n;
            }
            return new[] { a, b };
        }
        //剑指 Offer 15. 二进制中 1 的个数
        public int HammingWeight(uint n)
        {
            /*
            //v1
            uint count = 0;
            while (n > 0)
            {
                count += (n & 1);
                n >>= 1;//右移一位
            }
            return (int)count;
            */

            //v2
            int res = 0;
            while (n != 0)
            {
                n &= (n - 1);
                res++;
            }
            return res;
        }
    }
}
