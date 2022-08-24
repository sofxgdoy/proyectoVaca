using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveMovimiento : MonoBehaviour
{
   
   private SwerveInputController _swerveInputController; // arrancamos referenciando el input
   [SerializeField] private float swerveVelocidad = 0.5f;
   private void Awake() 
   {
    _swerveInputController = GetComponent<SwerveInputController>(); //lo pedimos
   }
   
   private void Update()
   {
    float swerveAmount  = Time.deltaTime * swerveVelocidad * _swerveInputController.MovX;
    transform.Translate(swerveAmount, 0, 0);
   }
}
