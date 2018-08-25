using SAGAMES.GameFramework.ResourceSystem.Interfaces;
using SAGAMES.RogueSmash.Enemies;
using UnityEngine;
using UnityEngine.UI;

namespace SAGAMES.RogueSmash.HUD
{
    public class BossHud : MonoBehaviour
    {
        #region Variables

        private IResource health;
        [SerializeField] private Text nameTag;
        [SerializeField] private Slider healthBar;
        #endregion

        #region Unity Callbacks

        private void Start()
        {
            GameObject boss = GameObject.FindWithTag("Boss");
            BasicBoss bossScript = boss.GetComponent<BasicBoss>();
            health = bossScript.Health;
            health.OnValueChanged += OnValueChanged;
            healthBar.maxValue = health.CurrentValue;
            healthBar.value = healthBar.maxValue;
            nameTag.text = "Bad Cylinder";
        }

        #endregion

        #region Class Methods

        private void OnValueChanged(float _newValue)
        {
            healthBar.value = _newValue;
        }

        #endregion
    }
}
//By Sean González
