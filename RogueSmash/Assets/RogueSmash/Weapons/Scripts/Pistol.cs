using System.Collections;
using SAGAMES.GameFramework.InputSystem.Interfaces;
using SAGAMES.RogueSmash.PlayerController.Scripts;
using SAGAMES.GameFramework.Coroutines;
using UnityEngine;
using SAGAMES.GameFramework.ResourceSystem.Interfaces;

namespace SAGAMES.RogueSmash.Weapons
{
    public class Pistol : IWeapon
    {
        #region Variables

        private MeshRenderer meshRenderer;
        private WeaponData weaponData;
        private IResource ammo;
        private bool isReloading = false;
        private float lastFire = 0;
        private Transform actorLocation;
        public IResource Ammo { get { return ammo; } }


        #endregion
        #region Constructor

        public Pistol(WeaponData _weaponData, GameObject _actor, MeshRenderer _meshRenderer)
        {
            this.weaponData = _weaponData;
            this.actorLocation = _actor.transform;
            this.meshRenderer = _meshRenderer;
            ammo = new Ammo(weaponData.MaxAmmo);
        }

        #endregion
        #region Contract Methods

        public void Reload()
        {
            meshRenderer.material.color = Color.red;
            isReloading = true;
            CoroutineHelper.RunCoroutine(ReloadTimer);
        }

        public bool Shoot()
        {
            if (lastFire + weaponData.MinFireInterval > Time.time)
            {
                //Debug.LogWarning("Click");
                return false;
            }
            if (isReloading)
            {
                //Debug.LogWarning("Reloading");
                return false;
            }
            if (ammo.CurrentValue > 0)
            {
                ammo.Remove(1);
                lastFire = Time.time;
                SpawnProjectile();
                //Debug.Log("PEW" + currentAmmo + "/" + weaponData.MaxAmmo);
                return true;
            }
            if (ammo.CurrentValue <= 0 && weaponData.DoesAutoReload)
            {
                //Debug.LogWarning("Reloading");
                Reload();
                return false;
            }
            else
            {
                //Debug.LogWarning("Out of Ammo");
                return false;
            }
        }
        #endregion
        #region Class Methods

        private void SpawnProjectile()
        {
            GameObject instance = GameObject.Instantiate(weaponData.ProjectilePrefab, actorLocation.position, actorLocation.rotation);
            instance.name = "Projectile";
            Projectile projectile = instance.AddComponent<Projectile>();
            projectile.Init(actorLocation.forward.normalized, weaponData.ProjectileSpeed);
            projectile.Shoot();
            //Rigidbody rb = instance.GetComponent<Rigidbody>();
            //rb.velocity = rb.transform.forward.normalized * weaponData.ProjectileSpeed;
            //GameObject.Destroy(instance, weaponData.ProjectileLifeTime);
        }

        private IEnumerator ReloadTimer()
        {
            float timer = 0f;
            while (timer <= weaponData.ReloadTime)
            {
                timer += Time.deltaTime;
                yield return null;
            }
            //Debug.LogError("Reload Complete");
            meshRenderer.material.color = Color.white;
            ammo.Add(weaponData.MaxAmmo);
            isReloading = false;
        }
        #endregion
    }
}
//By Sean González
