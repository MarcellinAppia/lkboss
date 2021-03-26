using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{

    public InputField email;
    public InputField pass;
    public Button LoginButton; 


   public void login()
    {
        StartCoroutine(Logins());
    }


    IEnumerator Logins()
    {

        WWWForm form = new WWWForm();
        form.AddField("email", email.text);
        form.AddField("pwd1", pass.text);


        WWW www = new WWW("http://localhost/lkboss/login.php", form);
        yield return www;
        if (www.text[0] == '0')
        {

            DBManager.email = email.text;
            DBManager.nom = www.text.Split('\t')[1];
            DBManager.prenom = www.text.Split('\t')[2];
            DBManager.ville = www.text.Split('\t')[3];
            DBManager.numero = www.text.Split('\t')[4];
            DBManager.psw = www.text.Split('\t')[5];
           // DBManager.psw = www.text.Split('\t')[4];
          

            UnityEngine.SceneManagement.SceneManager.LoadScene(3);
        }
        else
        {
            Debug.Log("erreur de connexion" + www.text);
        }



    }

}
