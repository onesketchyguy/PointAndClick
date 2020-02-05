using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Loading
{
    public class LoadingScreen : MonoBehaviour
    {
        public static int levelToLoad = 0;

        public GameObject door;

        private void OnEnable()
        {
            if (levelToLoad >= 0)
            {
                Load(levelToLoad);
            }
            else
            {
                Debug.LogError("Build index invalid!");

                Load(0);
            }

            door.SetActive(false);
        }

        private void OnDisable()
        {
            levelToLoad = -1;
        }

        private AsyncOperation loadingOperation;
        private Scene sceneTryingToLoad;

        public void Load(int indexToLoad)
        {
            StartCoroutine(LoadSceneIn(indexToLoad));
        }

        private IEnumerator LoadSceneIn(int index)
        {
            yield return null;

            loadingOperation = SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
            loadingOperation.allowSceneActivation = false;

            while (loadingOperation.progress < 0.9f)
            {
                // do nothing
                yield return null;
                Debug.Log($"Loading {SceneManager.GetSceneAt(index).name}...{loadingOperation.progress * 100}%");
            }

            sceneTryingToLoad = SceneManager.GetSceneByBuildIndex(index);

            door.SetActive(true);
        }

        private IEnumerator UnloadScene()
        {
            var index = SceneManager.GetActiveScene();
            Camera.main.gameObject.GetComponent<AudioListener>().enabled = false;

            loadingOperation.allowSceneActivation = true;

            yield return null;
            SceneManager.SetActiveScene(sceneTryingToLoad);

            var unloading = SceneManager.UnloadSceneAsync(index, UnloadSceneOptions.None);
            yield return new WaitWhile(() => unloading.isDone == false);
        }

        public void OpenScene()
        {
            StartCoroutine(UnloadScene());
        }
    }
}