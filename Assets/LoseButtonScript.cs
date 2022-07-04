using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseButtonScript : MonoBehaviour
{
    public void LoadScene(string sceneName) {
        StartCoroutine(Transition(sceneName));
    }

    IEnumerator Transition(string sceneName) {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }
}
