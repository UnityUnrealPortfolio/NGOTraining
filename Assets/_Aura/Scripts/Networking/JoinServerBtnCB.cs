
using Unity.Netcode;
using UnityEngine;

public class JoinServerBtnCB : MonoBehaviour
{
    public void HandleJoinServer()
    {
        NetworkManager.Singleton.StartClient();
    }
}
