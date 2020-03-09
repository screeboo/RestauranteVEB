﻿using DAO.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Impl
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private RContext _context;
        public UsuarioRepository(RContext context)
        {
            this._context = context;
        }

        public async Task<Response> Insert(UsuarioDTO usuario)
        {
            Response response = new Response();

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            this._context.Usuarios.Add(usuario);
            await this._context.SaveChangesAsync();
            return response;
        }

        public async Task<DataResponse<UsuarioDTO>> GetData()
        {
            DataResponse<UsuarioDTO> response = new DataResponse<UsuarioDTO>();

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            await this._context.Usuarios.ToListAsync();
            return response;
        }

        public async Task<Response> Autententicar(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
