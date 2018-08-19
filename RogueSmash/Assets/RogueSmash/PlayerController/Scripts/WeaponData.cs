using UnityEngine;
using System;

namespace SAGAMES.RogueSmash.PlayerController.Scripts
{
    [Serializable]
    public struct WeaponData
    {
        #region Variables

        [Header("General Characteristics")]
        [SerializeField] private int maxAmmo;
        [SerializeField] private float minFireInterval;

        [Header("Reload")]
        [SerializeField] private float reloadTime;
        [SerializeField] private bool doesAutoReload;

        [Header("Projectile")]
        [SerializeField] private float baseDamage;
        [SerializeField] private float projectileSpeed;
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private float projectileLifeTime;
        #endregion
        #region Property Accessors

        public int MaxAmmo
        {
            get { return maxAmmo; }
        }

        public float MinFireInterval
        {
            get { return minFireInterval; }
        }

        public float ReloadTime
        {
            get { return reloadTime; }
        }

        public float BaseDamage
        {
            get { return baseDamage; }
        }

        public bool DoesAutoReload
        {
            get { return doesAutoReload; }
        }

        public float ProjectileSpeed
        {
            get { return projectileSpeed; }
        }

        public GameObject ProjectilePrefab
        {
            get { return projectilePrefab; }
        }

        public float ProjectileLifeTime
        {
            get { return projectileLifeTime; }
        }

        #endregion
    }
}
//By Sean González
