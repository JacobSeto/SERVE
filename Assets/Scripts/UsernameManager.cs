using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UsernameManager : MonoBehaviour
{
    [SerializeField] TMP_InputField usernameInput;

    private void Start()
    {
        print("changing username");
        if (PlayerPrefs.HasKey("username"))
        {
            usernameInput.text = PlayerPrefs.GetString("username");
            PhotonNetwork.NickName = usernameInput.text;
             OnUsernameInputValueChange();
        }
        else
        {
            usernameInput.text = "Player " + Random.Range(0, 10000).ToString("0000");
            OnUsernameInputValueChange();
        }
    }

    public void OnUsernameInputValueChange()
    {
        PhotonNetwork.NickName = usernameInput.text;
        PlayerPrefs.SetString("username", usernameInput.text);
        PlayerPrefs.Save();
        // print(PhotonNetwork.NickName);
    }

    void Update()
    {
        OnUsernameInputValueChange();
        // print("updating");
    //     if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
    //     {
    //         print("updating");
    //         OnUsernameInputValueChange();
    //     }
    }

}
