namespace WebPetShop.Models.APITTHH;

public class Costos
{
	public int Codigo { get; set; }
	public string NombreCentroCostos { get; set; }
	public string Mensaje { get; set; }

	public override string ToString()
	{
		return $"codigoC: {Codigo}, nombrecosto: {NombreCentroCostos}, mensaje: {Mensaje}";
	}

}
