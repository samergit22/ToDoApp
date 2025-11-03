using Application.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ErrorService : IErrorService
    {
        private readonly List<ErrorViewModel> _errors = new();

        public async Task LogErrorAsync(ErrorViewModel error)
        {
            _errors.Add(error);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<ErrorViewModel>> GetAllErrorsAsync()
        {
            return await Task.FromResult(_errors);
        }
    }
}
