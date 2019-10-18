using System;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotateTrigger : MonoBehaviour
{
    [SerializeField] private List<RotateTarget> rotateTargets = null;
    [SerializeField] private float rotateSpeed = 2f;
    [SerializeField] private float totalTime = 2f;

    [Serializable]
    private class RotateTarget
    {
        public Transform rotateTarget;
        public Vector3 rotateAmount;
        private Quaternion startRotation;

        public Quaternion GetStartRot()
        {
            return startRotation;
        }

        public void SetStartRot(Quaternion startRot)
        {
            this.startRotation = startRot;
        }
    }

    private bool startRotating = false;
    private float elapsedTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !startRotating)
        {
            startRotating = true;
            foreach(RotateTarget target in rotateTargets)
            {
                target.SetStartRot(target.rotateTarget.rotation);
            }
            elapsedTime = totalTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (startRotating)
        {
            foreach(RotateTarget target in rotateTargets)
            {
                target.rotateTarget.rotation = Quaternion.Slerp(target.rotateTarget.rotation, target.GetStartRot() * Quaternion.Euler(target.rotateAmount), Time.deltaTime * rotateSpeed);
            }
            elapsedTime -= Time.deltaTime;

            if(elapsedTime <= 0)
            {
                startRotating = false;
            }
        }
    }
}
