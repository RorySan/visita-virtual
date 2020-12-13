using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Interactable : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEvent onInteraction;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        image.color = Color.cyan;
    }

    public void CancelHighlight()
    {
        image.color = Color.cyan;
    }

    public void Highlight()
    {
        image.color = Color.red;
    }

    public void Interact(RaycastSelector instigator)
    {
        onInteraction.Invoke();
    }

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }
}
