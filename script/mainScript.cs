using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[]models;
    public static string[] animationClip = { "Idle (1)", "Arms Hip Hop Dance", "Belly Dance","Female Sitting Pose","Walking","Salsa Dancing","Twist Dance" };
    public static int animationIndex;
    public int modelIndex;
    public bool m1, m2, m3, m4, m5;
    void Start()
    {
        modelIndex = 0;
        animationIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //--- Change Model ----

        if (modelIndex <= 0 || modelIndex >= models.Length+1)
        {
            modelIndex = 0;
        }

        try
        {
            if (modelIndex == 0)
            {
                models[0].SetActive(true);
            }
            else
            {
                models[0].SetActive(false);
            }

            if (modelIndex == 1)
            {
                models[1].SetActive(true);
            }
            else
            {
                models[1].SetActive(false);
            }

            if (modelIndex == 2)
            {
                models[2].SetActive(true);
            }
            else
            {
                models[2].SetActive(false);
            }
            if (modelIndex == 3)
            {
                models[3].SetActive(true);
            }
            else
            {
                models[3].SetActive(false);
            }
            if (modelIndex == 4)
            {
                models[4].SetActive(true);
            }
            else
            {
                models[4].SetActive(false);
            }
            if (modelIndex == 5)
            {
                models[5].SetActive(true);
            }
            else
            {
                models[5].SetActive(false);
            }
        }
        catch (Exception e)
        {
           //Error
        }

        
        //--- End change position -----



    }

    public void ChangeModel()
    {

        modelIndex += 1;
    }
    public void ChangeAnimation()
    {
        animationIndex += 1;
        if (animationIndex > animationClip.Length - 1)
        {
            animationIndex = 0;
        }
        
    }

    public void Buy()
    {

    }

    public void MailSend()
    {

    }
    public void Delivery()
    {

    }
    public void Facebook()
    {

    }

    public void Close()
    {
        Application.Quit();
    }

}
