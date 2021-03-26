using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class webscript : MonoBehaviour

{

    [SerializeField] int nscene;
    [SerializeField] int pscene;
    //public Button login;
    

    // Start is called before the first frame update
    void Start()
    {

        nscene = SceneManager.GetActiveScene().buildIndex + 1;
        pscene = SceneManager.GetActiveScene().buildIndex - 1;
        // StartCoroutine(GetUser());
        // StartCoroutine(Login("kjeem", "12345"));
        // StartCoroutine(Registeru("mimi", "mimi","mima","shege@gmail.com","121212"));

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

    public IEnumerator GetUser(string userid, System.Action<string> callback   )
    {
        WWWForm form = new WWWForm();
        form.AddField("userid", userid);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/lkscript/getUser.php", form))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string jsonArray = www.downloadHandler.text;
                callback(jsonArray);
                Debug.Log(www.downloadHandler.text);

            }
        }
    }



    public IEnumerator GUser(string id, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("id", id);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/lkscript/getdata.php", form))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string jsonArray = www.downloadHandler.text;
                callback(jsonArray);
                Debug.Log(www.downloadHandler.text);

            }
        }
    }




    public IEnumerator Login(string pseudo, string pass1 )
    {
        WWWForm form = new WWWForm();
        form.AddField("luser", pseudo);
        form.AddField("lpass", pass1);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/lkscript/loaduser.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {

                string jsonArray = www.downloadHandler.text;

                // string response = www.downloadHandler.text;  

                //Debug.Log(www.downloadHandler.text);

                try {
                    Debug.Log(jsonArray);
                    reference.Instance.userinfo.Setuserinfo(pseudo, pass1);
                    reference.Instance.userinfo.SetID(jsonArray);
                    SceneManager.LoadScene(nscene);
                }
                catch (Exception e )
                {
                    Debug.LogException(e, this);
                }

                if (jsonArray.Contains("email/mot de passe incorrect") || jsonArray.Contains("enregistrez vous!"))
                {
                    Debug.Log("Idemtifiant/mot de passe incorrect");
                }


            }
        }
    }





    public IEnumerator Registeru(string nom, string prenom, string pseudo, string email, string pass1, string pass2)
    {
        WWWForm form = new WWWForm();
        form.AddField("lname", nom);
        form.AddField("lsurname", prenom);
        form.AddField("luser", pseudo);
        form.AddField("lemail", email);
        form.AddField("lpass", pass1);
        form.AddField("lpass2", pass2);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/lkscript/insert.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
               
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text == " Vous êtes enregistré, connectez vous")
                {
                    SceneManager.LoadScene(nscene);
                }
            }
        }
    }
}
      