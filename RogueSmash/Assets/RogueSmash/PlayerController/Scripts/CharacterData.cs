using UnityEngine;
using System;

namespace SAGAMES.RogueSmash.PlayerController.Scripts
{
    [Serializable]
    public struct CharacterData
    {
        #region Variables

        [Header("Movement")]
        [SerializeField] private float movementSpeed;
        [SerializeField] private int maxHealth;
        [SerializeField] private int maxLives;


        public float MovementSpeed
        {
            get { return movementSpeed; }
        }
        public int MaxHealth
        {
            get { return maxHealth; }
        }
        public int MaxLives
        {
            get { return maxLives; }
        }

        #endregion
    }
}
//By Sean González
