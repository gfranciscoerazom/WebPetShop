namespace WebPetShop.Models.APITTHH;

// {"COMP_Codigo":3,"Id_Trabajador":1,"Tipo_trabajador":"1","Apellido_Paterno":"ACHIG","Apellido_Materno":"TAPIA","Nombres":"ESTEFANIA ADRIANA","Identificacion":"1722663711   ","Entidad_Bancaria":"Banco Guayaquil","CarnetIESS":"NA","Direccion":"UYUMBICHO CALLE PASOCHOA LOTE 4 Y OCTAVIO ROCHA","Telefono_Fijo":"022331034","Telefono_Movil":"0990907984","Genero":"F","Nro_Cuenta_Bancaria":"34611144","Codigo_Categoria_Ocupacion":"9","Ocupacion":"1","Centro_Costos":"99999","Nivel_Salarial":"2","EstadoTrabajador":"*","Tipo_Contrato":"1","Tipo_Cese":"1","EstadoCivil":"2","TipodeComision":" ","FechaNacimiento":"1989-03-29T00:00:00","FechaIngreso":"2009-03-01T00:00:00","FechaCese":"2022-10-21T00:00:00","PeriododeVacaciones":0,"FechaReingreso":"1900-01-01T00:00:00","Fecha_Ult_Actualizacion":"1900-01-01T00:00:00","EsReingreso":"0","BancoCTA_CTE":null,"Tipo_Cuenta":"1","RSV_Indem_Acumul":0,"Año_Ult_Rsva_Indemni":0,"Mes_Ult_Rsva_Indemni":0,"FormaCalculo13ro":1,"FormaCalculo14ro":1,"BoniComplementaria":0,"BoniEspecial":0,"Remuneracion_Minima":550,"CuotaCuentaCorriente":0,"Fondo_Reserva":"M","Mensaje":null}
public class Trabajador
{
    public int COMP_Codigo { get; set; }
    public int Id_Trabajador { get; set; }
    public string Tipo_trabajador { get; set; }
    public string Apellido_Paterno { get; set; }
    public string Apellido_Materno { get; set; }
    public string Nombres { get; set; }
    public string Identificacion { get; set; }
    public string Entidad_Bancaria { get; set; }
    public string CarnetIESS { get; set; }
    public string Direccion { get; set; }
    public string Telefono_Fijo { get; set; }
    public string Telefono_Movil { get; set; }
    public string Genero { get; set; }
    public string Nro_Cuenta_Bancaria { get; set; }
    public string Codigo_Categoria_Ocupacion { get; set; }
    public string Ocupacion { get; set; }
    public string Centro_Costos { get; set; }
    public string Nivel_Salarial { get; set; }
    public string EstadoTrabajador { get; set; }
    public string Tipo_Contrato { get; set; }
    public string Tipo_Cese { get; set; }
    public string EstadoCivil { get; set; }
    public string TipodeComision { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public DateTime FechaIngreso { get; set; }
    public DateTime FechaCese { get; set; }
    public int PeriododeVacaciones { get; set; }
    public DateTime FechaReingreso { get; set; }
    ]public DateTime Fecha_Ult_Actualizacion { get; set; }
    public string EsReingreso { get; set; }
    public object BancoCTA_CTE { get; set; }
    public string Tipo_Cuenta { get; set; }
    public int RSV_Indem_Acumul { get; set; }
    public int Año_Ult_Rsva_Indemni { get; set; }
    public int Mes_Ult_Rsva_Indemni { get; set; }
    public int FormaCalculo13ro { get; set; }
    public int FormaCalculo14ro { get; set; }
    public int BoniComplementaria { get; set; }
    public int BoniEspecial { get; set; }
    public int Remuneracion_Minima { get; set; }
    public int CuotaCuentaCorriente { get; set; }
    public string Fondo_Reserva { get; set; }
    public object Mensaje { get; set; }
}
