using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using UnityEngine.Networking;
using System.Text;

public class InGameRankMain : MonoBehaviour
{
    public string host;
    public string idurl;
    public string posturl;

    public SpawnManagerScriptableObject scriptableObject;

    public void GetScore()
    {
        var url = string.Format("{0}/{1}", host, idurl);
        Debug.Log(url);

        StartCoroutine(this.GetId(url, (raw) =>
        {
            var res = JsonConvert.DeserializeObject<Protocols.Packets.res_scores_id>(raw);
            if (res.result == null)
            {
                PostScore();
                UserStatus.score = scriptableObject.score;
            }
            else
            {
                UserStatus.score = res.result.score;
                Debug.LogFormat("{0} : {1}", res.result.id, UserStatus.score);
            }
        }));
    }

    public void PostScore()
    {
        var url = string.Format("{0}/{1}", host, posturl);
        Debug.Log(url);

        var req = new Protocols.Packets.req_scores();
        req.id = scriptableObject.id;
        req.score = scriptableObject.score;

        var json = JsonConvert.SerializeObject(req); // Object to string
        Debug.Log(json);

        StartCoroutine(this.GetPost(url, json, (raw) =>
        {
            Protocols.Packets.res_scores res = JsonConvert.DeserializeObject<Protocols.Packets.res_scores>(raw);
            Debug.LogFormat("{0}, {1}", res.cmd, res.message);
        }));
    }
    // Start is called before the first frame update
    void Start()
    {
        GetScore();
    }

    private IEnumerator GetId(string url, System.Action<string> callback)
    {
        var webRequest = UnityWebRequest.Get(url);
        yield return webRequest.SendWebRequest();

        Debug.Log("--->" + webRequest.downloadHandler.text);

        if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("네트워크 환경이 안좋아서 통신을 할수 없습니다.");
        }
        else
        {
            callback(webRequest.downloadHandler.text);
        }
    }

    private IEnumerator GetPost(string url, string json, System.Action<string> callback)
    {
        var webRequest = new UnityWebRequest(url, "POST");
        var bodyRaw = Encoding.UTF8.GetBytes(json); // string to byte list

        webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");

        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("네트워크 환경이 안좋아서 통신을 할수 없습니다.");
        }
        else
        {
            Debug.LogFormat("{0}\n{1}\n{2}", webRequest.responseCode, webRequest.downloadHandler.data, webRequest.downloadHandler.text);
            callback(webRequest.downloadHandler.text);
        }

        webRequest.Dispose();
    }
}
