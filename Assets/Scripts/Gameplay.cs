using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public Map map;
    public GameObject refEnemy;

    void Start()
    {
        refEnemy.SetActive(false);
        StartCoroutine(NewWave());
    }

    //Coroutines
    IEnumerator NewWave()
    {
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.3f);
            GameObject _e = Instantiate(refEnemy, map.Waypoints[0], Quaternion.identity);
            _e.SetActive(true);

            Enemy _enemy = _e.GetComponent<Enemy>();
            _enemy.StartCoroutine(_enemy.TravelToEnd(map.Waypoints));
        }
    }
}
