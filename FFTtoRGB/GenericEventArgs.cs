using System;

namespace FFTtoRGB
{
    /// <summary>
    /// Generic event args for passing data throw EventHandlers
    /// </summary>
    /// <typeparam name="T">Data type</typeparam>
    public class GenericEventArgs<T> : EventArgs
    {
        public T Data { get; }
        public GenericEventArgs(T data) => Data = data;
    }
}
