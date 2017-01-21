using UnityEngine;
using System.Collections;

public class FromToMovement : MonoBehaviour {
    [SerializeField]
    private float speed = 7;
    [SerializeField]
    private float minDist = 0.01f;

    private Vector3 targetPosition;

    private bool hasTarget = false;

    Collider2D[] c;

    public void GoToPoint(Vector3 position)
    {
        targetPosition = position;

        c = GetComponents<Collider2D>();

        if (c!= null)
        {
            for (int i = 0; i < c.Length; i++)
            {
                c[i].enabled = false;
            } 
        }
        hasTarget = true;
        print(targetPosition);
    }

    void Update()
    {

        if (hasTarget)
        {
            Vector3 dir = targetPosition - transform.position;

            dir.Normalize();

            dir *= Time.deltaTime * speed;
            transform.position += dir;

            print(dir);

            if (Vector2.Distance(transform.position, targetPosition)< minDist)
            {
                
                if (c != null)
                {
                    for (int i = 0; i < c.Length; i++)
                    {
                        c[i].enabled = true;
                    }
                }

                hasTarget = false;
            }

        }

    }
	
    public float Speed
    {
        get
        {
            return speed;
        }
    }

    public float Distance
    {
        get
        {
            return Vector2.Distance(transform.position, targetPosition);
        }
    }
}
