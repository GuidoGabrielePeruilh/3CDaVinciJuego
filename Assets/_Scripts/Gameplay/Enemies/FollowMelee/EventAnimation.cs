using UnityEngine;

namespace Game.Gameplay.Enemies.FollowMelee
{
    public class EventAnimation : MonoBehaviour
    {

        [SerializeField] GameObject _damage;

        void Awake()
        {
            _damage.SetActive(false);
        }
        public void Event_StartAnimation()
        {
            _damage.SetActive(true); 
        }
        public void Event_EndAnimation()
        {
            _damage.SetActive(false);
        }
    }
}
