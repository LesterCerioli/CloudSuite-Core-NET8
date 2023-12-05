﻿using MediatR;
using System.ComponentModel.DataAnnotations;
using StateEntity = CloudSuite.Domain.Models.State;
using CountryEntity = CloudSuite.Domain.Models.Country;
using CloudSuite.Modules.Application.Handlers.State.Responses;

namespace CloudSuite.Modules.Application.Handlers.State
{
    public class CreateStateCommand : IRequest<CreateStateResponse>
    {
        public Guid Id { get; private set; }
                
        public string? StateName { get; set; }
                
        public string? UF { get; set; }
        
        public CreateStateCommand()
        {
            Id = Guid.NewGuid();
        }

		public StateEntity GetEntity()
        {
            return new StateEntity(
                this.Id,
                this.UF,
                this.StateName
                
                );
        }

    }
}
