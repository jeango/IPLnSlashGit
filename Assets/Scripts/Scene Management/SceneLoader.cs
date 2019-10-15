using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName ="Scene Management/Scene Loader")]
public class SceneLoader : ScriptableObject
{
    public string sceneName;
    public LoadSceneMode loadMode;

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName, loadMode);
    }
}
