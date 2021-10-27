using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemyHp = 10f;

    public IEnumerator TravelToEnd(List<Vector2> _Path)
    {
        float _moveSpeed = Random.Range(3.5f, 5.5f);
        foreach (Vector2 _p in _Path)
        {
            while ((Vector2)transform.position != _p)
            {
                yield return new WaitForEndOfFrame();
                transform.position = Vector2.MoveTowards(transform.position, _p, Time.deltaTime * _moveSpeed);
            }
        }

        //What happens after reaching to the end?
        Destroy(gameObject);
    }
}
