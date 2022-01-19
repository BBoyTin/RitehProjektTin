using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ARLocation.MapboxRoutes;
using System;


public class PutRouteFromDB : MonoBehaviour
{
    public GameObject mapboxRoute;

    public CustomRoute _customeRouteTin;

    public Text DebugText;

    private void Start()
    {
        //GetRouteData();

        StartRouteIfDBTrue();
    }

    private void StartRouteIfDBTrue()
    {

        var ds = new DataService("TinovaBazaLokacija.db");

        var lokacije = ds.GetLokacije();
        //ToConsole(lokacije);

        ToConsole(ds.GetLokacijaFromId(1));
        Lokacija odOvudaVadim=new Lokacija();
        foreach(Lokacija l in ds.GetLokacijaFromId(1))
        {
            odOvudaVadim = l;
        }

        foreach (Lokacija l in lokacije)
        {
            //ToConsole(l.Latitude.ToString() + " " + l.Longitude.ToString());
            
        }

        CustomRoute.Point[] points = _customeRouteTin.Points.ToArray();

        foreach (CustomRoute.Point point in points)
        {
            if (point.Name.Equals("end"))
            {
                point.Location.Latitude = odOvudaVadim.Latitude;
                point.Location.Longitude = odOvudaVadim.Longitude;
                point.Instruction = odOvudaVadim.Opis;

            }
            mapboxRoute.SetActive(true);
           // ToConsole(point.Name.ToString());

        }
    }

    public void GetRouteData()
    {
        ToConsole(_customeRouteTin.Points.ToString());
        ToConsole(_customeRouteTin.GetWaypoints().ToString());

        Waypoint[] waypoints = _customeRouteTin.GetWaypoints().ToArray();

        foreach(Waypoint point in waypoints)
        {
            ToConsole(point.ToString());
        }

        CustomRoute.Point[] points = _customeRouteTin.Points.ToArray();

        foreach (CustomRoute.Point point in points)
        {
            if (point.Name.Equals("start"))
            {
                point.Name = "promijenio ime starta";
            }
            ToConsole(point.Name.ToString());
            
        }
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
