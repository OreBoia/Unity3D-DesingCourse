using UnityEngine;

namespace DES.U1.Basics
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField] private Vector3 axes = new Vector3(0, 45f, 0);
        [SerializeField] private bool useUnscaledTime = false;

        void Update()
        {
            float dt = useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;
            transform.Rotate(axes * dt, Space.Self);
        }
    }
}
