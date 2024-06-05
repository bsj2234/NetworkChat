using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginUi : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_InputField InputField_userId;
    [SerializeField] private TMPro.TMP_InputField InputField_userPassword;
    public void OnLogin()
    {
        if(Login.RequestLogin(InputField_userId.text, InputField_userPassword.text))
        {
            Debug.Log("Success");
        }
        else
        {
            Debug.Log("Fail");
        }
    }
}
