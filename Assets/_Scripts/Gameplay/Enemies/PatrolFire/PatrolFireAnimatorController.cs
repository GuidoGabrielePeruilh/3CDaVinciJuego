using UnityEngine;

namespace Game.Gameplay.Enemies.PatrolFire
{
    public class PatrolFireAnimatorController : MonoBehaviour
    {
        [SerializeField] Animator _animator;
        void ShootAnimation()
        {
            //TODO trigger shoot animation
            Debug.Log("Trigger shootAnimation");
        }
    }
}