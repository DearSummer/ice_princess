using UnityEngine;
using System.Collections;

namespace MagicalFX
{
	[RequireComponent (typeof(Rigidbody))]

public class FX_AddForceForward : MonoBehaviour
	{
	
		public float Force = 300;
		void Start ()
		{
			Rigidbody rig = GetComponent<Rigidbody>();
            Vector3 dir = (GameObject.Find("character").transform.position - this.transform.position).normalized;
			if (rig) {
				rig.AddForce (dir * Force);
			}
		}

		void Update ()
		{
		
		}
	}
}
