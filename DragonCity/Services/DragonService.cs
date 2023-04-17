using System.Text.Json;
using DragonCity.Models;

namespace DragonCity.Services

{
    public class DragonService : IDragonService
    {
        private readonly IHttpContextAccessor _session;
        private readonly string dragoesFile = @"Data\dragoes.json";
        private readonly string tipoFile = @"Data\tipo.json";
        public DragonService(IHttpContextAccessor session)
        {
            _session = session;
            PopularSessao();
        }
        public List<dragoes> GetDragao()
        {
            PopularSessao();
            var dragao = JsonSerializer.Deserialize<List<dragoes>>
            (_session.HttpContext.Session.GetString("dragao"));
            return dragao;
        }
        public List<Tipo> GetTipos()
        {
            PopularSessao();
            var tipos = JsonSerializer.Deserialize<List<Tipo>>
            (_session.HttpContext.Session.GetString("Tipos"));
            return tipos;
        }
        public dragoes GetDragoes(int Numero)
        {
            var dragao = GetDragao();
            return dragao.Where(p => p.Numero == Numero).FirstOrDefault();
        }
        public DragonCityDto GetDragonCityDto()
        {
            var drag = new DragonCityDto()
            {
                Dragao = GetDragao(),
                tipos = GetTipos()
            };
            return drag;
        }
        public DetailsDto GetDetailedCampeao(int Numero)
        {
            var dragao = GetDragao();
            var drag = new DetailsDto()
            {
                Current = dragao.Where(p => p.Numero == Numero)
                    .FirstOrDefault(),
                Prior = dragao.OrderByDescending(p => p.Numero)
                    .FirstOrDefault(p => p.Numero < Numero),
                Next = dragao.OrderBy(p => p.Numero)
                    .FirstOrDefault(p => p.Numero > Numero),
            };
            return drag;
        }
        public Tipo GetTipo(string Nome)
        {
            var tipos = GetTipos();
            return tipos.Where(t => t.Nome == Nome).FirstOrDefault();
        }
        private void PopularSessao()
        {
            if (string.IsNullOrEmpty(_session.HttpContext.Session.GetString("Tipos")))
            {
                _session.HttpContext.Session
                    .SetString("dragao", LerArquivo(dragoesFile));
                _session.HttpContext.Session
                    .SetString("Tipos", LerArquivo(tipoFile));
            }
        }
        private string LerArquivo(string fileName)
        {
            using (StreamReader leitor = new StreamReader(fileName))
            {
                string dados = leitor.ReadToEnd();
                return dados;
            }
        }
    }
}
