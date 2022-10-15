using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

//this class should derive from NetworkBehaviour
public class NetworkPlayer : NetworkBehaviour, IPlayerLeft
{
    //way to access the local network player
    public static NetworkPlayer Local { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Spawned()
    {
        if (Object.HasInputAuthority)
        {
            Local = this;
            Debug.Log("Spawned one player");
        }
        else
        {
            Debug.Log("Spawned other player's character");
        }
    }
    public void PlayerLeft(PlayerRef player)
    {
        //dealing with player leaving
        if (player == Object.InputAuthority)
        {
            Runner.Despawn(Object);
        }
    }
   
}
