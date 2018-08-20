using UnityEngine;
namespace SAGAMES.RogueSmash.PlayerController.Scripts
{
    [CreateAssetMenu(fileName = "New CharacterDataTemplate", menuName = "SAGAMES/Data/Create Character Data Teemplate")]
    public class CharacterDataTemplate : ScriptableObject
    {
        #region Variables

        [SerializeField]
        private CharacterData characterData;
        public CharacterData Data { get { return characterData; } }

        #endregion
    }
}
//By Sean González
