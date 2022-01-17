using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "ProceduralCity/Rules")]
public class Rule : ScriptableObject
{


    [System.Serializable]
    public struct Data
    {
        public char letter;
        public string[] results;
    }

    public Data[] datas;

    [SerializeField]
    private bool randomResult = false;

    public string GetResult(int dataNumber)
    {
        if(randomResult)
        {
            int randomIndex = UnityEngine.Random.Range(0, datas[dataNumber].results.Length);
            return datas[dataNumber].results[randomIndex];
        }
        return datas[dataNumber].results[0];
    }
    // public string GetResult()
    // {
    //     if (randomResult)
    //     {
    //         int randomIndex = UnityEngine.Random.Range(0, results.Length);
    //         return results[randomIndex];
    //     }
    //     return results[0];
    // }
}
