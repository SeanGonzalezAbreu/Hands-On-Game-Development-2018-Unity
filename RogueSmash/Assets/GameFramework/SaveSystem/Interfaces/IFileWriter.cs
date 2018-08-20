namespace SAGAMES.GameFramework.SaveSystem.Interfaces
{
    public interface IFileWriter
    {
        #region Variables

        void Write(byte[] data, string path);

        #endregion
    }
}
//By Sean González
