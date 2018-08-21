using SAGAMES.RogueSmash.Weapons;
using System;
using UnityEngine;

namespace SAGAMES.RogueSmash.Prototype.Scripts
{

    public class WeaponController
    {
        #region Variables

        [System.Serializable]
        public struct WeaponControllerData
        {
            public GameObject projectilePrefab;
            public Transform projectileSpawnPoint;
        }
        private GameObject projectilePrefab;
        private Transform projectileSpawnPoint;

        #endregion

        #region Class Methods

        public WeaponController(WeaponControllerData weaponData)
        {
            projectilePrefab = weaponData.projectilePrefab;
            projectileSpawnPoint = weaponData.projectileSpawnPoint;

        }
        public void Use()
        {
            SpawnProjectile();
        }

        private void SpawnProjectile()
        {
            GameObject spawnedProjectile = GameObject.Instantiate(projectilePrefab
                , projectileSpawnPoint.transform.position
                , projectileSpawnPoint.transform.rotation);
            Projectile projectile = spawnedProjectile.AddComponent<Projectile>();
            projectile.Init(projectileSpawnPoint.transform.forward);
            projectile.Shoot();
        }

        #endregion
    }
}
//By Sean González
