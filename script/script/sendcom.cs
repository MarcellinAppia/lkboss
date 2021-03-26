using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class sendcom : MonoBehaviour
{
    //public string baseUrl = "http://localhost/lkscript/insert.php";

    private int nscene;
    private int pscene;
    public InputField Nom;
    public InputField prenom;
    public InputField mail;
    public InputField tel;
    public InputField livraison;
    public InputField taille;
    public InputField epaule;
    public InputField ttaille;
    public InputField poitrine;
    public InputField manche;


    // Start is called before the first frame update
    void Start()
    {
        nscene = SceneManager.GetActiveScene().buildIndex + 1;
        pscene = SceneManager.GetActiveScene().buildIndex - 1;
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void nextscene()
    {
        SceneManager.LoadScene(nscene);
    }

    public void previouscene()
    {
        SceneManager.LoadScene(pscene);
    }


    //fonction  d'enregistrement utilisateur

    public void Sendata()
    {


      ;
       
        string SNom = Nom.text;
        string Sprenom = prenom.text;
        string Smail = mail.text;
        string Stel = tel.text;
        string Slivraison = livraison.text;
        string Staille = taille.text;
        string Sepaule = epaule.text;
        string Sttaille = ttaille.text;
        string Spoitrine= poitrine.text;
        string Smanche = manche.text;



    StartCoroutine(datastring(SNom, Sprenom, Smail, Stel, Slivraison, Staille, Sepaule, Sttaille, Spoitrine, Smanche));


    }




    //routine d'enregistrement

    IEnumerator datastring(string SNom, 
                            string Sprenom, 
                            string Smail, 
                            string Stel,
                            string Slivraison,
                            string Staille,
                            string Sepaule, 
                            string Sttaille,
                            string Spoitrine,
                            string Smanche)
    {
        WWWForm form = new WWWForm();
        form.AddField("lname", SNom);
        form.AddField("lsurname", Sprenom);
        form.AddField("lemail", Smail);
        form.AddField("tel", Stel);
        form.AddField("livraison", Slivraison);
        form.AddField("taille", Staille);
        form.AddField("epaule", Sepaule);
        form.AddField("ttaille", Sttaille);
        form.AddField("poitrine", Spoitrine);
        form.AddField("manche", Smanche);
       




        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/lkscript/commandSend.php", form))
        {
            www.downloadHandler = new DownloadHandlerBuffer();

            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string responseText = www.downloadHandler.text;
                string dv = " Vous êtes enregistré, connectez vous";
                Debug.Log("Response = " + responseText);

                if (responseText == dv)
                {
                    Nom.text = "";
                    prenom.text = "";
                    mail.text = "";
                    tel.text = "";
                    livraison.text = "";
                    taille.text = "";
                    epaule.text = "";
                    ttaille.text = "";
                    poitrine.text = "";
                    manche.text = "";
                    // SceneManager.LoadScene(nscene);
                }

                //  info.text = "Response = " + responseText;
            }


        }


    }






}
