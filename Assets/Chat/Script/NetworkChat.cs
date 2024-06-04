using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NetworkChat : NetworkBehaviour
{
    [Header ("SetPlayerColor reference richText")]
    [SerializeField] private string E_playerChatColor = "teal";

    public string _chatContent { get; private set; }
    private string _playerName;

    public void SendUserChat(string name,string message)
    {
        _playerName = name;
        if(isServerOnly)
        {
            return;
        }
        CommandSendMessage(name, message);
    }

    [Command(requiresAuthority = false)]
    private void CommandSendMessage(string name, string message)
    {
        _chatContent = _chatContent + message;
        RpcSendMessage(name, message);
    }

    [ClientRpc]
    private void RpcSendMessage(string name, string message)
    {
        if(this.name == name)
        {
            GetChatFormated(name, message, E_playerChatColor);
        }
        else
        {
            GetChatFormated(name, message);
        }
    }

    private string GetChatFormated(string name, string message)
    {
        return $"{name}: {message}";
    }
    private string GetChatFormated(string name, string message, string color)
    {
        return $"<color={color}>{GetChatFormated(name, message)}</color>";
    }

}
