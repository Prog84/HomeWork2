using UnityEngine;

public class CubeMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _finalMovementPoint;

    private bool iSTransporter = false;

    private void Update()
    {
        if (iSTransporter)
        {
            Move(_finalMovementPoint);
        }        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Transporter transporter))
        {
            iSTransporter = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Transporter transporter))
        {
            iSTransporter = false;
        }
    }

    private void Move(Transform finalMovementPoint)
    {
        transform.position = Vector3.Lerp(transform.position, finalMovementPoint.position, _speed * Time.deltaTime);
    }
}
