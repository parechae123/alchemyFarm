using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmManager : MonoBehaviour
{
    // Start is called before the first frame update
    public PlantState[] plants = new PlantState[20];
    

    public void GrowingPlants(byte plantArr,ItemTable tmpSeed)
    {
        if(plantArr < 20)
        {
            plants[plantArr].SeedInfo = tmpSeed;
        }

    }
}
