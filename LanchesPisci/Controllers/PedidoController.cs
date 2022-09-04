using LanchesPisci.Models;
using LanchesPisci.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LanchesPisci.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoController(IPedidoRepository pedidoRepository, CarrinhoCompra carrinhoCompra)
        {
            _pedidoRepository = pedidoRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        //formulário de conclusão do pedido.
        [Authorize]
        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Checkout(Pedido pedido)
        {
            int totalItensPedido = 0;
            decimal valorTotalPedido = 0.0m;

            //obter os itens no carrinho de compras do cliente
            List<CarrinhoCompraItem> itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItems = itens;

            //verificar se existem itens de pedido.
            if(_carrinhoCompra.CarrinhoCompraItems.Count == 0)
            {
                ModelState.AddModelError("", "Seu carrinho está vazio!");
            }

            //se houver itens, calcula o total de itens e o total do pedido.
            foreach(var item in itens)
            {
                totalItensPedido = item.Quantidade;
                valorTotalPedido = (item.Lanche.Preco * item.Quantidade);
            }

            //atribuir os valores obtidos
            pedido.TotalItensPedido = totalItensPedido;
            pedido.PedidoTotal = valorTotalPedido;

            //valida os dados do pedido
            if (ModelState.IsValid)
            {
                //cria o pedido e os detalhes
                _pedidoRepository.CriarPedido(pedido);

                ViewBag.MensagemCheckoutCompleto = "Obrigado pelo seu pedido!";
                ViewBag.TotalPedido = _carrinhoCompra.GetCompraTotal();

                //limpa o carrinho
                _carrinhoCompra.LimparCarrinho();

                //exibe a view com os dados do cliente e o pedido.
                return View("~/Views/Pedido/CheckoutCompleto.cshtml", pedido);
            }

            return View(pedido);
        }
    }
}
