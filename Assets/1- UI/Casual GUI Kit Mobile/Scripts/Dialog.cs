﻿using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace hardartcore.CasualGUI
{

    public class Dialog : MonoBehaviour
    {
        public float AnimDuration = 0.2f;
        public GameObject DialogContent;

        public void ShowDialog()
        {
            Time.timeScale = 1.0f;
            DialogContent.SetActive(false);
            gameObject.SetActive(true);
            DialogContent.transform.localScale = Vector3.zero;
            DialogContent.SetActive(true);
            DialogContent.transform.DOScale(Vector3.one, AnimDuration);
        }

        public void HideDialog()
        {
            Time.timeScale = 1.0f;
            DialogContent.transform.DOScale(Vector3.zero, AnimDuration);
            StartCoroutine(HideDialogAfterTime());
        }

        private IEnumerator HideDialogAfterTime()
        {
            yield return new WaitForSeconds(AnimDuration);
            gameObject.SetActive(false);
        }
    }
}
