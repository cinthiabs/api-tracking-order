using Application.DTO;
using Application.Interface;
using AutoMapper;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class Service : IService
    {
        private readonly IRegistration _Registration;
        private readonly IMapper _mapper;

        public Service(IRegistration Registration, IMapper mapper)
        {
            _Registration = Registration;
            _mapper = mapper;
        }
        public async Task<int> userQuery(UserDTO login)
        {
            int query = 0;
            try
            {
                query = await _Registration.userQuery(login.User, login.Password);
            }
            catch (Exception ex)
            {
                var erro = ex.Message;
                await _Registration.LogError("ConsultaUsuario - Application", erro, "API Sequoia - Brudam");
            }
            return query;
        }
    }
}
