using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 40f; // Vitesse de déplacement
    public float rotationSpeed = 500f; // Vitesse de rotation

    void Update()
    {
        // Calcul du mouvement avant/arrière et latéral
        float moveForward = 0f;
        float moveSideways = 0f;

        if (Input.GetKey(KeyCode.UpArrow)) // Flèche haut pour avancer
        {
            moveForward += 1f;
        }
        if (Input.GetKey(KeyCode.DownArrow)) // Flèche bas pour reculer
        {
            moveForward -= 1f;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) // Flèche gauche pour bouger à gauche
        {
            moveSideways -= 1f;
        }
        if (Input.GetKey(KeyCode.RightArrow)) // Flèche droite pour bouger à droite
        {
            moveSideways += 1f;
        }

        // Normalisation du vecteur de déplacement
        Vector3 movement = new Vector3(moveSideways, 0, moveForward).normalized;
        transform.position += movement * speed * Time.deltaTime;

        // Rotation gauche/droite avec les touches "S" et "D"
        if (Input.GetKey(KeyCode.S)) // Touche "S" pour tourner à gauche
        {
            transform.Rotate(new Vector3(0, -rotationSpeed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.D)) // Touche "D" pour tourner à droite
        {
            transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
        }
    }
}