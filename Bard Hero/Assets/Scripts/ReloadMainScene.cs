using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadMainScene : MonoBehaviour {

    void Start()
    {
        StartCoroutine(waitAndReset());
    }

	public IEnumerator waitAndReset()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Main");
    }
}
