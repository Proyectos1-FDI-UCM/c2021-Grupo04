using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class SkipCutscene : MonoBehaviour
{

    public float timeToSkip = 12f;


    void Start()
    {
        Time.timeScale = 1;
        Invoke("SkipScene", timeToSkip);       
    }


    private void SkipScene()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    
}
