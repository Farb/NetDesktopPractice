using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDemo.Search
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    class SearchDemo
    {
        //剑指 Offer 37. 序列化二叉树
        // Encodes a tree to a single string.
        //public string serialize(TreeNode root)
        //{

        //}

        //// Decodes your encoded data to tree.
        //public TreeNode deserialize(string data)
        //{

        //}
        //剑指 Offer 34. 二叉树中和为某一值的路径
        public IList<IList<int>> PathSum(TreeNode root, int target)
        {
            var res = new List<List<int>>();
            var path = new LinkedList<int>();
            Recur(root,target);
            return res.ToArray();

            void Recur(TreeNode node,int sum){
                if (node == null) return;

                path.AddLast(node.val);
                sum -= node.val;
                if (sum == 0 && node.left == null && node.right == null)
                    res.Add(path.ToList());
                Recur(node.left, sum);
                Recur(node.right, sum);
                path.RemoveLast();
            }
        }
        //剑指 Offer 32 - II. 从上到下打印二叉树 II
        public IList<IList<int>> LevelOrder2(TreeNode root)
        {
            var result = new List<List<int>>();
            if (root is null) return result.ToArray();

            var queues = new Queue<TreeNode>();
            queues.Enqueue(root);

            while (queues.Count > 0)
            {
                var layerList = new List<int>();
                for (int i = queues.Count - 1; i >= 0; i--)
                {
                    TreeNode node= queues.Dequeue();
                    layerList.Add(node.val);
                    if (node.left != null) queues.Enqueue(node.left);
                    if (node.right != null) queues.Enqueue(node.right);
                }
                result.Add(layerList);
            }
            return result.ToArray();
        }
        //剑指 Offer 32 - I. 从上到下打印二叉树
        public int[] LevelOrder(TreeNode root)
        {
            if (root == null) return Array.Empty<int>();
            var nodeQueues = new Queue<TreeNode>();
            nodeQueues.Enqueue(root);
            var list = new List<int>();
            while (nodeQueues.Count > 0)
            {
                TreeNode node = nodeQueues.Dequeue();
                list.Add(node.val);
                if (node.left != null) nodeQueues.Enqueue(node.left);
                if (node.right != null) nodeQueues.Enqueue(node.right);
            }
            return list.ToArray();
        }
        //剑指 Offer 28. 对称的二叉树
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;

            return Recur(root.left, root.right);

            bool Recur(TreeNode left, TreeNode right)
            {
                if (left == null && right == null) return true;
                if (left == null || right == null || left.val != right.val) return false;
                return Recur(left.left, right.right) && Recur(left.right, right.left);
            }
        }
        //剑指 Offer 27. 二叉树的镜像
        public TreeNode MirrorTree(TreeNode root)
        {
            //思路：交换节点的左右子节点
            if (root == null) return null;//特例

            TreeNode tmp = root.left;
            root.left = MirrorTree(root.right);
            root.right = MirrorTree(tmp);
            return root;
        }
        //剑指 Offer 26. 树的子结构
        public bool IsSubStructure(TreeNode A, TreeNode B)
        {
            if (A == null || B == null)//如果任意一棵树为空，则返回false
                return false;

            //只要以A根节点或者左子节点或右子节点有一个包含，就返回true
            return Recur(A, B) || IsSubStructure(A.left, B) || IsSubStructure(A.right, B);

            bool Recur(TreeNode a, TreeNode b)
            {
                //说明子结构已经遍历结束，已找到
                if (b == null) return true;
                if (a == null || a.val != b.val) return false;//母树已经遍历完成还没找到或者不匹配
                return Recur(a.left, b.left) && Recur(a.right, b.right);
            }
        }

        //剑指 Offer 13. 机器人的运动范围
        public int MovingCount(int m, int n, int k)
        {
            int[,] arr = new int[m, n];
            int sum = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    sum += Dfs(m, n, i, j, k);
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
                sum += Dfs(m, n, i, j + 1, k);//go right
                sum += Dfs(m, n, i + 1, j, k);//go down
                sum += Dfs(m, n, i, j - 1, k);//go left
                sum += Dfs(m, n, i - 1, j, k);//go up
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
