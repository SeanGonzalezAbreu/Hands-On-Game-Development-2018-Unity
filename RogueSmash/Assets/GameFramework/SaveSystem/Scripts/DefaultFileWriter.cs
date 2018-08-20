using SAGAMES.GameFramework.SaveSystem.Interfaces;
using System.IO;
using UnityEngine;

namespace SAGAMES.GameFramework.SaveSystem
{
    public class DefaultFileWriter : IFileWriter
    {
        #region Contract Methods

        public void Write(byte[] data, string path)
        {
            File.WriteAllBytes(path, data);
        }

        #endregion
    }
}
//By Sean González
