using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShakeCamera : MonoBehaviour
{
    public static ShakeCamera instance;
    [SerializeField] private CinemachineImpulseSource _impulseSource;
    private void Awake() => instance = this;
    public void Shake() => _impulseSource.GenerateImpulse();
}
