using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor;


public class SpaceShooter2DSceneManager : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad;

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneToLoad);

    }


}
