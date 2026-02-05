using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public GameData data;

    public bool randomEventActive =true;
    private float currentTimer;
    private float beatMin;
    private float beatMax;

    void Start()
    {
        beatMax = data.randomEventTimerMax;
        beatMin = data.randomEventTimerMin;
        Pulse();
    }

    void Pulse()
    {
        float rng = Random.Range(beatMin, beatMax);
        currentTimer = rng;

        while (currentTimer > 0)
        {
            currentTimer -= Time.deltaTime;
            break;
        }
        
        OnBeat();
    }

    void OnBeat()
    {
        Debug.Log("onbeat");
        Pulse();
    }
}
