#region Usings

using System;

#endregion

namespace PortableExtensions
{
    /// <summary>
    ///     Class containing some extension methods for <see cref="EventHandler" /> and <see cref="EventHandler{T}" />.
    /// </summary>
    public static class EventHandlerEx
    {
        /// <summary>
        ///     Raises the given <see cref="EventHandler" /> with
        ///     <paramref name="sender" />as sender and
        ///     <paramref name="e" />as argument.
        /// </summary>
        /// <param name="eventHandler">The <see cref="EventHandler" /> to raise.</param>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <returns>Returns the given event handler.</returns>
        public static EventHandler Raise ( this EventHandler eventHandler, Object sender, EventArgs e )
        {
            if ( eventHandler != null )
                eventHandler( sender, e );

            return eventHandler;
        }

        /// <summary>
        ///     Raises the given <see cref="EventHandler" /> with
        ///     <paramref name="sender" />as sender and
        ///     <paramref name="e" />as argument.
        /// </summary>
        /// <typeparam name="T">The type of the event arguments.</typeparam>
        /// <param name="eventHandler">The <see cref="EventHandler" /> to raise.</param>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        /// <returns>Returns the given event handler.</returns>
        public static EventHandler<T> Raise<T> ( this EventHandler<T> eventHandler, Object sender, T e )
            where T : EventArgs
        {
            if ( eventHandler != null )
                eventHandler( sender, e );

            return eventHandler;
        }
    }
}