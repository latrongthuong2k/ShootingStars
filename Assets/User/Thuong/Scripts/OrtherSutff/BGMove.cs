using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour
{
    public int Speed = 1;
    public Vector3 loopPosition;
    // Update is called once per frame
    protected virtual void Update()
    {
        Move();
        LoopPos();
    }
    protected virtual void Move()
    {
        gameObject.transform.Translate(Vector3.left * Time.deltaTime * Speed);
    }
    protected virtual void LoopPos()
    {
        if (this.transform.position.x <= -61)
        {
           this.transform.position = loopPosition;
        }
    }


}
