using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reference : MonoBehaviour
{
    public static reference Instance;
    public  webscript webs;
    public login login; 
    public userinfo userinfo;
    

   
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        webs = GetComponent<webscript>();
        userinfo = GetComponent<userinfo>();
        login = GetComponent<login>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    


   
}
