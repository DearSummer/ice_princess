using Cinemachine;
using UnityEngine;

namespace God_SCRIPT.Camera
{
    public class CameraTurn : MonoBehaviour
    {

        private CharacterInput _input;
        [Header("Ref")]
        public CinemachineFreeLook freeLookCamera;

        [Header("Attr")]
        public float minTurnSpeed;
        public float maxTurnSpeed;

        public float maxForwardSpeed;

        float forwardSpeed = 0f;

        private void Start()
        {
            _input = GetComponent<CharacterInput>();
        }


        public void FollowWithCamera()
        {

            Vector2 inputMove = new Vector2(_input.m_MovementForward, _input.m_MovementRight);
            Vector3 localMovementDir = new Vector3(inputMove.y, 0, inputMove.x).normalized;

            Vector3 cameraForward = Quaternion.Euler(0f, freeLookCamera.m_XAxis.Value, 0f) * Vector3.forward;
            cameraForward.y = 0;
            cameraForward.Normalize();

            Quaternion targetQuaternion;
            if (Mathf.Approximately(Vector3.Dot(localMovementDir, cameraForward), -1f))
            {
                targetQuaternion = Quaternion.LookRotation(-cameraForward);
            }
            else
            {
                Quaternion cameraToInputOffset = Quaternion.FromToRotation(Vector3.forward, localMovementDir);
                targetQuaternion = Quaternion.LookRotation(cameraToInputOffset * cameraForward);
            }

            // Vector3 targetRotation = targetQuaternion * Vector3.forward;

            float desireForwardSpeed = _input.InputMagic * maxForwardSpeed;
            forwardSpeed = Mathf.Lerp(forwardSpeed, desireForwardSpeed, 20f * Time.fixedDeltaTime);
            float turnSpeed = Mathf.Lerp(minTurnSpeed, maxTurnSpeed, forwardSpeed / desireForwardSpeed);

            targetQuaternion =
                Quaternion.RotateTowards(this.transform.rotation, targetQuaternion, turnSpeed * Time.fixedDeltaTime);
            this.transform.rotation = targetQuaternion;

            //        float dirX = Mathf.Abs(_input.m_MovementForward - 0) > 0.2f ? 1 : 0;
            //        float dirY = Mathf.Abs(_input.m_MovementRight - 0) > 0.2f ? 1 : 0;
            //        if (dirX != 0 || dirY != 0)
            //        {
            //            Vector3 todir = Vector3.zero;
            //            if (dirX != 0)
            //            {
            //                dirX = _input.m_MovementForward > 0 ? 0 : -1;
            //                todir = new Vector3(this.transform.rotation.x,
            //                    _followCamera.transform.rotation.eulerAngles.y + 180 * dirX, this.transform.rotation.z);
            //            }
            //
            //            if (dirY != 0)
            //            {
            //                dirY = _input.m_MovementRight > 0 ? 1 : -1;
            //                todir = new Vector3(this.transform.rotation.x,
            //                    _followCamera.transform.rotation.eulerAngles.y + 90 * dirY, this.transform.rotation.z);
            //            }
            //
            //            Quaternion todirQuateranion = Quaternion.Euler(todir);
            //            Quaternion c = Quaternion.Slerp(this.transform.rotation, todirQuateranion, Time.deltaTime * 5);
            //            this.transform.rotation = c;
            //        }
        }
    }
}
