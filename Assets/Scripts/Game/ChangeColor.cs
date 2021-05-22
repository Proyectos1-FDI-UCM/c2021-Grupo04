using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private Renderer rend;

    [SerializeField]
    private Color cambiocolor = Color.red;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    public IEnumerator Colorear()
    {
        rend.material.color = cambiocolor;
        yield return new WaitForSeconds(0.3f);
        rend.material.color = Color.white;
    }

    public void CambiaColor()
    {
        StartCoroutine(Colorear());
    }
}
