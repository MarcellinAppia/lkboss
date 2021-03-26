using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class menuprincipal : MonoBehaviour
{


    public GameObject info0;
    public GameObject info1;
    public GameObject info2;
    public Text email;
    public Text nom;
    public Text ville;
    public Text prenom;
    public Text numero;
    public Text pwd;



    private void Start()
    {
        if (DBManager.loggedIn)
        {
            email.text = DBManager.email;
            nom.text = DBManager.nom;
            prenom.text = DBManager.prenom;
            ville.text = DBManager.ville;
            numero.text = DBManager.numero;
            pwd.text = DBManager.psw;
        }
    }


        public void backinfo0()
        {
            // SceneManager.LoadScene(0);
            info0.SetActive(true);
            info1.SetActive(false);
            info2.SetActive(false);
        }

    public void backinfo1()
    {
        // SceneManager.LoadScene(0);
        info0.SetActive(false);
        info1.SetActive(true);
        info2.SetActive(false);
    }

    public void goinfo1()
    {
        // SceneManager.LoadScene(1);
        info0.SetActive(false);
        info1.SetActive(true);
        info2.SetActive(false);
    }


    public void goinfo2()
    {
        //  SceneManager.LoadScene(2);
        info0.SetActive(false);
        info1.SetActive(false);
        info2.SetActive(true);
    }



    public void goLogin()
    {
        SceneManager.LoadScene(2);
    }

}
