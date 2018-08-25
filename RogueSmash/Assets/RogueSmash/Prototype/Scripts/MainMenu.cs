using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace SAGAMES
{
    public class MainMenu : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Button button;

        #endregion
        #region Unity Callbacks

        private void OnEnable()
        {
            button.onClick.AddListener(StartGame);
        }
        private void OnDisable()
        {
            button.onClick.RemoveAllListeners();
        }

        #endregion

        #region Class Methods
        private void StartGame()
        {
            GoToLevel("ControlsTest");
        }

        public void GoToLevel(string _levelName)
        {
            SceneManager.LoadScene(_levelName);
        }

        #endregion
    }
}
//By Sean González
