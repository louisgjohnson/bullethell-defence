﻿using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	public Transform camTransform;
	
	// How long the object should shake for.
	public float shakeDuration = 0f;
	
	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.05f;
	public float decreaseFactor = 1.0f;
	
	Vector3 originalPos;
	
	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}
	
	void OnEnable()
	{
		originalPos = camTransform.localPosition;
	}

	public void ExtraSmallShake() {
		if (shakeDuration == 0) {
        shakeDuration = 0.15f;
		}
        shakeAmount = 0.02f;
    }

    public void SmallShake() {
			if (shakeDuration == 0) {
				shakeAmount = 0.05f;
			}
        shakeDuration = 0.25f;
    }

    public void BigShake() {
        shakeDuration = 0.4f;
        shakeAmount = 0.08f;
    }

	public IEnumerator BumpCameraUpDown() {
		yield return new WaitForSeconds(0.4f);
	}

	void Update()
	{
		if (shakeDuration > 0)
		{
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			
			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shakeDuration = 0f;
			camTransform.localPosition = originalPos;
		}
	}
}
