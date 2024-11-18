using AgendaAPI.Data;
using AgendaAPI.Dto;
using AgendaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaAPI.Services.Contato
{
    public class ContatoService : IContatoInterface
    {
        private readonly AppDbContext _context;

        public ContatoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<ContatoModel>>> ListarContatos()
        {
            var resposta = new ResponseModel<List<ContatoModel>>();

            try
            {
                var contatos = await _context.Contatos.ToListAsync();
                resposta.Dados = contatos;
                resposta.Mensagem = "Todos os contatos foram encontrados!";
                resposta.Status = true;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = $"Erro: {ex.Message}";
                resposta.Status = false;
            }

            return resposta;
        }

        public async Task<ResponseModel<ContatoModel>> BuscarContatoPorId(int idContato)
        {
            var resposta = new ResponseModel<ContatoModel>();

            try
            {
                var contato = await _context.Contatos.FirstOrDefaultAsync(c => c.Id == idContato);

                if (contato == null)
                {
                    resposta.Mensagem = "Nenhum Registro no Banco de Dados!";
                    resposta.Status = false;
                }
                else
                {
                    resposta.Dados = contato;
                    resposta.Mensagem = "Contato Encontrado!";
                    resposta.Status = true;
                }
            }
            catch (Exception ex)
            {
                resposta.Mensagem = $"Erro: {ex.Message}";
                resposta.Status = false;
            }

            return resposta;
        }

        public async Task<ResponseModel<List<ContatoModel>>> CriarContato(CriarContatoDto criarContatoDto)
        {
            var resposta = new ResponseModel<List<ContatoModel>>();

            try
            {
                // Verificar se o email já existe
                bool emailExists = await _context.Contatos.AnyAsync(c => c.Email == criarContatoDto.Email);
                if (emailExists)
                {
                    resposta.Mensagem = "O email já está em uso.";
                    resposta.Status = false;
                    return resposta;
                }

                var contato = new ContatoModel
                {
                    Nome = criarContatoDto.Nome,
                    Email = criarContatoDto.Email,
                    Telefone = criarContatoDto.Telefone
                };

                _context.Contatos.Add(contato);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Contatos.ToListAsync();
                resposta.Mensagem = "Contato Criado Com Sucesso!";
                resposta.Status = true;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = $"Erro: {ex.Message}";
                resposta.Status = false;
            }

            return resposta;
        }

        public async Task<ResponseModel<List<ContatoModel>>> EditarContato(EditarContatoDto editarContatoDto)
        {
            var resposta = new ResponseModel<List<ContatoModel>>();

            try
            {
                var contato = await _context.Contatos.FirstOrDefaultAsync(c => c.Id == editarContatoDto.Id);

                if (contato == null)
                {
                    resposta.Mensagem = "Nenhum Contato Encontrado!";
                    resposta.Status = false;
                    return resposta;
                }

                // Verificar se o email já está em uso por outro contato
                bool emailExists = await _context.Contatos.AnyAsync(c => c.Email == editarContatoDto.Email && c.Id != editarContatoDto.Id);
                if (emailExists)
                {
                    resposta.Mensagem = "O email já está em uso.";
                    resposta.Status = false;
                    return resposta;
                }

                contato.Nome = editarContatoDto.Nome;
                contato.Email = editarContatoDto.Email;
                contato.Telefone = editarContatoDto.Telefone;

                _context.Update(contato);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Contatos.ToListAsync();
                resposta.Mensagem = "Contato Atualizado com Sucesso!";
                resposta.Status = true;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = $"Erro: {ex.Message}";
                resposta.Status = false;
            }

            return resposta;
        }

        public async Task<ResponseModel<List<ContatoModel>>> ExcluirContato(int idContato)
        {
            var resposta = new ResponseModel<List<ContatoModel>>();

            try
            {
                var contato = await _context.Contatos.FirstOrDefaultAsync(c => c.Id == idContato);

                if (contato == null)
                {
                    resposta.Mensagem = "Nenhum Contato Encontrado!";
                    resposta.Status = false;
                    return resposta;
                }

                _context.Contatos.Remove(contato);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Contatos.ToListAsync();
                resposta.Mensagem = "Contato Removido com Sucesso!";
                resposta.Status = true;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = $"Erro: {ex.Message}";
                resposta.Status = false;
            }

            return resposta;
        }
    }
}
