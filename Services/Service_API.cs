using WebPetShop.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using WebPetShop.Models.APITTHH;

namespace WebPetShop.Services;

public class Service_API : IService_API
{
    private static string _baseUrl;
    private static string _ApiTthhUrl;

    public Service_API()
    {
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        _ApiTthhUrl = builder.GetSection("ApiSettings:ApiTthhUrl").Value;
    }

    public async Task<List<Producto>> GetProductosAsync()
    {
        var productos = new List<Producto>();

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(_baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync("api/Productos");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                productos = JsonConvert.DeserializeObject<List<Producto>>(json);
            }
        }
        
        return productos;
    }

    public async Task<Producto> GetProductoAsync(int id)
    {
        var producto = new Producto();

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(_baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync($"api/Productos/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                producto = JsonConvert.DeserializeObject<Producto>(json);
            }
        }

        return producto;
    }

    public async Task<bool> AddProductoAsync(Producto producto)
    {
        bool success = false;

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(_baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var json = JsonConvert.SerializeObject(producto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/Productos", content);

            if (response.IsSuccessStatusCode)
            {
                success = true;
            }
        }

        return success;
    }

    public async Task<bool> UpdateProductoAsync(Producto producto)
    {
        var success = false;

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(_baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var json = JsonConvert.SerializeObject(producto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"api/Productos/{producto.ProductoId}", content);

            if (response.IsSuccessStatusCode)
            {
                success = true;
            }
        }

        return success;
    }

    public async Task<bool> DeleteProductoAsync(int id)
    {
        var success = false;

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(_baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.DeleteAsync($"api/Productos/{id}");

            if (response.IsSuccessStatusCode)
            {
                success = true;
            }
        }

        return success;
    }

    
    public async Task<List<Cliente>> GetClientesAsync()
    {
        var clientes = new List<Cliente>();

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(_baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync("api/Clientes");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                clientes = JsonConvert.DeserializeObject<List<Cliente>>(json);
            }
        }

        return clientes;
    }

    public async Task<Cliente> GetClienteAsync(int id)
    {
        var cliente = new Cliente();

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(_baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync($"api/Clientes/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                cliente = JsonConvert.DeserializeObject<Cliente>(json);
            }
        }

        return cliente;
    }

    public async Task<bool> AddClienteAsync(Cliente cliente)
    {
        var success = false;

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(_baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var json = JsonConvert.SerializeObject(cliente);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/Clientes", content);

            if (response.IsSuccessStatusCode)
            {
                success = true;
            }
        }

        return success;
    }

    public async Task<bool> UpdateClienteAsync(Cliente cliente)
    {
        var success = false;

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(_baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var json = JsonConvert.SerializeObject(cliente);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"api/Clientes/{cliente.ClienteId}", content);

            if (response.IsSuccessStatusCode)
            {
                success = true;
            }
        }

        return success;
    }

    public async Task<bool> DeleteClienteAsync(int id)
    {
        var success = false;

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(_baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.DeleteAsync($"api/Clientes/{id}");

            if (response.IsSuccessStatusCode)
            {
                success = true;
            }
        }

        return success;
    }

    
    public async Task<Usuario[]> GetUsuarioOutputsAsync(Usuario usuario)
    {
        var usuarioOutputs = Array.Empty<Usuario>();

        using (HttpClient httpClient = new())
        {
            httpClient.BaseAddress = new Uri(_ApiTthhUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

            var response = await httpClient.GetAsync($"api/Usuarios/?usuario={usuario.usuario}&password={usuario.password}");

            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                usuarioOutputs = JsonConvert.DeserializeObject<Usuario[]>(jsonResult);
            }
        }

        return usuarioOutputs;
    }

    public async Task<Emisor[]> GetEmisoresAsync()
    {
        var emisores = Array.Empty<Emisor>();

        using (HttpClient httpClient = new())
        {
            httpClient.BaseAddress = new Uri(_ApiTthhUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

            var response = await httpClient.GetAsync("api/Varios/GetEmisor");

            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                emisores = JsonConvert.DeserializeObject<Emisor[]>(jsonResult);
            }
        }

        foreach (var emisor in emisores)
        {
            Console.WriteLine(emisor.ToString());
        }

        return emisores;
    }



	public async Task<Costos[]> CostosSelectAsync()
	{
		var costos= Array.Empty<Costos>();

		using (HttpClient httpClient = new())
		{
			httpClient.BaseAddress = new Uri(_ApiTthhUrl);
			httpClient.DefaultRequestHeaders.Accept.Clear();
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

			var response = await httpClient.GetAsync("api/Varios/CentroCostosSelect");

			if (response.IsSuccessStatusCode)
			{
				var jsonResult = await response.Content.ReadAsStringAsync();
				costos = JsonConvert.DeserializeObject<Costos[]>(jsonResult);
			}
		}

		foreach (var costo in costos)
		{
			Console.WriteLine(costo.ToString());
		}

		return costos;
	}

	public async Task<Costos[]> CostosInsertAsync(Costos costo)
	{
        var costos = Array.Empty<Costos>();

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(_ApiTthhUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

            var response = await httpClient.GetAsync($"api/Varios/CentroCostosInsert?codigocentrocostos={costo.Codigo}&descripcioncentrocostos={costo.NombreCentroCostos}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                costos = JsonConvert.DeserializeObject<Costos[]>(json);
            }
        }

        return costos;
    }

	public async Task<Costos[]> CostosDeleteAsync(Costos costo)
	{
        var costos = Array.Empty<Costos>();

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(_ApiTthhUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

            var response = await httpClient.GetAsync($"api/Varios/CentroCostosDelete?codigocentrocostos={costo.Codigo}&descripcioncentrocostos={costo.NombreCentroCostos}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                costos = JsonConvert.DeserializeObject<Costos[]>(json);
            }
        }

        return costos;
    }

	public async Task<Costos[]> CostosUpdateAsync(Costos costo)
	{
        var costos = Array.Empty<Costos>();

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(_ApiTthhUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

            var response = await httpClient.GetAsync($"api/Varios/CentroCostosUpdate?codigocentrocostos={costo.Codigo}&descripcioncentrocostos={costo.NombreCentroCostos}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                costos = JsonConvert.DeserializeObject<Costos[]>(json);
            }
        }

        return costos;
    }

    public async Task<Costos[]> CostosSearchAsync(string descripcioncentrocostos)
    {
        var costos = Array.Empty<Costos>();

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(_ApiTthhUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

            var response = await httpClient.GetAsync($"api/Varios/CentroCostosSearch?descripcioncentrocostos={descripcioncentrocostos}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                costos = JsonConvert.DeserializeObject<Costos[]>(json);
            }
        }

        return costos;
    }


    public async Task<MovimientoPlanilla[]> MovimientoPlanillaSelectAsync()
    {
        var movimientos = Array.Empty<MovimientoPlanilla>();

        using (HttpClient httpClient = new())
        {
            httpClient.BaseAddress = new Uri(_ApiTthhUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

            var response = await httpClient.GetAsync("api/Varios/MovimientoPlanillaSelect");

            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                movimientos = JsonConvert.DeserializeObject<MovimientoPlanilla[]>(jsonResult);
            }
        }

        return movimientos;
    }


    public async Task<MovimientoPlanilla> MovimientoPlanillaInsertAsync(MovimientoPlanilla movimientoPlanilla)
    {
        var movimientos = Array.Empty<MovimientoPlanilla>();

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(_ApiTthhUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

            var response = await httpClient.GetAsync($"api/Varios/MovimientoPlanillaInsert?conceptos={movimientoPlanilla.CodigoConcepto}&prioridad={movimientoPlanilla.Prioridad}&tipooperacion={movimientoPlanilla.TipoOperacion}&cuenta1={movimientoPlanilla.Cuenta1}&cuenta2={movimientoPlanilla.Cuenta2}&cuenta3={movimientoPlanilla.Cuenta3}&cuenta4={movimientoPlanilla.Cuenta4}&MovimientoExcepcion1={movimientoPlanilla.MovimientoExcepcion1}&MovimientoExcepcion2={movimientoPlanilla.MovimientoExcepcion2}&MovimientoExcepcion3={movimientoPlanilla.MovimientoExcepcion3}&Traba_Aplica_iess={movimientoPlanilla.Aplica_iess}&Traba_Proyecto_imp_renta={movimientoPlanilla.Aplica_imp_renta}&Aplica_Proy_Renta={movimientoPlanilla.Empresa_Afecta_Iess}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                movimientos = JsonConvert.DeserializeObject<MovimientoPlanilla[]>(json);
            }
        }

        return movimientos.FirstOrDefault();
    }

    public async Task<MovimientoPlanilla> MovimientoPlanillaUpdateAsync(MovimientoPlanilla movimientoPlanilla)
    {
        var movimientos = Array.Empty<MovimientoPlanilla>();

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(_ApiTthhUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

            var response = await httpClient.GetAsync($"api/Varios/MovimientoPlanillaUpdate?conceptos={movimientoPlanilla.CodigoConcepto}&prioridad={movimientoPlanilla.Prioridad}&tipooperacion={movimientoPlanilla.TipoOperacion}&cuenta1={movimientoPlanilla.Cuenta1}&cuenta2={movimientoPlanilla.Cuenta2}&cuenta3={movimientoPlanilla.Cuenta3}&cuenta4={movimientoPlanilla.Cuenta4}&MovimientoExcepcion1={movimientoPlanilla.MovimientoExcepcion1}&MovimientoExcepcion2={movimientoPlanilla.MovimientoExcepcion2}&MovimientoExcepcion3={movimientoPlanilla.MovimientoExcepcion3}&Traba_Aplica_iess={movimientoPlanilla.Aplica_iess}&Traba_Proyecto_imp_renta={movimientoPlanilla.Aplica_imp_renta}&Aplica_Proy_Renta={movimientoPlanilla.Empresa_Afecta_Iess}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                movimientos = JsonConvert.DeserializeObject<MovimientoPlanilla[]>(json);
            }
        }

        return movimientos.FirstOrDefault();
    }

    public async Task<MovimientoPlanilla> MovimientoPlanillaDeleteAsync(int codigoConcepto, string concepto)
    {
        var movimientos = Array.Empty<MovimientoPlanilla>();

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(_ApiTthhUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

            var response = await httpClient.GetAsync($"api/Varios/MovimeintoPlanillaDelete?codigomovimiento={codigoConcepto}&descripcionomovimiento={concepto}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                movimientos = JsonConvert.DeserializeObject<MovimientoPlanilla[]>(json);
            }
        }

        return movimientos.FirstOrDefault();
    }

    public async Task<MovimientoPlanilla[]> MovimientoPlanillaSearchAsync(string concepto)
    {
        var movimientos = Array.Empty<MovimientoPlanilla>();

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(_ApiTthhUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

            var response = await httpClient.GetAsync($"api/Varios/MovimientoPlanillaSearch?Concepto={concepto}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                movimientos = JsonConvert.DeserializeObject<MovimientoPlanilla[]>(json);
            }
        }

        return movimientos;
    }


    public async Task<TipoOperacion[]> TipoOperacionSelectAsync()
    {
        var tipoOperaciones = Array.Empty<TipoOperacion>();

        using (HttpClient httpClient = new())
        {
            httpClient.BaseAddress = new Uri(_ApiTthhUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

            var response = await httpClient.GetAsync("api/Varios/TipoOperacion");

            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                tipoOperaciones = JsonConvert.DeserializeObject<TipoOperacion[]>(jsonResult);
            }
        }

        return tipoOperaciones;
    }


    public async Task<MovimientosExcepcion[]> MovimientosExcepcion1y2Async()
    {
        var movimientosExcepcion = Array.Empty<MovimientosExcepcion>();

        using (HttpClient httpClient = new())
        {
            httpClient.BaseAddress = new Uri(_ApiTthhUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

            var response = await httpClient.GetAsync("api/Varios/MovimientosExcepcion1y2");

            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                movimientosExcepcion = JsonConvert.DeserializeObject<MovimientosExcepcion[]>(jsonResult);
            }
        }

        return movimientosExcepcion;
    }

    public async Task<MovimientosExcepcion[]> MovimientosExcepcion3Async()
    {
        var movimientosExcepcion = Array.Empty<MovimientosExcepcion>();

        using (HttpClient httpClient = new())
        {
            httpClient.BaseAddress = new Uri(_ApiTthhUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

            var response = await httpClient.GetAsync("api/Varios/MovimientosExcepcion3");

            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                movimientosExcepcion = JsonConvert.DeserializeObject<MovimientosExcepcion[]>(jsonResult);
            }
        }

        return movimientosExcepcion;
    }

    public async Task<MovimientosExcepcion[]> TrabaAfectaIESSSelectAsync()
    {
        var trabaAfectaIESS = Array.Empty<MovimientosExcepcion>();

        using (HttpClient httpClient = new())
        {
            httpClient.BaseAddress = new Uri(_ApiTthhUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

            var response = await httpClient.GetAsync("api/Varios/TrabaAfectaIESS");

            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                trabaAfectaIESS = JsonConvert.DeserializeObject<MovimientosExcepcion[]>(jsonResult);
            }
        }

        return trabaAfectaIESS;
    }

    public async Task<MovimientosExcepcion[]> TrabAfecImpuestoRentaSelectAsync()
    {
        var trabAfecImpuestoRenta = Array.Empty<MovimientosExcepcion>();

        using (HttpClient httpClient = new())
        {
            httpClient.BaseAddress = new Uri(_ApiTthhUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

            var response = await httpClient.GetAsync("api/Varios/TrabAfecImpuestoRenta");

            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                trabAfecImpuestoRenta = JsonConvert.DeserializeObject<MovimientosExcepcion[]>(jsonResult);
            }
        }

        return trabAfecImpuestoRenta;
    }

    public async Task<Usuario> GetAutorizadorAsync(Usuario usuario)
    {
        var usuarios = Array.Empty<Usuario>();

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(_ApiTthhUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

            var response = await httpClient.GetAsync($"api/Varios/GetAutorizador?usuario={usuario.NombreUsuario}&clave={usuario.Clave}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                usuarios = JsonConvert.DeserializeObject<Usuario[]>(json);
            }
        }

        return usuarios.FirstOrDefault();
    }

    // http://apiservicios.ecuasolmovsa.com:3009/api/Varios/TrabajadorSelect?sucursal=3

    public async Task<Trabajador[]> TrabajadorSelectAsync(int sucursal)
    {
        var trabajadores = Array.Empty<Trabajador>();

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(_ApiTthhUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

            var response = await httpClient.GetAsync($"api/Varios/TrabajadorSelect?sucursal={sucursal}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                trabajadores = JsonConvert.DeserializeObject<Trabajador[]>(json);
            }
        }

        return trabajadores;
    }

    public async Task<Trabajador> TrabajadorInsertAsync(Trabajador trabajador)
    {
        var trabajadores = Array.Empty<Trabajador>();

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(_ApiTthhUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

            var response = await httpClient.GetAsync($"api/Varios/TrabajadorInsert?COMP_Codigo={trabajador.COMP_Codigo}&Tipo_trabajador={trabajador.Tipo_trabajador}&Apellido_Paterno={trabajador.Apellido_Paterno}&Apellido_Materno={trabajador.Apellido_Materno}&Nombres={trabajador.Nombres}&Identificacion={trabajador.Identificacion}&Entidad_Bancaria={trabajador.Entidad_Bancaria}&CarnetIESS={trabajador.CarnetIESS}&Direccion={trabajador.Direccion}&Telefono_Fijo={trabajador.Telefono_Fijo}&Telefono_Movil={trabajador.Telefono_Movil}&Genero={trabajador.Genero}&Nro_Cuenta_Bancaria={trabajador.Nro_Cuenta_Bancaria}&Codigo_Categoria_Ocupacion={trabajador.Codigo_Categoria_Ocupacion}&Ocupacion={trabajador.Ocupacion}&Centro_Costos={trabajador.Centro_Costos}&Nivel_Salarial={trabajador.Nivel_Salarial}&EstadoTrabajador={trabajador.EstadoTrabajador}&Tipo_Contrato={trabajador.Tipo_Contrato}&Tipo_Cese={trabajador.Tipo_Cese}&EstadoCivil={trabajador.EstadoCivil}&TipodeComision={trabajador.TipodeComision}&FechaNacimiento={trabajador.FechaNacimiento}&FechaIngreso={trabajador.FechaIngreso}&FechaCese={trabajador.FechaCese}&PeriododeVacaciones={trabajador.PeriododeVacaciones}&FechaReingreso={trabajador.FechaReingreso}&Fecha_Ult_Actualizacion={trabajador.Fecha_Ult_Actualizacion}&EsReingreso={trabajador.EsReingreso}&Tipo_Cuenta={trabajador.Tipo_Cuenta}&FormaCalculo13ro={trabajador.FormaCalculo13ro}&FormaCalculo14ro={trabajador.FormaCalculo14ro}&BoniComplementaria={trabajador.BoniComplementaria}&BoniEspecial={trabajador.BoniEspecial}&Remuneracion_Minima={trabajador.Remuneracion_Minima}&Fondo_Reserva={trabajador.Fondo_Reserva}&Mensaje={trabajador.Mensaje}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                trabajadores = JsonConvert.DeserializeObject<Trabajador[]>(json);
            }
        }

        return trabajadores.FirstOrDefault();
    }

}