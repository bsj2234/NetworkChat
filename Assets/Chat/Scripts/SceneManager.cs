using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : SingletonComponent<SceneManager>
{
    public event System.Action<Player> OnLocalPlayerSpawned;
    public void TriggerPlayerSpawned(Player player)
    {
        OnLocalPlayerSpawned?.Invoke(player);
    }
}
