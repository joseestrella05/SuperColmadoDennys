using SuperColmadoDennys.Models;

namespace SuperColmadoDennys.Services;

public class CartService
{
    private readonly List<OrdenItem> _cart = new List<OrdenItem>();

    public void AddToCart(Productos producto, int cantidad)
    {
        var item = _cart.FirstOrDefault(x => x.ProductoId == producto.Id);
        if (item != null)
        {
            item.Cantidad += cantidad;
        }
        else
        {
            _cart.Add(new OrdenItem
            {
                ProductoId = producto.Id,
                Producto = producto,
                Cantidad = cantidad,
                Precio = producto.Precio
            });
        }
    }

    public void UpdateQuantity(int productoId, int cantidad)
    {
        var item = _cart.FirstOrDefault(x => x.ProductoId == productoId);
        if (item != null)
        {
            item.Cantidad = cantidad;
        }
    }

    public void RemoveFromCart(int productoId)
    {
        var item = _cart.FirstOrDefault(x => x.ProductoId == productoId);
        if (item != null)
        {
            _cart.Remove(item);
        }
    }

    public List<OrdenItem> GetCart() => _cart;

    public void ClearCart() => _cart.Clear();

    public decimal GetTotal() => (decimal)_cart.Sum(x => x.Precio * x.Cantidad);
}

