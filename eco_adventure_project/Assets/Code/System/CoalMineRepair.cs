using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalMineRepair : MonoBehaviour
{
    [SerializeField] public SpriteRenderer openMine;
    [SerializeField] public SpriteRenderer closedMine;
    [SerializeField] public ChangeSceneOnTimer changeSceneOnTimer;
    [SerializeField] public PhysicsMover _physicsMover;

    private void Start()
    {
        closedMine.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _physicsMover.allowMovement = false;
            closeMine();
            changeSceneOnTimer.enabled = true;

            
        }
    }
    public void closeMine()
    {
        openMine.enabled = false;
        closedMine.enabled = true;
    }
}
