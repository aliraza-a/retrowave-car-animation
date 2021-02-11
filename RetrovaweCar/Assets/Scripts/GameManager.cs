using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource backgroundMusic;

    public GameObject cube;
    public Transform cubeSpawnPoint;

    public GameObject Tree;
    public Transform treeSpawnPoint;
    public float maxTreeSpawnPointLeft;
    public float minTreeSpawnPointLeft;
    public float maxTreeSpawnPointRight;
    public float minTreeSpawnPointRight;

    public GameObject startPanel;

    bool gameStarted = false;

    public static GameManager instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        if (Input.anyKeyDown && !gameStarted)
        {
            startPanel.gameObject.SetActive(false);

            backgroundMusic.Play();

            StartCoroutine("SpawnTrees");
            StartCoroutine("SpawnCubes");

            gameStarted = true;
        }
    }

    IEnumerator SpawnTrees()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            SpawnTreeRight();
            SpawnTreeLeft();
        }
    }

    IEnumerator SpawnCubes()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            SpawnCubeRight();
            SpawnCubeLeft();
        }
    }
    public void SpawnTreeLeft()
    {
        float randomTreeSpawnXLeft = Random.Range(minTreeSpawnPointLeft, maxTreeSpawnPointLeft);

        Vector3 treeSpawnPos = treeSpawnPoint.position;
        treeSpawnPos.x = randomTreeSpawnXLeft;

        Instantiate(Tree, treeSpawnPos, Quaternion.identity);
    }

    public void SpawnTreeRight()
    {
        float randomTreeSpawnXRight = Random.Range(minTreeSpawnPointRight, maxTreeSpawnPointRight);

        Vector3 treeSpawnPos = treeSpawnPoint.position;
        treeSpawnPos.x = randomTreeSpawnXRight;

        Instantiate(Tree, treeSpawnPos, Quaternion.identity);
    }

    public void SpawnCubeLeft()
    {
        float randomTreeSpawnXLeft = Random.Range(minTreeSpawnPointLeft, maxTreeSpawnPointLeft);

        Vector3 treeSpawnPos = treeSpawnPoint.position;
        treeSpawnPos.x = randomTreeSpawnXLeft;

        Instantiate(cube, treeSpawnPos, Quaternion.identity);
    }

    public void SpawnCubeRight()
    {
        float randomTreeSpawnXRight = Random.Range(minTreeSpawnPointRight, maxTreeSpawnPointRight);

        Vector3 treeSpawnPos = treeSpawnPoint.position;
        treeSpawnPos.x = randomTreeSpawnXRight;

        Instantiate(cube, treeSpawnPos, Quaternion.identity);
    }
}
