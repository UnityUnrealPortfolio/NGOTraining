using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : NetworkBehaviour
{
    [Header("Input reader reference")]
    [SerializeField] private SOInputReader inputReader;
    [Header("Tank references")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform tankBodyTransform;

    [Header("Movement Variables")]
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private float playerMoveSpeed;
    [SerializeField] private float tankBodyTurnRate;

    private Vector2 previousMovementInput;

    public override void OnNetworkSpawn()
    {
        if (!IsOwner)
        {
            return;
        }
        inputReader.OnPlayerMove += HandlePlayerMove;
        inputReader.OnPlayerPrimaryFire += HandlePlayerPrimaryFire;
    }
    public override void OnNetworkDespawn()
    {
        if (!IsOwner)
        {
            return;
        }
        inputReader.OnPlayerMove-= HandlePlayerMove;
        inputReader.OnPlayerPrimaryFire-= HandlePlayerPrimaryFire;
    }

    private void Update()
    {
        if (!IsOwner) return;

        float zRotation = previousMovementInput.x * -tankBodyTurnRate * Time.deltaTime;
        tankBodyTransform.Rotate(0f, 0f, zRotation);
    }

    private void FixedUpdate()
    {
        if (!IsOwner) return;

        playerRB.velocity = (Vector2)tankBodyTransform.up * previousMovementInput.y * playerMoveSpeed;
    }
    #region Input Reader Callbacks
    private void HandlePlayerPrimaryFire(bool _value)
    {

    }

    private void HandlePlayerMove(Vector2 _value)
    {
        previousMovementInput = _value;
    } 
    #endregion
}
