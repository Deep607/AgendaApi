using AgendaAPI.Dto;
using AgendaAPI.Models;

namespace AgendaAPI.Services.Contato
{
    public interface IContatoInterface
    {
        Task<ResponseModel<List<ContatoModel>>> ListarContatos();
        Task<ResponseModel<ContatoModel>> BuscarContatoPorId(int idContato);
        Task<ResponseModel<List<ContatoModel>>> CriarContato(CriarContatoDto criarContatoDto);
        Task<ResponseModel<List<ContatoModel>>> EditarContato(EditarContatoDto editarContatoDto);
        Task<ResponseModel<List<ContatoModel>>> ExcluirContato(int idContato);
    }
}
