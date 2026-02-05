using UnityEngine;
using System.Collections.Generic;

public class DeathZonesManager : MonoBehaviour
{
    public List<deathZonesGroup> deathZonesGroups;
    private int index = 0;
    void Update()
    {
		//IMPORTANT : A tej plus tard, debug
		if (Input.GetKeyDown("r"))
		{
            DeathZonesSwap();
		}
	}

    public void DeathZonesSwap()
    {
        DeathZonesReset();
        foreach (EnemyDeathZone zone in deathZonesGroups[index].deathZones)
        {
            zone.SetState(true);
        }
		if (index + 1 < deathZonesGroups.Count) index++; else index = 0;

	}

	public void DeathZonesReset()
    {
        foreach(deathZonesGroup groups  in deathZonesGroups)
        {
            foreach(EnemyDeathZone zone in groups.deathZones)
            {
                zone.SetState(false);
            }
        }
    }
}

[System.Serializable]
public class deathZonesGroup
{
    public List<EnemyDeathZone> deathZones; 
}
