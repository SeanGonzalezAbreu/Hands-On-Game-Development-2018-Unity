using System;
using System.Collections;
using UnityEngine;

namespace SAGAMES.GameFramework.Coroutines
{
    public class CoroutineInstance : MonoBehaviour
    {
        #region Class Methods

        public IEnumerator Run(Func<IEnumerator> _runner, bool _selfDestruct = true)
        {
            yield return StartCoroutine(_runner.Invoke());
            Destroy(gameObject);
        }

        #endregion
    }
}
//By Sean González
