using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class m5motifs : MonoBehaviour
{

    public Texture[] myTextures;
    public Sprite[] lemotif;
    public Image motif;
    public Text mtext;


    public int arrayPos;
    private int nextarray;
    private int prevarray;

    // Start is called before the first frame update
    void Start()
    {
        arrayPos = 0;
        nextarray = arrayPos + 1;
        prevarray = nextarray -1;
        mtext.text = lemotif[arrayPos].name;
        
       
        //  GetComponent<Renderer>().material.mainTexture = myTextures[arrayPos];
    }

    // Update is called once per frame
    void Update()
    {
       
            GetComponent<Renderer>().material.mainTexture = myTextures[arrayPos];// changer la texture d'un objet

            motif.sprite = lemotif[arrayPos];// changer l'image d'un element ui

        
       
           if (arrayPos > myTextures.Length)
        {
            previousmotif();
            // arrayPos = myTextures.Length - 1;
          
        }
        if (arrayPos < 0)
        {
            nextmotif();
        }
         

         




    }


    /*
    public void changeMotif() 
    {

    }
   
     */



    public void nextmotif()
        
    {




        arrayPos = nextarray;

        mtext.text = lemotif[nextarray].name;





        /*if (arrayPos < myTextures.Length)
          {
              arrayPos += 1;
          }
          else
          {
              arrayPos += 0;
          }
          */
    }

    public void previousmotif()
    {

        arrayPos = prevarray;
        mtext.text = lemotif[prevarray].name;
        //arrayPos -= 1;





        //mtext.text = mtext.text - lemotif[arrayPos];
        /* if (arrayPos > 0)
           {
               arrayPos -= 1;
           }
           else
           {
               arrayPos += 0;
           }
         */
    }
}
