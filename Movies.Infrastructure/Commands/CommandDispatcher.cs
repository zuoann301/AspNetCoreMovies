﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _context;


        public CommandDispatcher(IComponentContext context)
        {
            _context = context;
        }

        public async Task Dispatch<T>(T command) where T : ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command),
                    $"Command: '{typeof(T).Name}' can not be null.");
            }
            var handler = _context.Resolve<ICommandHandler<T>>();
            await handler.Handle(command);
        }
    }
}
