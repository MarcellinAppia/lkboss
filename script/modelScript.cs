using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modelScript : MonoBehaviour
{
    public Animation anim;
    public int animindex;
    void Start()
    {
        anim = GetComponent<Animation>();
    }
    void Update()
    {
        animindex = mainScript.animationIndex;
        try
        {
            anim.CrossFade(mainScript.animationClip[mainScript.animationIndex]);
           
        }
        catch (Exception e)
        {
            //Error
        }
    }


}
