using SQLite4Unity3d;
using UnityEngine;
#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif
using System.Collections.Generic;

public class DataService  {

	private SQLiteConnection _connection;

	public DataService(string DatabaseName){

#if UNITY_EDITOR
            var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
#else
        // check if file exists in Application.persistentDataPath
        var filepath = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);

        if (!File.Exists(filepath))
        {
            Debug.Log("Database not in Persistent path");
            // if it doesn't ->
            // open StreamingAssets directory and load the db ->

#if UNITY_ANDROID 
            var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
            while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDb.bytes);
#elif UNITY_IOS
                 var loadDb = Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);
#elif UNITY_WP8
                var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);

#elif UNITY_WINRT
		var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
		
#elif UNITY_STANDALONE_OSX
		var loadDb = Application.dataPath + "/Resources/Data/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
#else
	var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
	// then save to Application.persistentDataPath
	File.Copy(loadDb, filepath);

#endif

            Debug.Log("Database written");
        }

        var dbPath = filepath;
#endif
            _connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        Debug.Log("Final PATH: " + dbPath);     

	}



	public Lokacija CreateLokacija()
    {
		var l = new Lokacija
		{
			Latitude = 1.1d,
			Longitude = 1.1d,
			Opis = "tekst"
		};
		_connection.Insert(l);
		return l;
    }
	public Lokacija CreateLokacija(double lat,double lng,string tekst)
    {
		var l = new Lokacija
		{
			Latitude = lat,
			Longitude = lng,
			Opis = tekst
		};
		_connection.Insert(l);
		return l;
    }
	public Lokacija CreateLokacija(int id,double lat,double lng,string tekst)
    {
		var l = new Lokacija
		{
			Id=id,
			Latitude = lat,
			Longitude = lng,
			Opis = tekst
		};
		_connection.Insert(l);
		return l;
    }
	public IEnumerable<Lokacija> GetLokacije()
	{
		return _connection.Table<Lokacija>();
	}

	public IEnumerable<Lokacija> GetLokacijaFromId(int id)
	{
		return _connection.Table<Lokacija>().Where(x => x.Id == id);
	}
	

	public void DeleteLokacijaWithId(int id)
	{
		var zaObrisati= _connection.Table<Lokacija>().Where(x => x.Id == id).FirstOrDefault();

        if (zaObrisati !=null)
        {
			_connection.Delete(zaObrisati);
			
        }
		/*
		var friend = db.Friends.Where(x => x.person.Id == user && x.Person1.Id == friend).FirstorDefault();
		if (friend != null)
		{
			db.friends.Remove(friend);
			db.SaveChanges()
		 }
		*/
	}

}
