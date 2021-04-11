using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDemo.DataStructure
{
    public class MinStack
    {
        private readonly Stack<int> _mainStack;
        //非严格降序
        private readonly Stack<int> _auxiliaryStack;
        /** initialize your data structure here. */
        public MinStack()
        {
            _mainStack = new Stack<int>();
            _auxiliaryStack = new Stack<int>();
        }

        public void Push(int x)
        {
            _mainStack.Push(x);
            //当入栈元素小于等于辅助栈的栈顶元素时，入栈
            if (_auxiliaryStack.Count<=0||x<=_auxiliaryStack.Peek())
            {
                _auxiliaryStack.Push(x);
            }
        }

        public void Pop()
        {
            int top= _mainStack.Pop();
            //如果主栈元素的栈顶元素等于辅助栈的栈顶元素时，辅助栈也出栈
            if (top == _auxiliaryStack.Peek())
            {
                _auxiliaryStack.Pop();
            }
        }

        public int Top()
        {
            return _mainStack.Peek();
        }

        public int Min()
        {
            //返回辅助栈的栈顶元素
            return _auxiliaryStack.Peek();
        }
    }

    /**
     * Your MinStack object will be instantiated and called as such:
     * MinStack obj = new MinStack();
     * obj.Push(x);
     * obj.Pop();
     * int param_3 = obj.Top();
     * int param_4 = obj.Min();
     */
}
