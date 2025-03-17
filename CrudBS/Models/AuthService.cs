using System;

namespace CrudBS.Models
{
    public class AuthService
    {
        private readonly CrudBsContext _context;

        public AuthService(CrudBsContext context)
        {
            _context = context;
        }

        public Usuario? Login(string correoElectronico, string contraseña)
        {
            // ENCRIPTAR LA CONTRASEÑA ANTES DE COMPARAR SI USAS HASHING
            return _context.Usuarios.FirstOrDefault(u => u.CorreoElectronico == correoElectronico && u.Contraseña == contraseña);
        }
    }

}
