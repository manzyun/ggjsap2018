using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanGender : MonoBehaviour {
    public Gender gender { get; private set; }
	public void SetGender(Gender gender)
    {
        this.gender = gender;
    }
}

public enum Gender
{
    male,
    female
}
