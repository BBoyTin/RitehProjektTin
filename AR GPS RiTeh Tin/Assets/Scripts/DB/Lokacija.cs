using SQLite4Unity3d;
public class Lokacija
{
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public double Latitude { get; set; }
	public double Longitude { get; set; }
	public string Opis { get; set; }

	public override string ToString()
	{
		return string.Format("[Lokacija: Id={0}, Latitude={1},  Longitude={2}, Opis={3}]", Id, Latitude, Longitude, Opis);
	}
}
