using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    public string sceneName;
    public GameObject canvas;
    public List<GameObject> menuObjects = new List<GameObject>();

    public void LoadByIndex()
    {
        StartCoroutine(LoadingScene());
        canvas.SetActive(false);
        

    }
    public void Settings()
    {
        menuObjects[0].SetActive(true);
        
    }

    public void Back()
    {
        menuObjects[0].SetActive(false);
        
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }
    IEnumerator LoadingScene()
    {
        yield return new WaitForSeconds(2f);
        
        SceneManager.LoadScene(sceneName);
    }

    
    
}