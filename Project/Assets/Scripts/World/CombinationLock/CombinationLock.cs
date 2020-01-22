using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace World.CombinationLock
{
    public class CombinationLock : MonoBehaviour
    {
        public Combination combination;

        public UnityEngine.Events.UnityEvent OnOpenenedEvent;

        public void OpenMenu()
        {
            var menu = GameManager.instance.combinationLock;
            menu.gameObject.SetActive(true);

            menu.combination = combination;
            menu.onCompletedAction += () =>
            {
                StartCoroutine(Unlocked(menu));
            };
        }

        private IEnumerator Unlocked(CombinationChecker menu)
        {
            menu.gameObject.SetActive(false);

            yield return new WaitUntil(() => menu.gameObject.gameObject.activeSelf == false);

            yield return new WaitForSecondsRealtime(Time.deltaTime);

            GameManager.instance.cutSceneManager.DisplayMessage("Got it!");

            OnOpenenedEvent.Invoke();
        }
    }
}