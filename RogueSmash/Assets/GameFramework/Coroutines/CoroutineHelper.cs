using System;
using System.Collections;
using UnityEngine;

namespace SAGAMES.GameFramework.Coroutines
{
    public class CoroutineHelper
    {
        #region Class Methods


        public static void RunCoroutine(Func<IEnumerator> _coroutine, bool _selfDestruct = true)
        {
            GameObject runner = new GameObject("CoroutineRunner");
            CoroutineInstance coroutineInstance = runner.AddComponent<CoroutineInstance>();
            coroutineInstance.StartCoroutine(coroutineInstance.Run(_coroutine, _selfDestruct));
        }
        #endregion
    }
}
//By Sean González
