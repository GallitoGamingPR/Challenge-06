using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WavesManager : MonoBehaviour
{
    public static WavesManager instance;
    public List<Spawner> waves;
    public UnityEvent onChanged;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Instance duplicated, ignore this");
        }
    }

    public void AddWave(Spawner wave)
    {
        waves.Add(wave);
        onChanged.Invoke();
    }

    public void RemoveWave(Spawner wave)
    {
        waves.Remove(wave);
        onChanged.Invoke();
    }
}
