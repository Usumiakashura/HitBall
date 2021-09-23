using UnityEngine.EventSystems;
using UnityEngine;

public class Swipe : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    [SerializeField] private GameObject ball = null;
    
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if ((Mathf.Abs(eventData.delta.x)) < (Mathf.Abs(eventData.delta.y)) &&
            eventData.delta.y > 0)
        {
            ball.GetComponent<BallController>().Hit();
        }
    }

    public void OnDrag(PointerEventData eventData) { }

}
