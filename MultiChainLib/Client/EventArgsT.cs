using System;

namespace MultiChainLib.Client
{
    public class EventArgs<T> : EventArgs
    {
        public EventArgs()
        {
        }

        public EventArgs(T item)
        {
            Item = item;
        }

        public T Item { get; set; }
    }
}