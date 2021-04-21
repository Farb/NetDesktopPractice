using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDemo.Search
{
    class SearchDemo
    {
        //剑指 Offer 13. 机器人的运动范围
        public int MovingCount(int m, int n, int k)
        {
            int[,] arr = new int[m, n];
            int sum = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    sum+= Dfs(m, n, i, j, k);
                }
            }
            return sum;

            int Dfs(int m, int n, int i, int j, int k)
            {
                //越界处理
                if (i < 0 || i >= m || j < 0 || j >= n)
                    return 0;
                //不能进入行坐标和列坐标的数位之和大于k的格子
                if (NumSum(i) + NumSum(j) > k)
                    return 0;
                //访问过的格子不能再计数
                if (arr[i, j] == 1)
                    return 0;
                arr[i, j] = 1;
                sum++;
                sum += Dfs(m, n, i, j+1, k);//go right
                sum += Dfs(m, n, i+1, j, k);//go down
                sum += Dfs(m, n, i, j-1, k);//go left
                sum += Dfs(m, n, i-1, j, k);//go up
                return sum;
            }

            //求一个数字的各位和
            int NumSum(int num)
            {
                int sum = 0;
                while (num > 0)
                {
                    sum += num % 10;
                    num /= 10;
                }
                return sum;
            }
        }
        //剑指 Offer 12. 矩阵中的路径
        public bool Exist(char[][] board, string word)
        {
            char[] chArr = word.ToArray();
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (Dfs(board, chArr, i, j, 0)) return true;
                }
            }
            return false;
            //深度优先搜索逻辑
            bool Dfs(char[][] board, char[] chArr, int row, int col, int k)
            {
                //越界返回false  当前元素不匹配当前字符也返回false
                if (row < 0 || row >= board.Length || col < 0 ||
                    col >= board[row].Length || board[row][col] != chArr[k])
                    return false;
                //找到了，完全匹配字符串
                if (k == chArr.Length - 1)
                    return true;
                //当前元素已经访问过
                if (board[row][col] == '\0')
                    return false;
                board[row][col] = '\0';//访问过的元素置为空
                //找到当前元素，返回顺时针访问4个方向的或结果
                bool res = Dfs(board, chArr, row, col + 1, k + 1) ||//向右搜索下一个字符
                           Dfs(board, chArr, row + 1, col, k + 1) ||//向下搜索下一个字符
                           Dfs(board, chArr, row, col - 1, k + 1) ||//向左搜索下一个字符
                           Dfs(board, chArr, row - 1, col, k + 1);  //向上搜索下一个字符
                board[row][col] = word[k];//回填置为空的字符
                return res;
            }
        }
    }
}
