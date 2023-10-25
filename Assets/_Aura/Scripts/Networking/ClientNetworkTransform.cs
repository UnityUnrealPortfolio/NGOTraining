using System.Collections;
using System.Collections.Generic;
using Unity.Netcode.Components;
using UnityEngine;

/// <summary>
/// Script allows player clients to be authoritative
/// over movement logic
/// </summary>
public class ClientNetworkTransform : NetworkTransform
{
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        CanCommitToTransform = IsOwner;
    }
    //allow Player to be authoritative
    protected override bool OnIsServerAuthoritative()
    {
        return false;
    }

    protected override void Update()
    {
        CanCommitToTransform = IsOwner;
        base.Update();
        if (NetworkManager != null)
        {
            if(NetworkManager.IsConnectedClient || NetworkManager.IsListening)
            {
                if(CanCommitToTransform)
                {
                    TryCommitTransformToServer(transform, NetworkManager.LocalTime.Time);
                }
            }
        }
    }
}
