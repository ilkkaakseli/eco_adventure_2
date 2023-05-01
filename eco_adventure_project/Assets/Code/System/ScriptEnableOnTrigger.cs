using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEnableOnTrigger : MonoBehaviour
{
    [SerializeField] public ChangeSceneOnTimer changeScene;
    [SerializeField] public PhysicsMover _mover;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            changeScene.enabled = true;
            _mover.allowMovement = false;
        }
    }
}
