using System;

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
        //剑指 Offer 25. 合并两个排序的链表
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null || l2 == null)//有1个为空的就返回另一个不为空的链表
                return l1 != null ? l1 : l2;
            //int newHeadValue = Math.Min(l1.val, l2.val);
            //ListNode result = new ListNode(newHeadValue);

            //ListNode l = l1.val == newHeadValue ? l1.next : l1;//一个左链表一个右链表
            //ListNode r = l2.val == newHeadValue ? l2.next : l2;
            //while (l != null && r != null)
            //{
            //    if (l.val == r.val)
            //    {
            //        result.next=new ListNode(l.val)
            //    }

            //}
            return null;
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
