using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBlog.Application.Abstractions.Commands
{
    public interface ICommand : IRequest
    { }
    
    public interface ICommand<out TResponse> : IRequest<TResponse>
    { }
}
