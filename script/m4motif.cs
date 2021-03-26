using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m4motif : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject canvasHaut;
    public GameObject canvasBas;
    public bool haut;

    void Start()
    {
        haut = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (haut)
        {
            canvasHaut.SetActive(true);
            canvasBas.SetActive(false);
        }
        else
        {
            canvasHaut.SetActive(false);
            canvasBas.SetActive(true);
        }


    }


    public void MySwitch(){
        if (haut)
        {
           haut = false;
        }
        else
{
    haut = true;
}


}


}
