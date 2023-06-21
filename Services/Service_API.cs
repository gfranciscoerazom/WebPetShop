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

		foreach (var Costos in costos)
		{
			Console.WriteLine(costos.ToString());
		}

		return costos;
	}

	public async Task<Costos> CostosInsertAsync(Costos costos)
	{
        var costosI = new Costos();

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(_baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

            var response = await httpClient.GetAsync($"api/Varios/CentroCostosInsert?codigocentrocostos={costos.Codigo}&descripcioncentrocostos={costos.NombreCentroCostos}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                costosI = JsonConvert.DeserializeObject<Costos>(json);
            }
        }

        return costosI;


        /*var costoI = false;

		using (HttpClient httpClient = new())
		{
			httpClient.BaseAddress = new Uri(_ApiTthhUrl);
			httpClient.DefaultRequestHeaders.Accept.Clear();
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

			var response = await httpClient.GetAsync($"api/Varios/CentroCostosInsert?codigocentrocostos={costos.codigoC}&descripcioncentrocostos={costos.nombreCosto}");

			if (response.IsSuccessStatusCode)
			{
				costoI = true;
			}
		}

        return costoI;*/
    }

	public async Task<Costos> CostosDeleteAsync(Costos costos)
	{
        var costosD = new Costos();

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(_baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

            var response = await httpClient.GetAsync($"api/Varios/CentroCostosDelete?codigocentrocostos={costos.Codigo}&descripcioncentrocostos={costos.NombreCentroCostos}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                costosD = JsonConvert.DeserializeObject<Costos>(json);
            }
        }

        return costosD;

        /*var costoD = false;

		using (HttpClient httpClient = new())
		{
			httpClient.BaseAddress = new Uri(_ApiTthhUrl);
			httpClient.DefaultRequestHeaders.Accept.Clear();
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

			var response = await httpClient.GetAsync($"api/Varios/CentroCostosDelete?codigocentrocostos={costos.codigoC}&descripcioncentrocostos={costos.nombreCosto}");

			if (response.IsSuccessStatusCode)
			{
                costoD = true;
			}
		}

		return costoD;*/
    }

	public async Task<Costos> CostosUpdateAsync(Costos costos)
	{
        var costosU = new Costos();

        using (var httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(_baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

            var response = await httpClient.GetAsync($"api/Varios/CentroCostosUpdate?codigocentrocostos={costos.Codigo}&descripcioncentrocostos={costos.NombreCentroCostos}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                costosU = JsonConvert.DeserializeObject<Costos>(json);
            }
        }

        return costosU;

        /*var costoU = false;

		using (HttpClient httpClient = new())
		{
			httpClient.BaseAddress = new Uri(_ApiTthhUrl);
			httpClient.DefaultRequestHeaders.Accept.Clear();
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));

			var response = await httpClient.GetAsync($"api/Varios/CentroCostosUpdate?codigocentrocostos={costos.codigoC}&descripcioncentrocostos={costos.nombreCosto}");

			if (response.IsSuccessStatusCode)
			{
                costoU = true;
			}
		}

		return costoU;*/
    }

}
