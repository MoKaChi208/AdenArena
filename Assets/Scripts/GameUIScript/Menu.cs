using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public Button Login;
    public Button Signin;

    public Text LogText;
    private void Start()
    {
        if (DBManager.LoggedIn)
        {
            LogText.text = "Welcome back "+ DBManager.username.ToUpper()+ "!";
            Login.gameObject.SetActive(false);
            Signin.gameObject.SetActive(false);
        }

    }
    public void GoToRegister()
    {
        SceneManager.LoadScene(1);
    }


    public void GotoLogin()
    {
        SceneManager.LoadScene(1);
    }

    public void HostGame()
    {
        SceneManager.LoadScene(3);
    }

    public void JoinGame()
    {
        SceneManager.LoadScene(3);
    }
}
