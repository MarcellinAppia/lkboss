using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class insertuser : MonoBehaviour
{
    //public string baseUrl = "http://localhost/lkscript/insert.php";

    private int nscene;
    private int pscene;
    public InputField userSurName;
    public InputField userName;
    public InputField userPseudo;
    public InputField userEmail;
    public InputField userPassword1;
    public InputField userPassword2;


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

    public void AccountRegister()
    {

        
        string uSurName = userSurName.text;
        string uName = userName.text;
        string uPseudo = userPseudo.text;
        string email = userEmail.text; 
        string uPass1 = userPassword1.text;
        string uPass2 = userPassword2.text;
        StartCoroutine(RegisterNewAccount(uSurName, uName, uPseudo, email, uPass1, uPass2));
        

    }




    //routine d'enregistrement

    IEnumerator RegisterNewAccount(string uSurName, string uName, string uPseudo, string email , string uPass1, string uPass2)
    {
        WWWForm form = new WWWForm();
        form.AddField("userSurName", uSurName);
        form.AddField("newuserName", uName);
        form.AddField("newuserPseudo", uPseudo);
        form.AddField("newuserEmail", email);
        form.AddField("newuserPassword1", uPass1);
        form.AddField("newuserPassword2", uPass2);

        


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/lkscript/insert.php", form))
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
                    userSurName.text = "";
                    userName.text = "";
                    userPseudo.text = "";
                    userEmail.text = "";
                    userPassword1.text = "";
                    userPassword2.text = "";

                    SceneManager.LoadScene(nscene);
                }
               
                //  info.text = "Response = " + responseText;
            }

            
        }

        
    }






}
