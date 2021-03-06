﻿/*
 *  f1livetiming - Part of the Live Timing Library for .NET
 *  Copyright (C) 2009 Liam Lowey
 *  
 *      http://livetiming.turnitin.co.uk/
 *
 *  Licensed under the Apache License, Version 2.0 (the "License"); 
 *  you may not use this file except in compliance with the License. 
 *  You may obtain a copy of the License at 
 *  
 *      http://www.apache.org/licenses/LICENSE-2.0 
 *  
 *  Unless required by applicable law or agreed to in writing, software 
 *  distributed under the License is distributed on an "AS IS" BASIS, 
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
 *  See the License for the specific language governing permissions and 
 *  limitations under the License. 
 */

using System;
using System.Threading;
using Common.Patterns.Command;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    /// <summary>
    /// Summary description for CommandQueueTest
    /// </summary>
    [TestClass]
    public class CommandQueueTest : UnitTestBase
    {
        private int _callCount = 0;
        private CommandQueue _queue;

        public override void  OnSetup()
        {
            _queue = new CommandQueue();
            _callCount = 0;
        }
        

        [TestMethod]
        public void TestQueing()
        {
            _queue.Push(CommandFactory.MakeCommand(IncrementCallCount));
            _queue.Push(CommandFactory.MakeCommand(IncrementCallCount));

            ProcessQueue(_queue,0);

            Assert.AreEqual(_callCount, 2);

            _queue.Push(CommandFactory.MakeCommand(IncrementCallCount));
            _queue.Push(CommandFactory.MakeCommand(IncrementCallCount));

            Assert.AreEqual(_callCount, 2);

            ProcessQueue(_queue,0);

            Assert.AreEqual(_callCount, 4);
        }

        [TestMethod]
        public void TestThreadNotification1()
        {
            Thread t = new Thread(WaitThread); 

            t.Start(_queue);

            Thread.Sleep(500);

            _queue.Push(CommandFactory.MakeCommand(IncrementCallCount));

            Thread.Sleep(1000);

            Assert.AreEqual(_callCount, 1);

            t.Join();
        }


        private static void ProcessQueue(CommandQueue queue, int timeoutSecs)
        {
            ICommand cmd = queue.Pop(false);
            while (cmd != null)
            {
                cmd.Execute();
                cmd.Dispose();

                cmd = queue.Pop(false);
            }
        }


        private void IncrementCallCount()
        {
            _callCount++;
        }


        private static void WaitThread(Object o)
        {
            CommandQueue q = o as CommandQueue;
            using (ICommand cmd = q.Pop())
            {
                cmd.Execute();
            }
        }
    }
}
