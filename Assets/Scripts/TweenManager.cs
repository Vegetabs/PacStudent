using UnityEngine;

public class TweenManager : MonoBehaviour
{
    private Transform target;
    private Vector3 start;
    private Vector3 end;
    private float startTime;
    private float duration;
    private bool active = false;

    public void newTween(Transform target, Vector3 start, Vector3 end, float duration)
    {
        this.target = target;
        this.start = start;
        this.end = end;
        this.duration = duration;
        startTime = Time.time;
        active = true;
    }

    public bool getActive() { return active; }

    public void updateTween()
    {
        if (active)
        {
            float t = (Time.time-startTime)/duration;
            if (t >= 1f)
            {
                target.position = end;
                active = false;
            }
            else
            {
                target.position = Vector3.Lerp(start, end, t);
            } 
        }
    }
}
