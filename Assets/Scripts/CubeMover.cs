using UnityEngine;

public class CubeMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _finalMovementPoint;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Transporter transporter))
        {
            Move(_finalMovementPoint);
        }
    }

    private void Move(Transform finalMovementPoint)
    {
        transform.position = Vector3.Lerp(transform.position, finalMovementPoint.position, _speed * Time.deltaTime);
    }
}
