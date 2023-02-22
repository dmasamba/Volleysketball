using UnityEngine;

public class VolleyballController : MonoBehaviour
{
    [HideInInspector]
    public VolleyballEnvController envController;

    public GameObject purpleHoop;
    public GameObject blueHoop;
    Collider purpleHoopCollider;
    Collider blueHoopCollider;

    void Start()
    {
        envController = GetComponentInParent<VolleyballEnvController>();
        purpleHoopCollider = purpleHoop.GetComponent<Collider>();
        blueHoopCollider = blueHoop.GetComponent<Collider>();
    }

    /// <summary>
    /// Detects whether the ball lands in the blue, purple, or out of bounds area
    /// </summary>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("boundary"))
        {
            // ball went out of bounds
            envController.ResolveEvent(Event.HitOutOfBounds);
        }
        else if (other.gameObject.CompareTag("blueBoundary"))
        {
            // ball hit into blue side
            envController.ResolveEvent(Event.HitIntoBlueArea);
        }
        else if (other.gameObject.CompareTag("purpleBoundary"))
        {
            // ball hit into purple side
            envController.ResolveEvent(Event.HitIntoPurpleArea);
        }
        else if (other.gameObject.CompareTag("purpleHoop"))
        {
            // ball hit purple Hoop (blue side court)
            envController.ResolveEvent(Event.HitPurpleHoop);
        }
        else if (other.gameObject.CompareTag("blueHoop"))
        {
            // ball hit blue Hoop (purple side court)
            envController.ResolveEvent(Event.HitBlueHoop);
        }

    }

}