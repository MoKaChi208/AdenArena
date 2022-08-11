using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Login : MonoBehaviour
{
    public InputField username;
    public InputField password;
    

    public void CallLogin()
    {
        StartCoroutine(UserLogin());
    }

    
    IEnumerator UserLogin()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username.text);
        form.AddField("password", password.text);
        

        WWW www = new WWW("1.55.74.17:80/sqlconnect/selectUser.php", form);
        yield return www;
        

        if (www.text != null && www.text.Contains("0"))
        {
            SceneManager.LoadScene(0);
            Debug.Log("Login successful");
            DBManager.username = username.text;
        }
        else
        {
            Debug.Log("Login fail on function #" + www.text);
        }
    }
}
