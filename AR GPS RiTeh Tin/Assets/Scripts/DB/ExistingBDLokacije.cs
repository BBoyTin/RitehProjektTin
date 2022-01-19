using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExistingBDLokacije : MonoBehaviour
{

	public Text DebugText;

	// Use this for initialization
	void Start()
	{
		var ds = new DataService("TinovaBazaLokacija.db");
		
		var lokacije = ds.GetLokacije();
		ToConsole(lokacije);
		/*
		
		lokacije = ds.GetLokacijaFromId(2);
		ToConsole("lokacija s id 2 ");
		ToConsole(lokacije);

		ds.CreateLokacija();
		ToConsole("New lokacija has been created");

		ds.CreateLokacija(2.453245, 4.32222, "ddd");

		ToConsole("New lokacija has been created with id=3");

		ds.CreateLokacija(3,3.333, 3.333333333, "nova s id 3");

		ds.DeleteLokacijaWithId(8);

		ToConsole(ds.GetLokacije());
		*/

	}

	private void ToConsole(IEnumerable<Lokacija> lokacije)
	{
		foreach (var l in lokacije)
		{
			ToConsole(l.ToString());
		}
	}

	private void ToConsole(string msg)
	{
		DebugText.text += System.Environment.NewLine + msg;
		Debug.Log(msg);
	}
		
}
