using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class saveMensu : MonoBehaviour
{
    //public InpuField id;
    public InputField taille;
    public InputField epaule;
    public InputField poitrine;
    public InputField manche;
    public InputField totaille;

    public Text TextConfirm;
    public GameObject Confirmbox;
    public Button Cancel;


    private void Awake()
    {
        if (DBManager.nom == null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
      
        //  pass.text = DBManager.ville;

    }


    public void insertMans()
    {
        StartCoroutine(insertM());
    }

    IEnumerator insertM()
    {

        WWWForm form = new WWWForm();


        // form.AddField("nom", DBManager.nom);
        
        //form.AddField("id", id.text);
        form.AddField("manche", manche.text);
        form.AddField("epaule", epaule.text);
        form.AddField("taille", taille.text);
        form.AddField("poitrine", poitrine.text);
        form.AddField("totaille", totaille.text);



        WWW www = new WWW("http://localhost/lkboss/insertMans.php", form);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("infos mis à jour enregistré");
            Confirmbox.SetActive(true);
            TextConfirm.text = "données enregistré";
            //UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else if(www.text == "informations enregistrés")
        {

            Debug.Log("infos enregistré");
            Confirmbox.SetActive(true);
            TextConfirm.text = "données enregistré";
            //UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

        else
        {

            Debug.Log("erreur de modification" + www.text);
            TextConfirm.text = "Erreur de modification ";
        }
    }

    public void goRoom()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}