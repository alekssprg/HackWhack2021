using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public static Spawner singleton { get; private set; }
    List<Transform> spawnPoints = new List<Transform>();
    HashSet<int> spareStars = new HashSet<int>();
    public GameObject starPrefab;
    // public List<GameObject> starPrefabs = new List<GameObject>();
    private int amountStarts = 3;

    private void Awake()
    {
        singleton = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("StarPosition").Select(t => t.transform).ToList();
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            spareStars.Add(i);
        }
        SpawnStars();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateOneStar()
    {
        SpawnStat(GetRandomSpawnTransformIndex());
    }

    public void AddSpareStat(int index)
    {
        spareStars.Add(index);
    }

    private int GetRandomSpawnTransformIndex()
    {
        int index = UnityEngine.Random.Range(0, spareStars.Count);
        int transformIndex = spareStars.ElementAt(index);
        spareStars.Remove(transformIndex);
        return transformIndex;
    }

    private void SpawnStars()
    {
        for (int i = 0; i < amountStarts; i++)
        {
            GameObject stat = SpawnStat(GetRandomSpawnTransformIndex());
        }
    }

    private GameObject SpawnStat(int spawnTransformIndex)
    {
        // var prefab = starPrefabs[UnityEngine.Random.Range(0, starPrefabs.Count)];
        var element = starPrefab.GetComponent<Star>();
        element.index = spawnTransformIndex;
        return Instantiate(starPrefab, spawnPoints[spawnTransformIndex]);
    }
}

