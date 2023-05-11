using ApiTiendaZapatillasJPL.Data;

namespace ApiTiendaZapatillasJPL.Repositories
{
    public class RepositoryUsuarios
    {
        private UsuariosContext context;

        public RepositoryUsuarios(UsuariosContext context)
        {
            this.context = context;
        }
    }
}
