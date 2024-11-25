using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class fadein : MonoBehaviour
{

    // Start is called before the first frame update
   
        private Animator animator;

        void Start()
        {
            animator = GetComponent<Animator>();
            PlayFadeIn();
        }

        public void PlayFadeIn()
        {
            animator.SetTrigger("fademenu");
        }
    }

