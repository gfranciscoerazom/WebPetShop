namespace WebPetShop.Models.APITTHH;

public class Emisor
{
    public int Codigo { get; set; }
    public string NombreEmisor { get; set; }
    public string Ruc { get; set; }

    public override string ToString()
    {
        return $"Codigo: {Codigo}, NombreEmisor: {NombreEmisor}, Ruc: {Ruc}";
    }
}
