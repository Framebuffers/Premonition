namespace Premonition.Nodes.Interfaces
{
    /// <summary>
    /// Each asset must implement this interface to be able to save and restore extrinsic data.
    /// </summary>
    public interface IAssetDataRetrieval
    {
        /// <summary>
        /// Export the current state of the object back to DataManager as a snapshot. Each object handles what and how data will be saved.
        /// </summary>
        /// <returns>A snapshot containing an anonymous object with data and identifying information.</returns>
        IDataSnapshot Save();

        /// <summary>
        /// Loads state from an snapshot back to the object. <see cref="IDataSnapshot.DataState"/> must be cast to the base class to obtain their data.
        /// </summary>
        /// <param name="snapshot">A snapshot taken from this object.</param>
        void Restore(IDataSnapshot snapshot);
    }
}