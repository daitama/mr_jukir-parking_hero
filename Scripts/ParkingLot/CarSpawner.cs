using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject car_prefab;
    
    [SerializeField]
    private float spawn_rate;

    private float _spawner_area_x;
    private float _spawner_area_z;

    // Start is called before the first frame update
    void Start()
    {
        _spawner_area_x = GetComponent<MeshFilter>().mesh.bounds.extents.x * GetComponent<Transform>().localScale.x;
        _spawner_area_z = GetComponent<MeshFilter>().mesh.bounds.extents.z * GetComponent<Transform>().localScale.z;

        StartCoroutine(SpawnCarWave());
    }

    // Update is called once per frame
    void Update()
    {
        IncrementDifficulty();
    }

    void SpawnCar()
    {
        GameObject spawned_car = Instantiate(car_prefab) as GameObject;
        spawned_car.transform.position = new Vector3(Random.Range(-_spawner_area_x, _spawner_area_x), 0.1f, Random.Range(-_spawner_area_z, _spawner_area_z));
    }

    IEnumerator SpawnCarWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawn_rate);
            SpawnCar();
        }
    }

    void IncrementDifficulty()
    {
        switch (Mathf.RoundToInt(Time.time))
        {
            case 30:
                spawn_rate = 9;
                UITextManager.instance.SetLevel(1);
                break;
            case 60:
                spawn_rate = 6;
                UITextManager.instance.SetLevel(2);
                break;
            case 90:
                spawn_rate = 5;
                UITextManager.instance.SetLevel(3);

                break;
            case 150:
                spawn_rate = 3;
                UITextManager.instance.SetLevel(4);

                break;
            case 180:
                spawn_rate = 1;
                UITextManager.instance.SetLevel(5);
                break;
            case 240:
                spawn_rate = 0.75f;
                UITextManager.instance.SetLevel(6);
                break;
            case 300:
                spawn_rate = 0.45f;
                UITextManager.instance.SetLevel(7);
                break;
        }
    }
}
