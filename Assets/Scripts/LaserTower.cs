using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTower : MonoBehaviour
{
    public float shootingDistance = 2f;
    LineRenderer lineRenderer;
    Enemy currentTarget;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
    }

    void Update()
    {
        DetectEnemy();
    }

    void DetectEnemy()
    {
        if (currentTarget != null)
        {
            Vector2 _targetPos = currentTarget.transform.position;
            if (Vector2.Distance(transform.position, _targetPos) < shootingDistance)
            {
                //Shoot
                lineRenderer.enabled = true;
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, _targetPos);

                //Decreasing the HP of enemy
                currentTarget.enemyHp = Mathf.MoveTowards(currentTarget.enemyHp, 0f, Time.deltaTime * 10f);
                if (currentTarget.enemyHp == 0f)
                {
                    Destroy(currentTarget.gameObject);
                    RemoveTarget();
                }
            }
            else
                RemoveTarget();
        }
        else
        {
            //Searching
            RemoveTarget();
            Collider2D _target = Physics2D.OverlapCircle(transform.position, shootingDistance);

            if (_target != null)
                currentTarget = _target.GetComponent<Enemy>();
        }
    }

    void RemoveTarget()
    {
        currentTarget = null;
        lineRenderer.enabled = false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, shootingDistance);
    }
}
