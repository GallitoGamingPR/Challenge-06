using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloorManager : MonoBehaviour
{
    public static FloorManager instance;
    public List<Floors> floors;
    public UnityEvent onChanged;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Duplicated Floors");
        }
    }

    public void addFloor(Floors floor)
    {
        floors.Add(floor); //Add to list
        onChanged.Invoke();
    }

    public void removeFloor(Floors floor)
    {
        floor.FadeAndDestroy(); // Start fade out before destruction
        floors.Remove(floor); // Remove from list
        onChanged.Invoke();
    }

    public void removeFloorRandom()
    {
        // Check if the list is empty
        if (floors.Count <= 0)
        {
            print("Floor list is empty");
        }

        // Generate a Random Number in the range of the length of the list
        int randomNum = Random.Range(0, floors.Count);

        // Remove the random floor assigned to the random number
        Floors removeRandFloor = floors[randomNum];
        removeFloor(removeRandFloor);
    }
}
