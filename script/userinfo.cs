using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class userinfo: MonoBehaviour

{
    public string userid { get; private set; }
    string userPseudo;
    string userPass;


    public void Setuserinfo(string pseudo, string pass1)
    {
        userPseudo = pseudo;
        userPass = pass1;

       

    }


    public void SetID(string id)
    {
        userid = id; 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
