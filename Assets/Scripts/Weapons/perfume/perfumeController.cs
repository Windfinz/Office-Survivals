using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perfumeController : WeaponController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    private protected override void Attack()
    {
        base.Attack();
        GameObject spawnedperfume = Instantiate(prefab);
        spawnedperfume.transform.position = transform.position;
        spawnedperfume.transform.parent = transform;
    }
}
