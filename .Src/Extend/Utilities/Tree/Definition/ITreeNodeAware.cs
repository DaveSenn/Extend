namespace Extend
{
    /// <summary>
    ///     Interface representing a type which gets informed about it's tree node.
    /// </summary>
    /// <typeparam name="T">The type of the nodes value.</typeparam>
    public interface ITreeNodeAware<T>
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the node of the object.
        /// </summary>
        /// <value>The node of the object.</value>
        ITreeNode<T> Node { get; set; }

        #endregion
    }
}