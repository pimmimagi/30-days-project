using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerPod : MonoBehaviour
{
    public int current_date = 15;
    public string current_day = "Sunday";
    public ReactiveProperty<string> StatusPlayerText = new ReactiveProperty<string>("ทำไรอยู่");



}