using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // public void Init(List<Vector2> _Path)
    // {

    // }

    public IEnumerator TravelToEnd(List<Vector2> _Path)
    {
        foreach (Vector2 _p in _Path)
        {
            while ((Vector2)transform.position != _p)
            {
                yield return new WaitForEndOfFrame();
                transform.position = Vector2.MoveTowards(transform.position, _p, Time.deltaTime * 4f);
            }
        }

        //What happens after reaching to the end?
        Destroy(gameObject);
    }
}
