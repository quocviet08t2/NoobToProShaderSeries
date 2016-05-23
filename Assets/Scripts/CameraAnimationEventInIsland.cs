////////////////////////////////////////////////////////////////////////////////
// Copyright (C) 2015 AsNet Co., Ltd.
// All Rights Reserved. These instructions, statements, computer
// programs, and/or related material (collectively, the "Source")
// contain unpublished information proprietary to AsNet Co., Ltd
// which is protected by US federal copyright law and by
// international treaties. This Source may NOT be disclosed to
// third parties, or be copied or duplicated, in whole or in
// part, without the written consent of AsNet Co., Ltd.
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

using Lilium.Environment;

public class CameraAnimationEventInIsland : MonoBehaviour
{

    private Animator _animtor;
    //private DayNightController _dayNightController;
    //private GameObject _buttons;

    public void Awake()
    {
        _animtor = GetComponent<Animator>();
        //_dayNightController = GameObject.FindObjectOfType<DayNightController>();        
        //_buttons = GameObject.FindObjectOfType<PanelMoveTo>().gameObject;

        // do not show buttons yet
        //_buttons.SetActive(false);
    }

    public void Start()
    {
        // active motion of buttons 
        //_buttons.SetActive(true);

        // disable camera animation 
        //_animtor.enabled = false;

        // enable day/night controller
        //_dayNightController.enabled = true;
        //_dayNightController.animator.enabled = true;
    }

    public void AnimEvOnFinishedIslandCutScene()
    {
        //// active motion of buttons 
        //_buttons.SetActive(true);

        // disable camera animation 
        _animtor.enabled = false;

        //// enable day/night controller
        //_dayNightController.enabled = true;
        //_dayNightController.animator.enabled = true;
    }
}
