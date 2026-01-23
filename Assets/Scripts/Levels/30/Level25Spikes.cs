using UnityEngine;

public class Level25Spikes : MonoBehaviour
{
    float spikeVel = 3f;
    float counter = .75f;


    void Update()
    {
        SpikeManager();
        CounterManager();
    }

    void CounterManager()
    {
        counter -= Time.deltaTime;

        if (counter <= 0)
        {
            spikeVel = -spikeVel;
            counter = 1.5f;
        }
    }
    void SpikeManager()
    {
        Vector3 pos = transform.position;
        pos.x += spikeVel * Time.deltaTime;
        transform.position = pos;      
    }
}
