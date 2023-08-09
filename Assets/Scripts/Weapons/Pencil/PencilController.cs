using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilController : WeaponController
{

    protected override void Start()
    {
        base.Start();
    }

    private protected override void Attack()
    {
        base.Attack();
        GameObject spawnPencil = Instantiate(weaponData.Prefab);
        spawnPencil.transform.position = transform.position;
        spawnPencil.GetComponent<PencilBehaviour>().DirectionChecker(pm.lastMovedVector);
    }
}
