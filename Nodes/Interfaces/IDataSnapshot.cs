using System;

namespace Premonition.Nodes.Interfaces
{
    /// <summary>
    /// Captures the state of an asset inside the game.
    /// </summary>
    public interface IDataSnapshot
    {
        /// <summary>
        /// Object representing data to be saved inside <see cref="DataManager"/>.
        /// </summary>
        object DataState { get; }

        /// <summary>
        /// When this snapshot has been captured.
        /// </summary>
        DateTime CaptureTimestamp { get; }

        /// <summary>
        /// Unique identifier of the snapshot.
        /// </summary>
        Guid SnapshotId { get; }
    }
}