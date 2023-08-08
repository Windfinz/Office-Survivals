using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilBehaviour : ProjectileController
{
    PencilController pc;
    protected override void Start()
    {
        base.Start();
        pc = FindObjectOfType<PencilController>();
    }

    void Update()
    {
        transform.position += direction * pc.speed * Time.deltaTime;
    }
}
