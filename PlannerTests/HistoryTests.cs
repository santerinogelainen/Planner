using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Planner.History;
using Planner;
using System.Linq;

namespace PlannerTests
{
		[TestClass]
		public class HistoryTests
		{

				[TestMethod]
				public void TestDoubleSidedStack()
				{
						DoubleSidedStack<int> stack = new DoubleSidedStack<int>();
						int first = 6;
						stack.Push(first);
						Assert.AreEqual(stack.Peek(), first, "the top-most value in stack is not equal to " + first);

						for (int i = 0; i <= 5; i++)
						{
								stack.Push(i);
						}
						Assert.AreEqual(stack.PeekBottom(), first, "the bottom-most value in stack is not equal to " + first);
						Assert.AreEqual(stack.Pop(), 5, "the popped value is not equal to " + 5);
						Assert.AreEqual(stack.PopBottom(), first, "the popped value is not equal to " + first);
						stack.PushBottom(10);
						Assert.AreEqual(stack.PeekBottom(), 10, "the bottom-most value is not equal to " + 10);

						// try with autopop

						int size = 10;
						stack = new DoubleSidedStack<int>(size, true);
						first = 11;
						stack.Push(first);
						Assert.AreEqual(stack.Peek(), first, "the top-most value in stack is not equal to " + first);

						for (int i = 0; i <= size; i++)
						{
								stack.Push(i);
						}
						Assert.AreEqual(stack.PeekBottom(), 1, "the bottom-most value in stack is not equal to " + 1);
						Assert.AreEqual(stack.Pop(), size, "the popped value is not equal to " + size);
						Assert.AreEqual(stack.PopBottom(), 1, "the popped value is not equal to " + 1);
						stack.PushBottom(10);
						stack.PushBottom(11);
						stack.PushBottom(12);
						stack.PushBottom(13);
						Assert.AreEqual(stack.PeekBottom(), 13, "the bottom-most value is not equal to " + 13);
				}
		}
}
