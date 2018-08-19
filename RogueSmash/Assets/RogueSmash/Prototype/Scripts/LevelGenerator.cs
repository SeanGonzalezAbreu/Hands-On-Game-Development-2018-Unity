using UnityEngine;
using System.Collections.Generic;
using System;

namespace SAGAMES.RogueSmash.Prototype.Scripts
{
    public class LevelGenerator : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Collider safeZone;
        [SerializeField] private Vector3 levelCenter;
        [SerializeField] private int levelWidth;
        [SerializeField] private int levelHeight;
        [SerializeField] private int obstacleCount;
        [SerializeField] private float itemDistanceBuffer = 2;
        [SerializeField] private GameObject obstaclePrefab;
        private List<Vector3> spawnedObstacleLocations = new List<Vector3>();

        #endregion

        #region Unity Methods

        private void Start()
        {
            GenerateLevel();
        }

        #endregion

        #region Class Methods

        private void GenerateLevel()
        {
            for (int i = 0; i < obstacleCount; i++)
            {
                GenerateObstacle();
            }
        }

        private void GenerateObstacle()
        {
            int attemps = 0;
            bool slotFound = false;
            Vector3 randomPoint = Vector3.zero;
            while (attemps < 5 && !slotFound)
            {
                int x = UnityEngine.Random.Range((int)levelCenter.x - levelWidth / 2, (int)levelCenter.x + levelWidth / 2);
                int z = UnityEngine.Random.Range((int)levelCenter.z - levelHeight / 2, (int)levelCenter.z + levelHeight / 2);
                randomPoint = new Vector3(x, levelCenter.y, z);
                if (TestPoint(randomPoint, spawnedObstacleLocations))
                {
                    slotFound = true;
                    spawnedObstacleLocations.Add(randomPoint);
                    Instantiate(obstaclePrefab, randomPoint, Quaternion.identity);
                }
                else
                {
                    attemps++;
                }

            }
        }

        private bool TestPoint(Vector3 _point2Test, List<Vector3> _otherPoints)
        {
            if (safeZone.bounds.Contains(_point2Test)) return false;
            if (_otherPoints.Count == 0) return true;
            foreach (Vector3 otherPoint in _otherPoints)
            {
                if (Vector3.Distance(_point2Test, otherPoint) < itemDistanceBuffer)
                {
                    return false;
                }
            }
            return true;
        }

        #endregion
    }
}
//By Sean González