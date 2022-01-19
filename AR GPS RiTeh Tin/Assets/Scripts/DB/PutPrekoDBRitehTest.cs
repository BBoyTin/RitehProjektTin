using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ARLocation.MapboxRoutes;
using System;


public class PutPrekoDBRitehTest : MonoBehaviour
{
    public GameObject mapboxRoute;

    public CustomRoute _customeRouteTin;

    public Text DebugText;

    private void Start()
    {

        StartRouteIfDBTrue();
    }

    private void StartRouteIfDBTrue()
    {

        var ds = new DataService("TinovaBazaLokacijaRiteh.db");

        var lokacije = ds.GetLokacije();
        ToConsole(lokacije);

        SetRouteByIdFromDB(ds,1);
        SetRouteByIdFromDB(ds,2);
        SetRouteByIdFromDB(ds,3);

        
        mapboxRoute.SetActive(true);

    }

    void SetRouteByIdFromDB(DataService ds,int idKojiDajemo)
    {
        Lokacija odOvudaVadim = new Lokacija();
        foreach (Lokacija l in ds.GetLokacijaFromId(idKojiDajemo))
        {
            odOvudaVadim = l;
        }

       

        CustomRoute.Point[] points = _customeRouteTin.Points.ToArray();

        if (idKojiDajemo > points.Length)
            return;

        points[idKojiDajemo-1].Location.Latitude = odOvudaVadim.Latitude;
        points[idKojiDajemo - 1].Location.Longitude = odOvudaVadim.Longitude;
        points[idKojiDajemo - 1].Instruction = odOvudaVadim.Opis;

        ToConsole("point " + (idKojiDajemo - 1)+" is filled by DB");

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
