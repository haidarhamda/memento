using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInput", menuName = "Input/PlayerInput")]
class PlayerInput : ScriptableObject
{
    [Header("Movement Keys")]
    public KeyCode Left;
    public KeyCode Right;

    [Header("Action Keys")]
    public KeyCode SpecialAction;

    public Vector2 MoveInput => new Vector2(
        Convert.ToInt32(Input.GetKey(Right)) - Convert.ToInt32(Input.GetKey(Left)),0
    );


}

