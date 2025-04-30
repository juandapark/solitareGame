using Core.Managers;
using Gameplay.Moves;
using Gameplay.StackZone;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public abstract class CardBase : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    protected SpriteRenderer spriteRenderer;
    private StackZone CurrentStack;
    private Vector3 offset;         
    private bool isDragging;
    private int origSorting;
    
    protected abstract void SetCardType();


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetCardType();
    }
    
   private void OnMouseDown()
    {
        isDragging = true;
        origSorting = spriteRenderer.sortingOrder;
        spriteRenderer.sortingOrder = 100;              
        offset = transform.position - ScreenToWorld(Input.mousePosition);
    }

    private void OnMouseDrag()
    {
        if (!isDragging) return;

        Vector3 target = ScreenToWorld(Input.mousePosition) + offset;
        transform.position = target;
    }

    private void OnMouseUp()
    {
        if (!isDragging) return;
        isDragging = false;

        spriteRenderer.sortingOrder = origSorting;

        Collider2D hit = Physics2D.OverlapPoint(ScreenToWorld(Input.mousePosition),layerMask);

        if (hit && hit.TryGetComponent(out StackZone zone))
        {
            var cmd = new MoveCommand(GetComponent<CardBase>(),
                CurrentStack,
                zone);
            
            GameManager.Instance.Execute(cmd);
        }
        else
        {
            Vector3 position = new Vector3(CurrentStack.transform.position.x, CurrentStack.transform.position.y, -1);

            transform.position = position;
        }
    }

    private Vector3 ScreenToWorld(Vector3 screenPos)
    {
        return Camera.main.ScreenToWorldPoint(
            new Vector3(screenPos.x,
                screenPos.y,
                Camera.main.nearClipPlane));
    }

    public void SetCardStack(StackZone stack)
    {
        CurrentStack = stack;
    }
}