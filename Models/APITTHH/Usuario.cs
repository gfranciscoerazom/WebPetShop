namespace WebPetShop.Models.APITTHH;

public class Usuario
{
    public string usuario { get; set; }
    public string password { get; set; }

    public string NOMBREUSUARIO { get; set; }
    public string PERFIL { get; set; }
    public string OBSERVACION { get; set; }
    public int CODIGOPERFIL { get; set; }
    public string ESTADO { get; set; }
    public int COMPANIA { get; set; }
    public int Emisor { get; set; }
    public int Cargo { get; set; }
    public string NOMBREEMISOR { get; set; }
    public string NOMBRECOMPANIA { get; set; }
    public string USUARIOCLIENTE { get; set; }
    public string RucUsuario { get; set; }

    public override string ToString()
    {
        return $"NOMBREUSUARIO: {NOMBREUSUARIO}, PERFIL: {PERFIL}, OBSERVACION: {OBSERVACION}, CODIGOPERFIL: {CODIGOPERFIL}, ESTADO: {ESTADO}, COMPANIA: {COMPANIA}, Emisor: {Emisor}, Cargo: {Cargo}, NOMBREEMISOR: {NOMBREEMISOR}, NOMBRECOMPANIA: {NOMBRECOMPANIA}, USUARIOCLIENTE: {USUARIOCLIENTE}, RucUsuario: {RucUsuario}";
    }
}
