using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmSummary
{
    /// <summary>
    /// 给定一个整数数组 asteroids，表示在同一行的行星。
    /// 对于数组中的每一个元素，其绝对值表示行星的大小，正负表示行星的移动方向（正表示向右移动，负表示向左移动）。每一颗行星以相同的速度移动。
    /// 找出碰撞后剩下的所有行星。碰撞规则：两个行星相互碰撞，较小的行星会爆炸。如果两颗行星大小相同，则两颗行星都会爆炸。
    /// 两颗移动方向相同的行星，永远不会发生碰撞。
    /// </summary>
    public class AsteroidCollision
    {
        public int[] Asteroid_Collision(int[] asteroids)
        {
            Stack<int> stack = new Stack<int>();
            int n = asteroids.Length;      
            for (int i = 0; i < n; i++)
            {
                if (asteroids[i] > 0)
                {
                    stack.Push(asteroids[i]);
                }
                else
                {
                    //右边的行星是否能存在
                    bool flag = true;
                    while (stack.Count > 0 && stack.Peek() > 0)
                    {
                        //右边行星被撞碎
                        if (stack.Peek() > -asteroids[i])
                        {
                            flag = false;
                            break;
                        }
                        //两边湮灭
                        else if (stack.Peek() == -asteroids[i])
                        {
                            stack.Pop();
                            flag = false;
                            break;
                        }
                        //左边行星被撞碎，出栈
                        else
                        {
                            stack.Pop();
                        }
                    }
                    if (flag)
                    {
                        stack.Push(asteroids[i]);
                    }
                }
            }

            return stack.Reverse().ToArray();
        }
    }
}
