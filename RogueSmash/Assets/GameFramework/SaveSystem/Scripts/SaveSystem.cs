using UnityEngine;
using SAGAMES.GameFramework.SaveSystem.Interfaces;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace SAGAMES.GameFramework.SaveSystem
{
    public class SaveSystem : MonoBehaviour
    {
        #region Variables

        private readonly string savePath;
        private IFileWriter fileWriter;
        private IFileReader fileReader;

        #endregion
        #region Construtors

        public SaveSystem(IFileWriter _fileWriter, IFileReader _fileReader)
        {
            savePath = Application.persistentDataPath + "/save.dat";
            this.fileWriter = _fileWriter;
            this.fileReader = _fileReader;
        }
        public SaveSystem()
        {
            fileWriter = new DefaultFileWriter();
            fileReader = new DefaultFileReader();
        }
        #endregion
        #region Class Methods

        public T Load<T>() where T : class
        {
            if (!File.Exists(savePath)) return null;
            using (MemoryStream stream = new MemoryStream(fileReader.Read(savePath)))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                T o = formatter.Deserialize(stream) as T;
                return o;
            }
        }

        public void Save(object _data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream _stream = new MemoryStream())
            {
                formatter.Serialize(_stream, _data);
                byte[] bytes = _stream.ToArray();
                fileWriter.Write(bytes, savePath);
            }
        }

        #endregion
    }
}
//By Sean González
