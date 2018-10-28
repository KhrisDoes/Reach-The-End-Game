using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumeGame : MonoBehaviour {

    public static int CurrentSceneIndex;

    public void Resume()
    {
        SceneManager.LoadScene(CurrentSceneIndex);
    }

}
