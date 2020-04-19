using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region 싱글톤
    public static GameManager Instance
    {
        get
        {
            if (_Instance == null)
                _Instance = FindObjectOfType<GameManager>();

            if (_Instance == null)
            {
                GameObject obj = new GameObject("Manager");
                _Instance = obj.AddComponent<GameManager>();
            }

            return _Instance;
        }
    }
    private static GameManager _Instance;
    #endregion

    public int leftEnemyCount;

    public string[] enemyNames;

    public void GameStart()
    {
        /// TileManager에서 맵 생성
        TileManager.Instance.Build();
        /// 적들을 생성 - N초마다 생성하는 기능
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (leftEnemyCount > 0)
        {
            yield return new WaitForSeconds(3f);
            Spawn();
        }
    }

    private void Spawn()
    {
        int randomIndex = Random.Range(0, enemyNames.Length);
        string selectOne = enemyNames[randomIndex];
        GameObject prefab = Resources.Load<GameObject>(selectOne);
        GameObject obj = Instantiate(prefab);

        obj.transform.position =
            TileManager.Instance.spawnPoint.transform.position;
    }

    public void Gameover()
    {
        
    }

    [UnityEditor.MenuItem("게임메니저/게임 시작")]
    public static void GameStart_EDITOR()
    {
        GameManager.Instance.GameStart();
    }
}
