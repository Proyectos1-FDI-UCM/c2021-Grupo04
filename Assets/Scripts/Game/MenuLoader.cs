using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoader : MonoBehaviour
{
    //Miguel

    public float timeToLoadMenu = 19f;
    private void Start()
    {
        Invoke("LoadMenu", timeToLoadMenu);
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene(1);
    }
}
