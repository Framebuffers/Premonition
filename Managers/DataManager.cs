using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Godot;
using Premonition.Nodes.Interfaces;

namespace Premonition.Managers
{
    public sealed partial class DataManager : Node
    {
        private List<IDataSnapshot> _snapshots { get; set; } = new List<IDataSnapshot>();
        private DataManager() { }
        [Required]
        private static DataManager _instance;
        private static readonly object _lock = new();
        public static DataManager GetDataManager()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new DataManager();
                        return _instance;
                    }
                }
            }
            return _instance;
        }

        public void SaveSnapshot(IDataSnapshot snapshot)
        {
            _snapshots.Add(snapshot);
        }

        public void CaptureState(IAssetDataRetrieval assetToCapture)
        {
            _snapshots.Add(assetToCapture.Save());
        }

        public void RestoreState(IAssetDataRetrieval assetToRestore)
        {

        }

    }
}
