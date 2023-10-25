
using Unity.Netcode;
using UnityEngine;

public class ConnectionButtonsCB : MonoBehaviour
{
    public void HandleJoinAsClient()
    {
        NetworkManager.Singleton.StartClient();
    }

    public void HandleJoinAsHost()
    {
        NetworkManager.Singleton.StartHost();
    }
}
