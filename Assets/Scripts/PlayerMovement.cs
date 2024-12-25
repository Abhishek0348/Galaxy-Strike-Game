using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f; 
    private Vector2 Movement;

    void Update()
    {
        PlayerTranslation();
    }

    public void OnMove(InputValue value)
    {
        Movement = value.Get<Vector2>();
    }

    private void PlayerTranslation()
    {
        float xOffset = Movement.x * controlSpeed * Time.deltaTime;
        float yOffset = Movement.y * controlSpeed * Time.deltaTime;
        transform.localPosition = new Vector3(transform.localPosition.x + xOffset, transform.localPosition.y + yOffset, 0f);
    }
}
