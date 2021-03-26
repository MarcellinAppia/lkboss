using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class loguser : MonoBehaviour
{
    private int nscene;
    private int pscene;
    public string baseurl = "http://localhost/lkscript/loaduser.php";
    public InputField uEmail;
    public InputField uPassword1;
    
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




    public void LoginAcccount()
    {
        string email = uEmail.text;
        string uPass1 = uPassword1.text;

        StartCoroutine(LoginNewUser(email, uPass1));

    }

    IEnumerator LoginNewUser(string email, string uPass1)
    {
        WWWForm logform = new WWWForm();

        logform.AddField("logEmail", email);
        logform.AddField("logPassword", uPass1);



        using (UnityWebRequest logwww = UnityWebRequest.Post(baseurl, logform))
        {
            logwww.downloadHandler = new DownloadHandlerBuffer();

            yield return logwww.SendWebRequest();
            if (logwww.isNetworkError)
            {
                Debug.Log(logwww.error);
            }
            else
            {
                string responseText = logwww.downloadHandler.text;
                string echo = "vous êtes connecté";
                Debug.Log("Response = " + responseText);
                

                 if (responseText == echo)
                  {

                      uEmail.text = "";
                      uPassword1.text = "";

                      nextscene();

                  }
                 

                //  info.text = "Response = " + responseText;
            }


        }


    }
}
