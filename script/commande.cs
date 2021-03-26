using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class commande : MonoBehaviour

{
    public GameObject panier;
    public GameObject cmdbox;
    public GameObject plus;
    public GameObject moins;
    public Text cmdnumber;
    public Text motifText;
    public Text CmdText;
    public Text OrderC;
    public Text OrderCa;
    public Text OrderConfirmCancel;
    public Text OrderConfirm;
    public Text Ok;
    private int com;
    public Text comtext;

    public InputField confirm;
    public InputField prix;
    private int n;
    private int o;
   // private int mincmd;
    private int b;
    public GameObject CConfirmation;
    public GameObject ConfirmPanel;
    public GameObject FinalCommand; 


    //inputfield var 




    //  public int command; 

    // Start is called before the first frame update
    void Start()
    {
        panier.SetActive(false);
       // n = 1;
       // b = n;
        //mincmd = 1;
        com = 1;

        o = 20000;
       
        prix.text = o.ToString(); 
       // cmdbox.SetActive(false);

      
        cmdnumber.text = "";
    }

    // Update is called once per frame
    void Update()
    {

        
        

    }

    //nouvelle commande activer la notification 
   public void NewCommand()
    {
        

        panier.SetActive(true);

        n = n + 1;

        com = Random.Range(250,100000);
        comtext.text = "comlk" + com.ToString();
        cmdnumber.text = n.ToString();
        cmdbox.SetActive(false);
        /*
           for (int n = 0; n < 10; n++)
        {
            n += 1;
            cmdnumber.text = n.ToString();
        }   
         */




    }

    // activer le formulaire de commande 
    public void cCmd()
    {
        if (panier.activeInHierarchy == true)
        {
            cmdbox.SetActive(true);
            confirm.text = cmdnumber.text;
            motifText.text = CmdText.text;
           
        }

        
    }
   
    //fermer le formulaire de commande 
    public void closeCmd()
    {
        cmdbox.SetActive(false);
    } 



    // reduire les commandes 
    public void cMoins()
    {

       
        n = n- 1;
        o /= 2;
        

        prix.text = o.ToString();
        if (n == 0)
        {
            cPlus();
        }

            confirm.text = n.ToString();
        if (panier.activeInHierarchy == true)
        {
            cmdnumber.text = confirm.text;
        }
            

    }

    //augmenter les commandes 
    public void cPlus()
    {
        
            n=n+1;
           
        o*= 2;
        prix.text = o.ToString();
        confirm.text = n.ToString();

        if(panier.activeInHierarchy == true){
            cmdnumber.text = confirm.text;
        }
        
        // Debug.Log(n);

        //n += 1;
        //confirm.text = n.ToString();
    }


    //annuler une commande 


    public void cConfirmationI()
    {
        CConfirmation.SetActive(true);
    }


    public void cpanel()
    {
        ConfirmPanel.SetActive(true);
    }
    


    //confirmer l'annulation
    public void CancelConfirm()
    {
        string r = "Oui";
       
       
        string CoOrderC = OrderC.text;
       


        if (r == CoOrderC)
        {
            n = 0;
            o = 20000;
            CConfirmation.SetActive(false);
            cmdbox.SetActive(false);
            panier.SetActive(false);
            
        }

       
    }


    //aannler 
    public void Cancelabort()
    {
        string s = "Non";
        string CanOrderC = OrderCa.text;
        if (s == CanOrderC)
        {
            CConfirmation.SetActive(false);
        }
    }


    //orderconfirm cancel


    public void confirmOrderC()
    {
        string confirm = OrderConfirmCancel.text;
        string r = "Non";

        if (confirm == r) {

            ConfirmPanel.SetActive(false);

        }

    }


        public void confirmOrder()
        {

            string confirm = OrderConfirm.text;
            string r = "Oui";

            if (confirm == r)
            {

                ConfirmPanel.SetActive(false);
                n = 0;
            o = 20000;
            CConfirmation.SetActive(false);
                cmdbox.SetActive(false);
                panier.SetActive(false);
                FinalCommand.SetActive(true);

            }


        }


    public void closefinalCmd()
    {
        FinalCommand.SetActive(false);
    }


}
