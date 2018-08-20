using SAGAMES.GameFramework.SaveSystem.Interfaces;
using System.IO;
using UnityEngine;

namespace SAGAMES.GameFramework.SaveSystem
{
    public class DefaultFileReader : IFileReader
    {
        #region Contract Methods

        public byte[] Read(string path)
        {
            if (File.Exists(path))
            {
                return File.ReadAllBytes(path);
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}
//By Sean González
