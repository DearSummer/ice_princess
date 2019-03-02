using UnityEngine;
using System.Collections;

namespace MagicalFX
{
	public class FX_Camera : MonoBehaviour
	{

		private Vector3 positionTemp;
        public bool _enable = false;
		void Start ()
		{
			CameraEffect.CameraFX = this;
		}
	
		Vector3 forcePower;

		public void Shake (Vector3 power)
		{
			forcePower = -power;
		}

		void Update ()
		{
			if(_enable)
            {
                forcePower = Vector3.Lerp(forcePower, Vector3.zero, Time.deltaTime * 5);
                this.transform.position = this.transform.position+ new Vector3(Mathf.Cos(Time.time * 80) * forcePower.x, Mathf.Cos(Time.time * 80) * forcePower.y, Mathf.Cos(Time.time * 80) * forcePower.z);
            }
		}
        IEnumerator close()
        {
            yield return new WaitForSeconds(0.2f);
            _enable = false;
        }
	}

	public static class CameraEffect
	{
		public static FX_Camera CameraFX;
	
		public static void Shake (Vector3 power)
		{
			if (CameraFX != null)
            {
                CameraFX.Shake(power);
                CameraFX._enable = true; 

            }
		}
	}
}
