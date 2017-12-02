using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagement : MonoBehaviour {

	public void ChangeScene ( int sceneIndex )
    {
        Debug.Log("Play button pressed");
        Application.LoadLevel(sceneIndex);
    }
}
