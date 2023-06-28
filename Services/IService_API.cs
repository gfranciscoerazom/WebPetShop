using WebPetShop.Models;
using WebPetShop.Models.APITTHH;

namespace WebPetShop.Services
{
    public interface IService_API
    {
        Task<List<Producto>> GetProductosAsync();
        Task<Producto> GetProductoAsync(int id);
        Task<bool> AddProductoAsync(Producto producto);
        Task<bool> UpdateProductoAsync(Producto producto);
        Task<bool> DeleteProductoAsync(int id);

        Task<List<Cliente>> GetClientesAsync();
        Task<Cliente> GetClienteAsync(int id);
        Task<bool> AddClienteAsync(Cliente cliente);
        Task<bool> UpdateClienteAsync(Cliente cliente);
        Task<bool> DeleteClienteAsync(int id);

        Task<Usuario[]> GetUsuarioOutputsAsync(Usuario usuario);
        Task<Emisor[]> GetEmisoresAsync();

        Task<Costos[]> CostosSelectAsync();
        Task<Costos[]> CostosInsertAsync(Costos costos);
        Task<Costos[]> CostosDeleteAsync(Costos costos);
        Task<Costos[]> CostosUpdateAsync(Costos costos);
        Task<Costos[]> CostosSearchAsync(string descripcioncentrocostos);

        Task<MovimientoPlanilla[]> MovimientoPlanillaSelectAsync();
        Task<MovimientoPlanilla> MovimientoPlanillaInsertAsync(MovimientoPlanilla movimientoPlanilla);
        Task<MovimientoPlanilla> MovimientoPlanillaUpdateAsync(MovimientoPlanilla movimientoPlanilla);
        Task<MovimientoPlanilla> MovimientoPlanillaDeleteAsync(int codigoConcepto, string concepto);
        Task<MovimientoPlanilla[]> MovimientoPlanillaSearchAsync(string concepto);

        Task<TipoOperacion[]> TipoOperacionSelectAsync();

        Task<MovimientosExcepcion[]> MovimientosExcepcion1y2Async();
        Task<MovimientosExcepcion[]> MovimientosExcepcion3Async();

        Task<MovimientosExcepcion[]> TrabaAfectaIESSSelectAsync();

        Task<MovimientosExcepcion[]> TrabAfecImpuestoRentaSelectAsync();

        Task<Usuario> GetAutorizadorAsync(Usuario usuario);

        Task<Trabajador[]> TrabajadorSelectAsync(int sucursal);
        Task<Trabajador> TrabajadorInsertAsync(Trabajador trabajador);
    }
}
