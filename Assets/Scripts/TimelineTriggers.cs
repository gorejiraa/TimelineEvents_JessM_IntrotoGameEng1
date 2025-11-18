using UnityEngine;
using UnityEngine.Playables;

public class TimelineTrigger : MonoBehaviour
{
    public PlayableDirector timelineDirector;
    private bool hasTriggered = false;

    void Start()
    {
        // Ensure timeline is stopped at start
        if (timelineDirector != null)
        {
            timelineDirector.Stop();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player entered and hasn't triggered yet
        if (other.CompareTag("Player") && !hasTriggered)
        {
            if (timelineDirector != null)
            {
                timelineDirector.Play();
                hasTriggered = true;
                Debug.Log("Timeline triggered!");
            }
        }
    }

    // Optional: Reset trigger when player exits
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasTriggered = false;
        }
    }
}