using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class login : MonoBehaviour
{
    private int nscene;
    private int pscene;
    public InputField Ipseudo;
    public InputField Ipass;
    public Button loginbutton;
    public Button register;

   
   



    // Start is called before the first frame update
    void Start()
    {
       // string a = Debug.Log("je mange");
        nscene = SceneManager.GetActiveScene().buildIndex + 1;
        pscene = SceneManager.GetActiveScene().buildIndex - 1;

        loginbutton.onClick.AddListener(() => {

            StartCoroutine(reference.Instance.webs.Login(Ipseudo.text, Ipass.text));
        });

        register.onClick.AddListener(() => {
            SceneManager.LoadScene(pscene);
        });



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

    /**

    public void Login()
    {
        string pseudo = Ipseudo.text;
        string pass = Ipass.text;
        StartCoroutine(Login(pseudo, pass));
      

    }

     **/

    /*
    IEnumerator Login(string pseudo, string pass1)
    {
    


        WWWForm form = new WWWForm();
        form.AddField("luser", pseudo);
        form.AddField("lpass", pass1);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/lkscript/loaduser.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            } else if (www.downloadHandler.text == "vous êtes connecté") {
                SceneManager.LoadScene(nscene);
            }
            else
            {
                string responseText = www.downloadHandler.text;
               // string dv = "Vous etes connecte";
                Debug.Log("Response = " + responseText);


                


                //  info.text = "Response = " + responseText;
            }
        }
    } 

    */
}
