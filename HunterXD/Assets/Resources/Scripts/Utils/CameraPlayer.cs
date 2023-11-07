using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    [SerializeField] private Actor _player;
    public float offsetX, offsetY;

    void Update()
    {
        Vector2 playerPosition = _player.transform.position;
        transform.position = new Vector3(playerPosition.x + offsetX, playerPosition.y + offsetY, transform.position.z);
    }
}
