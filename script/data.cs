using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using SimpleJSON;

public class data : MonoBehaviour
{

  //  public GameObject cpro;
    public Text lg;

    Action<string> _getDataCallback;
    // Start is called before the first frame update
    void Start()
    {
        _getDataCallback = (jsonArrayString) =>
        {
            StartCoroutine(gdataRoutine(jsonArrayString));
        };

        gdata();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // recuper les infos de webs
    public void gdata() {
        string userid = reference.Instance.userinfo.userid;
        StartCoroutine(reference.Instance.webs.GetUser(userid, _getDataCallback));
    }


    IEnumerator gdataRoutine(string jsonArrayString)
    {
        JSONArray jsonArray = JSON.Parse(jsonArrayString) as JSONArray;

        for ( int i = 0; i< jsonArray.Count;i++)
        {
            bool isDone = false;

            string id = jsonArray[i].AsObject["id"];

            JSONObject infosJson = new JSONObject();

            Action<string> getInfoCallback = (ginfo) =>
            {
                isDone = true;
                JSONArray tempArray = JSON.Parse(ginfo) as JSONArray;
                infosJson = tempArray[0].AsObject;
            };

            StartCoroutine(reference.Instance.webs.GUser(id, getInfoCallback));

            yield return new WaitUntil(() => isDone == true);

            GameObject item = Instantiate(Resources.Load("Prefabs/loginCanva") as GameObject);
            //GameObject item = Instantiate(cpro) as GameObject;
          //  item.transform.SetParent(this.transform);
          //  item.transform.localScale = Vector3.one;
          //  item.transform.localPosition = Vector3.zero;

           // item.transform.Find("Text").GetComponent<Text>().text = infosJson["pseudo"];
            lg.text = infosJson["pseudo"];

           // lg.text = infosJson["pseudo"];
        }
        //Debug.Log("item.text");

        //yield return null;
    }
}
