using System;
using System.Text;

namespace ConsoleAppDemo.DoublePointer
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    class DoublePointers
    {
        //剑指 Offer 58 - I. 翻转单词顺序
        public string ReverseWords(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;

            s = s.TrimEnd();
            int fast = s.Length - 1, slow = fast;
            var sb = new StringBuilder();
            while (fast >= 0)
            {
                //从后往前，找到第一个空格
                while (fast >= 0 && s[fast] != ' ') fast--;
                sb.Append(s[(fast + 1)..(slow + 1)] + " ");
                //找到下一个非空格
                while (fast >= 0 && s[fast] == ' ') fast--;
                slow = fast;
            }
            return sb.ToString().TrimEnd();
        }
        //剑指 Offer 57. 和为 s 的两个数字
        public int[] TwoSum(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            while (left < right)
            {
                if (nums[left] + nums[right] < target)
                    left++;
                else if (nums[left] + nums[right] > target)
                    right--;
                else
                    return new int[] { nums[left], nums[right] };
            }
            return Array.Empty<int>();
        }
        //剑指 Offer 52. 两个链表的第一个公共节点
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            var la = headA;
            var lb = headB;
            while (la != lb)
            {
                la = la != null ? la.next : headB;
                lb = lb != null ? lb.next : headA;
            }
            return la;
        }
        //剑指 Offer 25. 合并两个排序的链表
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            //初始化一个新合并链表，并加入第一个节点，称之为伪造节点
            ListNode fake = new ListNode(0);
            ListNode cur = fake;
            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    cur.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    cur.next = l2;
                    l2 = l2.next;
                }
                cur = cur.next;
            }
            cur.next = l1 != null ? l1 : l2;
            return fake.next;//只需返回伪造节点之后的节点就行了
        }
        //剑指 Offer 22. 链表中倒数第 k 个节点
        public ListNode GetKthFromEnd(ListNode head, int k)
        {
            //思路：求倒数第k个节点，可转化为慢指针指向头节点，快指针指向正数第k个节点，
            //则快指针到达尾结点时，慢指针指向的就是倒数第k个节点
            ListNode slow = head, fast = slow;//首先快慢指针都指向头指针
            while (k > 1)//快指针先走k-1步
            {
                fast = fast.next;
                k--;
            }
            while (fast.next != null)
            {
                fast = fast.next;
                slow = slow.next;
            }
            return slow;
        }
        //剑指 Offer 21. 调整数组顺序使奇数位于偶数前面
        public int[] Exchange(int[] nums)
        {
            //首尾对应的情况：奇奇，奇偶，偶奇，偶偶，其中奇偶不需要交换
            //奇奇：左指针右移，右指针不动
            //偶奇：交换元素
            //偶偶:左指针不动，右指针左移
            for (int i = 0, j = nums.Length - 1; i < j; i++, j--)
            {
                if (nums[i] % 2 != 0)
                {
                    if (nums[j] % 2 != 0)//奇奇
                        j++;
                }
                else
                {
                    if (nums[j] % 2 != 0)//偶奇
                    {
                        nums[i] = nums[i] ^ nums[j];
                        nums[j] = nums[i] ^ nums[j];
                        nums[i] = nums[i] ^ nums[j];
                    }
                    else//偶偶
                        i--;
                }
            }
            return nums;
        }
        //剑指 Offer 18. 删除链表的节点
        public ListNode DeleteNode(ListNode head, int val)
        {
            if (head.val == val) return head.next;
            ListNode pre = head;
            ListNode cur = head.next;
            while (cur != null)
            {
                if (cur.val == val)
                {
                    //将上一个节点指向当前节点的下一个节点
                    pre.next = cur.next;
                    return head;
                }
                pre = cur;//让当前节点充当上一个节点
                cur = cur.next;//当前节点的下一个节点充当当前节点继续遍历
            }
            return head;
        }
    }
}
