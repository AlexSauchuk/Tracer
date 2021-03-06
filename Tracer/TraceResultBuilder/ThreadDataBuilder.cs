﻿using System.Collections.Generic;
using Utilities.Tracer.TraceResultData;

namespace Utilities.Tracer.TraceResultBuilder
{
    internal class ThreadDataBuilder
    {
        private readonly ThreadController _thread;

        internal ThreadDataBuilder(ThreadController thread)
        {
            _thread = thread;
        }

        internal TraceThreadData GetResult()
        {
            return CreateThreadDataResult();
        }

        private TraceThreadData CreateThreadDataResult()
        {
            List<TraceMethodData> childList = GetChildList();
            TraceThreadData threadData = new TraceThreadData()
            {
                ExecutionTime = _thread.ExecutionTime,
                ChildMethods = childList
            };
            return threadData;
        }

        private List<TraceMethodData> GetChildList()
        {
            List<TraceMethodData> traceMethods = new List<TraceMethodData>();
            foreach (var childMethod in _thread.ChildMethods)
            {
                traceMethods.Add(new MethodDataBuilder(childMethod).GetResult());
            }
            return traceMethods;
        }
    }
}
