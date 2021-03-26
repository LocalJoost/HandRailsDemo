using MRTKExtensions.Gesture;
using MRTKExtensions.Utilities;
using UnityEngine;

namespace App.Scripts
{
    public class HandTrackingAnimator : HandRailsBase
    {
        [Header("Animation Settings")]
        [SerializeField] 
        private Animator animator;

        [SerializeField]
        private string animationName;

        [SerializeField] 
        private int animationLayer = 0;

        private static readonly int MotionTime = Animator.StringToHash("MotionTime");

        protected override void OnLocationUpdated()
        {
            var traveledLength = PointOnLine.DistanceTraveledAlongPath(WayPointLocations, CurrentIndex);
            var traveledFraction = traveledLength / TotalLength;

            if (!animator.GetCurrentAnimatorStateInfo(0).IsName(animationName))
            {
                animator.Play(animationName, animationLayer);
            }
            animator.SetFloat(MotionTime, traveledFraction);
        }
    }
}
