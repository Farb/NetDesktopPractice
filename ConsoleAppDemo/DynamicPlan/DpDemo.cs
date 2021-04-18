using System;
using System.Linq;

namespace ConsoleAppDemo.DynamicPlan
{
    class DpDemo
    {
        //剑指 Offer 63. 股票的最大利润
        public int MaxProfit(int[] prices)
        {
            //思路：
            int cost = prices[0], profit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] < cost)
                    cost = prices[i];
                prices[i] = Math.Max(prices[i - 1], prices[..i].Max() - cost);
                if (prices[i] > profit)
                    profit = prices[i];
            }
            return profit;
        }
        //剑指 Offer 47. 礼物的最大价值
        public int MaxValue(int[][] grid)
        {
            //核心思路：到第n个格子有2种走法，要么从上边，要么从左边
            //转移方程：dp[m,n]=max(dp[m,n-1],dp[m-1,n])+grid[m,n]
            //特别地，第一行和第一列单独处理
            for (int i = 1; i < grid[0].Length; i++)//第0行
            {
                grid[0][i] += grid[0][i - 1];
            }
            for (int i = 1; i < grid.Length; i++)//第0列
            {
                grid[i][0] += grid[i - 1][0];
            }
            for (int i = 1; i < grid.Length; i++)
            {
                for (int j = 1; j < grid[0].Length; j++)
                {
                    grid[i][j] += Math.Max(grid[i - 1][j], grid[i][j - 1]);
                }
            }
            return grid[^1][^1];
        }
    }
}
