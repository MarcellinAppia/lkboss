using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class register : MonoBehaviour

{
 
   
    public InputField nom;
    public InputField prenom;
    public InputField email;
    public InputField numero;
    public InputField ville;
    public InputField pass;
    public InputField pass2;
    public Button registerpart1;
    public Button registerButton;
  //  public Button lbutton;
    


    public void RegisterInfo()
    {
        StartCoroutine(RegisterUser());
    }






    IEnumerator RegisterUser()
    {

    WWWForm form = new WWWForm();
        
        form.AddField("nom", nom.text);
        form.AddField("prenom", prenom.text);
        form.AddField("email", email.text);
        form.AddField("numero", numero.text);
        form.AddField("pwd1", pass.text);
        form.AddField("ville", ville.text);

        WWW www = new WWW("http://localhost/lkboss/registerUser.php", form);
        yield return www; 
            if(www.text == "0")
            {
                Debug.Log("vous etes enregistré");
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
            else
            {
                Debug.Log("erreur d'inscription" + www.text);
            }


    }


public void formcheck0()
{
        registerpart1.interactable = (nom.text.Length >= 8
            /*
                                        && prenom.text.Length >= 1
                                        && email.text.Length >= 1
                                        && numero.text.Length >= 1
                                        && ville.text.Length >= 1
            */
                                      );
}
/*
    public void formcheck1()
    {
        registerButton.interactable = (
                                     
                                        && pass.text.Length >= 5
                                        && pass2.text.Length >= 5
                                        && pass.text == pass2.text);
    }
*/



}
