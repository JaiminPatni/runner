using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject stage;
    int count;
    public float Zlength;
    private void Start()
    {
        InstantiateStage();
    }
    public void InstantiateStage()
    {
        stage = Instantiate(stage, new Vector3(0, 0.77f, count * Zlength), Quaternion.identity);
        count++;
    }
}
