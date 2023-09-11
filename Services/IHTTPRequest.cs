namespace ProyectGarantia.Services
{
    public interface IHTTPRequest
    {
        //string ObtenerMensajeAsync();
        Task<string> ObtenerMensajeAsync();
    }
}
