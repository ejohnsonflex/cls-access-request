﻿using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

//public class ServerCommunications : MonoBehaviour
public class CommunicationsBKK : MonoBehaviour
{
    //private string _jsonResponse = string.Empty;
    public string JSON { get; set; }

    public IEnumerator NetworkManager (UnityWebRequest uWR)
    {
        // send request and wait for response
        yield return uWR.SendWebRequest();

        if (uWR.isNetworkError || uWR.isHttpError)
        {
            Debug.LogError("Network error");
            yield break;
        }

        //Debug.Log("Status Code: " + uWR.responseCode);
        //Debug.Log("Number of Bytes: " + uWR.downloadedBytes);

        else if (uWR.isDone)
        {
            var previewResponse = new PreviewResponse();
            /*previewResponse.DeserializePreviewResponse(uWR.downloadHandler.text);*/

            //JSON = uWR.downloadHandler.text;
            //yield break;
        }

        /*if (uWR.responseCode == 200)
        {

            _jsonResponse = uWR.downloadHandler.text;
            //Debug.Log(uWR.downloadHandler.text);
            Debug.Log(_jsonResponse);
        }*/

        //byte[] _byte = Encoding.UTF8.GetBytes(request.downloadHandler.text);
        //string results = request.downloadHandler.text;
    }

    public void PreviewRequestSendBKK()
    {
        //var previewRequest = new PreviewRequest();
        //Debug.Log("Host Type: " + previewRequest.HostId.Type + "     " + "HostId: " + previewRequest.HostId.Value);
        //string jsonString = previewRequest.SerializePreviewRequest(previewRequest);
        //Debug.Log(jsonString);

        string jsonString = new PreviewRequest().SerializePreviewRequest(new PreviewRequest());

        string url = ConfigDat.URL + "/preview_request";
        //string url = ("https://flex13005-uat.compliance.flexnetoperations.eu/api/1.0/instances/YLR8N2Y7DQS1/preview_request");
        Debug.Log(url);

        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonString);
        Debug.Log("Number of Byes in Request: " + System.Text.ASCIIEncoding.ASCII.GetByteCount(jsonString));

        var unityWebRequest = new UnityWebRequest(url, "POST");

        unityWebRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
        string getByte = Encoding.ASCII.GetString(bodyRaw);
        unityWebRequest.downloadHandler = new DownloadHandlerBuffer();
        unityWebRequest.timeout = -1;
        unityWebRequest.SetRequestHeader("Content-Type", "application/json");
        unityWebRequest.SetRequestHeader("Authorization", "Bearer " + ConfigDat.BearerToken);
        Debug.Log(ConfigDat.BearerToken);

        StartCoroutine(NetworkManager(unityWebRequest));
        StopCoroutine(NetworkManager(unityWebRequest));
    }

    /*public string GetJsonPreviewResponse()
    {
        return _jsonResponse;
    }*/

        //public void TalkToServer()
        //{
        // Connected to Preview / License Button and OnClick EventSystem
        //StartCoroutine(CommunicateToServer());
        //}

        /*IEnumerator CommunicateToServer()
        //public void CommunicateToServer()
        {
            string url = "https://flex13005-uat.compliance.flexnetoperations.eu/api/1.0/instances/0YBV7VG7HDL1/preview_request";

            //string url = CLSURL.ClsURl.Url() + ("/preview_request");
            Debug.Log(url);

            List<string> array = new List<string>();
            //array.Add("ANY");                                                         // implement
            //array.Add("EMEA");                                                        // implement

            var pR = new PreviewRequest("string", "wmelby@revenera.com", array);        // implement
            //var f1 = new Feature(1, "dsr", "1.0");                               // implement
            //var f2 = new Feature(1, "dsr.advanced", "1.0");                      // implement
            //pR.Features.Add(f1);
            //pR.Features.Add(f2);

            string jsonStr = JsonConvert.SerializeObject(pR);
            Debug.Log(jsonStr);

            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonStr);
            Debug.Log("Number of Byes in Request: " + System.Text.ASCIIEncoding.ASCII.GetByteCount(jsonStr));

            UnityWebRequest request = new UnityWebRequest(url, "POST");

            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            string getByte = Encoding.ASCII.GetString(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();

            request.SetRequestHeader("Content-Type", "application/json");
            //request.SetRequestHeader("Authorization", "Bearer " + ConfigManager.ReturnBearerToken());
            request.SetRequestHeader("Authorization", "Bearer " + "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwicm9sZXMiOiJST0xFX0NBUEFCSUxJVFkifQ.C8K43qlPcD8GR5ZfhqsZkPfc_Srkcx9RYnF5gcSeIik6dT9yIFaWJrBTzo5Ar0Yj0jfFXp0XdoWi6dS2vATgl31aBFHC4hcOf_kz2aAzS7FuWEelIxauYWz2kfJxS5VPqwRlKLFd7V1rXFVcUbIqbUScN0tyyUkeNgXHDa2oM4fELhflqMlrLqvwJPmONNQAhhYhXX67JLRimV0jmmAG3MN48T3FsjBMUOJEU2kUwJSX-RjggfG39DuOKiXb7b68e2PevDmcwgjKh6CVSXp9bds3jGTraYe6iQKUFYhyGJHHhzdArXLiUrra0xuKlwN38aDp9qcJgMaFpi3oW7rmlw");

            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
            {
                Debug.LogError("Network error");
            }

            else
            {
                Debug.Log("Status Code: " + request.responseCode);
                Debug.Log("Number of Bytes: " + request.downloadedBytes);

                byte[] _byte = Encoding.UTF8.GetBytes(request.downloadHandler.text);
                string results = request.downloadHandler.text;

                string jsonResult = System.Text.Encoding.UTF8.GetString(request.downloadHandler.data);

                PreviewResponse response = (JsonConvert.DeserializeObject<PreviewResponse>(results));

                Debug.Log(response.requestHostId.value);
                Debug.Log(response.requestHostId.type);
                Debug.Log(response.features[0].name);
                Debug.Log(response.features[0].maxCount);
                Debug.Log(response.features[0].expires.ToLocalTime());
            }
        }*/
}