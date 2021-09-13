using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace PingPong.Utils
{
    public static class Timer
    {
        private static MonoBehaviour _dumbMonoBehaviour;

        static Timer()
        {
            var go = new GameObject("DumbGameObject", typeof(DumbMonoBehaviour));
            _dumbMonoBehaviour = go.GetComponent<DumbMonoBehaviour>();
        }

        public static async Task Wait(float waitTime)
        {
            var task = new TaskCompletionSource<bool>();
            _dumbMonoBehaviour.StartCoroutine(WaitForSecond(waitTime, task));
            await task.Task;
        }

        public static IEnumerator WaitForSecond(float waitTime, TaskCompletionSource<bool> taskCompletionSource)
        {
            yield return new WaitForSeconds(waitTime);
            taskCompletionSource.SetResult(true);
        }
    }
}