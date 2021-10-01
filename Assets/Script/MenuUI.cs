using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuUI : MonoBehaviour
{
    private AsyncOperation async = null;

    void Start() {
        StartCoroutine(LoadScene());
    }

    public void StartGame() {
        async.allowSceneActivation = true;
    }

    public void ExitGame() {
        Application.Quit();
    }

    IEnumerator LoadScene() {
        async = SceneManager.LoadSceneAsync(1);
        async.allowSceneActivation = false;
        while (!async.isDone) {
            yield return null;
        }
    }
}
