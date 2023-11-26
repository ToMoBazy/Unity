using UnityEngine;

public class PlatformaWbijajaca : MonoBehaviour
{
    public float silaWbijajaca = 210f;

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszedł na windę.");
            CharacterController characterController = other.gameObject.GetComponent<CharacterController>();

            if (characterController != null)
            {
                // Dodawanie siły w kierunku pionowym do pozycji gracza
                characterController.Move(Vector3.up * silaWbijajaca * Time.deltaTime);
            }
        }
    }
}