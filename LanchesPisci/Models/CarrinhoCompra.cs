using LanchesPisci.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace LanchesPisci.Models
{
    public class CarrinhoCompra
    {
        private readonly AppDbContext _context;
        public CarrinhoCompra(AppDbContext context)
        {
            _context = context;
        }

        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }

        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            //define uma sessão.
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //obtem um serviço do tipo do nosso contexto.
            var context = services.GetService<AppDbContext>();

            //obtem ou gera um id no carrinho
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            //atribui o id do carrinho na sessão.
            session.SetString("CarrinhoId", carrinhoId);

            //Retorna o carrinho com o id atribuido ou obtido.
            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };
        }

        public void AdcionarAoCarrinho(Lanche lanche)
        {
            var carrinhoCompraItem = _context.CarrinhoCompraItens
                .SingleOrDefault(x => x.Lanche.LancheId == lanche.LancheId &&
                x.CarrinhoCompraId == CarrinhoCompraId);

            if(carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Lanche = lanche,
                    Quantidade = 1
                };
                _context.CarrinhoCompraItens.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
            }
            _context.SaveChanges();
        }

        public void RemoverDoCarrinho(Lanche lanche)
        {
            var carrinhoCompraItem = _context.CarrinhoCompraItens
                .SingleOrDefault(x => x.Lanche.LancheId == lanche.LancheId &&
                x.CarrinhoCompraId == CarrinhoCompraId);

            if(carrinhoCompraItem != null)
            {
                if(carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade--;
                }
            }
            else
            {
                _context.CarrinhoCompraItens.Remove(carrinhoCompraItem);
            }
            _context.SaveChanges();
        }

        public List<CarrinhoCompraItem> GetCarrinhoCompraItens()
        {
            return CarrinhoCompraItems ?? (CarrinhoCompraItems = _context.CarrinhoCompraItens
                .Where(x => x.CarrinhoCompraId == CarrinhoCompraId)
                .Include(x => x.Lanche)
                .ToList());
        }

        public void LimparCarrinho()
        {
            var carrinhoCompras = _context.CarrinhoCompraItens
                                  .Where(x => x.CarrinhoCompraId == CarrinhoCompraId);

            _context.CarrinhoCompraItens.RemoveRange(carrinhoCompras);
            _context.SaveChanges();
        }

        public decimal GetCompraTotal()
        {
            var total = _context.CarrinhoCompraItens
                        .Where(x => x.CarrinhoCompraId == CarrinhoCompraId)
                        .Select(x => x.Lanche.Preco * x.Quantidade).Sum();


            return total;
        }
    }
}
