using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class PoisonFoodEffects : MonoBehaviour
{

    public BoxCollider2D gridArea;

    private FunctionTimer functionTimer;
    
    private void Start()
    {
        RandomizePosition();
        functionTimer = new FunctionTimer(Respawn, 3f);
    }
    private void Update()
    {
        functionTimer.Update();
    }
    private void Respawn()
    {
        new FunctionTimer(Respawn, 3f);
        RandomizePosition();
    }

    private void RandomizePosition()
    {
        Bounds bounds = this.gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
         
    }

}