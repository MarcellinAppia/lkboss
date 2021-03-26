using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class userUpInfo : MonoBehaviour
{

    public InputField pass;
    public InputField pass2;
    //public InputField pass2;

    public Text nom;
    public Text TextConfirm;
    public GameObject Confirmbox;
    public GameObject Mensu;
    public GameObject PassUpdate;
    public Button Cancel;
    public Button Gomans;

    private void Awake()
    {
        if (DBManager.nom == null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        nom.text = DBManager.nom;
        //  pass.text = DBManager.ville;


    }


    public void UpdateInfop()
    {
        StartCoroutine(uinfop());
    }

    IEnumerator uinfop()
    {

        WWWForm form = new WWWForm();

        /*form.AddField("nom", nom.text);
        form.AddField("prenom", prenom.text);
        form.AddField("numero", numero.text);
        form.AddField("ville", ville.text);
        form.AddField("email", email.text);*/
        form.AddField("nom", DBManager.nom);
        form.AddField("pwd1", pass.text);


        WWW www = new WWW("http://localhost/lkboss/updateUser.php", form);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("modification reussie");
            Confirmbox.SetActive(true);
            TextConfirm.text = "Modification reusssie";
            //UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else
        {

            Debug.Log("erreur de modification" + www.text);
            TextConfirm.text = "Erreur de modification ";
        }



    }

    public void closeBox()
    {
        Confirmbox.SetActive(false);
    }

    public void mansA()
    {
        Mensu.SetActive(true);
        PassUpdate.SetActive(false);
    }
}
