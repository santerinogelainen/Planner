using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner
{
		public class DoubleSidedStack<T> : IEnumerable<T>
		{
				
				/// <summary>
				/// Size of this doublesided stack
				/// </summary>
				private int Size { get; set; }

				/// <summary>
				/// boolean determining whether to automatically pop/popbottom overflowing values when size is reached. Autopopping works like a queue, first in first out
				/// so if you push to top, it will pop from the bottom and viceversa
				/// </summary>
				public bool AutoPop { get; private set; }

				/// <summary>
				/// The stack. index 0 is bottom, index Stack.Count - 1 is the top
				/// </summary>
				private List<T> Stack { get; set; }

				/// <summary>
				/// Create a double sided stack of unknown size
				/// </summary>
				public DoubleSidedStack()
				{
						Stack = new List<T>();
				}

				/// <summary>
				/// Creates a double sided stack of a certain size
				/// </summary>
				/// <param name="size">amount of elements held in the stack</param>
				/// <param name="autopop">true to automatically pop/popbottom elements if the size is exceeded</param>
				public DoubleSidedStack(int size, bool autopop = false)
				{
						Size = size;
						Stack = new List<T>(size);
						AutoPop = autopop;
				}

				/// <summary>
				/// Pushes to the top of the stack
				/// </summary>
				/// <param name="item"></param>
				public void Push(T item)
				{
						Stack.Add(item);
						if (AutoPop && Stack.Count > Size) PopBottom();
				}

				/// <summary>
				/// Pushed to the bottom of the stack
				/// </summary>
				/// <param name="item">Item to push</param>
				public void PushBottom(T item)
				{
						Stack.Insert(0, item);
						if (AutoPop && Stack.Count > Size) Pop();
				}

				/// <summary>
				/// Pops the top-most element from the stack
				/// </summary>
				/// <returns>The popped element</returns>
				public T Pop()
				{
						if (Stack.Count > 0)
						{
								T item = Stack[Stack.Count - 1];
								Stack.RemoveAt(Stack.Count - 1);
								return item;
						}
						return default(T);
				}

				/// <summary>
				/// Pops the bottom-most element from the stack
				/// </summary>
				/// <returns>The popped element</returns>
				public T PopBottom()
				{
						if (Stack.Count > 0)
						{
								T item = Stack[0];
								Stack.RemoveAt(0);
								return item;
						}
						return default(T);
				}

				/// <summary>
				/// Get the top-most element in the stack
				/// </summary>
				/// <returns>The top-most element</returns>
				public T Peek()
				{
						if (Stack.Count > 0) return Stack[Stack.Count - 1];
						return default(T);
				}

				/// <summary>
				/// Get the bottom-most element in the stack
				/// </summary>
				/// <returns>The bottom-most element</returns>
				public T PeekBottom()
				{
						if (Stack.Count > 0) return Stack[0];
						return default(T);
				}

				public IEnumerator<T> GetEnumerator()
				{
						return Stack.GetEnumerator();
				}

				IEnumerator IEnumerable.GetEnumerator()
				{
						return ((IEnumerable)Stack).GetEnumerator();
				}
		}
}
