using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] monsterTypes;
    public static GameObject spawnedMonster;
    [SerializeField] private Transform leftSide, rightSide;
    public int randomSide;
    public int randomIndex;
    bool turn_Enemy ;

    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        while(NewBehaviourScript.isAlive)
        {
            randomIndex = Random.Range(0, monsterTypes.Length);
            randomSide = Random.Range(0, 2);
            spawnedMonster = Instantiate(monsterTypes[randomIndex]);

            if (randomSide == 0)
            {
                spawnedMonster.transform.position = leftSide.position;
                spawnedMonster.GetComponent<Enemy>().speed = Random.Range(13, 16);
            }
            else
            {
                spawnedMonster.transform.position = rightSide.position;
                spawnedMonster.GetComponent<Enemy>().speed = -Random.Range(3, 6);
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            yield return new WaitForSeconds(3f);

            
        }
        
    }
   

}
