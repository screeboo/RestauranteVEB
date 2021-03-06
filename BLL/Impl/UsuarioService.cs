﻿using BLL.Interfaces;
using DAO.Interfaces;
using DTO;
using DTO.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            this._usuarioRepository = usuarioRepository;
        }

        public async Task<Response> Insert(UsuarioDTO usuario)
        {
            Response response = Validate(usuario);

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            return await _usuarioRepository.Insert(usuario);
        }

        public async Task<DataResponse<UsuarioDTO>> GetData()
        {
            return await _usuarioRepository.GetData();
        }

        public async Task<UsuarioDTO> Autententicar(string email, string senha)
        {
            return await _usuarioRepository.Autententicar(email,senha);
        }

        private Response Validate(UsuarioDTO item)
        {
            Response response = new Response();

            if (string.IsNullOrWhiteSpace(item.Nome))
            {
                response.Erros.Add("Informe o seu nome.");
            }
            else
            {
                item.Nome = EXT.NormatizarNome(item.Nome);
                if (item.Nome.Length < 2 || item.Nome.Length > 50)
                {
                    response.Erros.Add("O nome deve conter entre 2 e 50 caracteres.");
                }
                else if (!EXT.CorrectName(item.Nome))
                {
                    response.Erros.Add("O nome está no formato incorreto.");
                }
            }

            if (string.IsNullOrWhiteSpace(item.CPF))
            {
                response.Erros.Add("Informe o seu CPF.");
            }
            else
            {
                if (item.CPF.Length != 14)
                {
                    response.Erros.Add("O CPF deve conter 14 caracteres.");
                }
                else if (!EXT.IsCpf(item.CPF))
                {
                    response.Erros.Add("O CPF deve estar no formato correto.");
                }
            }

            if (string.IsNullOrWhiteSpace(item.Email))
            {
                response.Erros.Add("Informe o seu email.");
            }
            else
            {
                item.Email = EXT.NormatizarEmail(item.Email);
                if (item.Email.Length < 2 || item.Email.Length > 50)
                {
                    response.Erros.Add("O email deve conter entre 2 e 50 caracteres.");
                }
                else if (!EXT.IsEmail(item.Email))
                {
                    response.Erros.Add("O email deve estar no formato correto.");
                }
            }

            if (string.IsNullOrWhiteSpace(item.Senha))
            {
                response.Erros.Add("A senha deve ser informada.");
            }
            else if(item.Senha.Length < 5 || item.Senha.Length > 15)
            {
                response.Erros.Add("A senha deve conter de 5 a 15 caracteres.");
            }

            return response;
        }
    }
}

