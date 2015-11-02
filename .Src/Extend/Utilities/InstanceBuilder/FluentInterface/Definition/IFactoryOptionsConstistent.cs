namespace Extend
{
    /// <summary>
    ///     Interface representing a configured factory.
    /// </summary>
    /// <typeparam name="T">The type of the object to create.</typeparam>
    public interface IFactoryOptionsConstistent<T> : IFactoryOptionsInconsistent<T>, ICreateInstanceOptions<T> where T : class
    {
    }
}