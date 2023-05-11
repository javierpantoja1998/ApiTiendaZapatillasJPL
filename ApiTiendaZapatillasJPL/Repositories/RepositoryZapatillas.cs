using ApiTiendaZapatillasJPL.Data;
using Microsoft.EntityFrameworkCore;
using NuggetTiendaZapatillasJPL.Models;

namespace ApiTiendaZapatillasJPL.Repositories
{
    public class RepositoryZapatillas
    {
        private ZapatillasContext context;

        public RepositoryZapatillas(ZapatillasContext context)
        {
            this.context = context;
        }

        //FUNCION PARA SACAR TODAS LAS ZAPATILLAS
        public async Task<List<Zapatilla>> GetZapatillassAsync()
        {
            return await this.context.Zapatillas.ToListAsync();

        }

        //FUNCION PARA LOS DETALLES
        public async Task<Zapatilla> FindZapatillaAsync(int id)
        {
            return await this.context.Zapatillas
            .FirstOrDefaultAsync(x => x.IdZapatilla == id);
        }

        //Funcion para insertar
        public async Task InsertarPersonaje
            (string numerotarjeta, string nombre, string apellidos, string direccion,
            string email, string numerotelefono, int codigopostal)
        {
            Compra compra = new Compra();
            compra.NumeroTarjeta = numerotarjeta;
            compra.Nombre = nombre;
            compra.Apellidos = apellidos;
            compra.Direccion = direccion;
            compra.Email = email;
            compra.NumeroTelefono = numerotelefono;
            compra.CodigoPostal = codigopostal;
            this.context.Compras.Add(compra);
            await this.context.SaveChangesAsync();
        }

    }
}
