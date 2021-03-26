using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    // Start is called before the first frame update
    public float xr;
    public float xy;
    public float xz; 
    public float speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xr* speed, xy* speed, xz* speed, Space.Self);
    }
}
