using CloudSuite.Domain.ValueObjects;
using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
namespace CloudSuite.Domain.Models
{
    public class Vendor : Entity, IAggregateRoot
    {
        

        public Vendor() { }

        public Vendor(string? name, string? slug, string? description, Cnpj cnpj, Guid cnpjId, string? email, DateTimeOffset? createdOn, DateTimeOffset? latestUpdatedOn, bool? isActive, bool? isDeleted)
        {
            Name = name;
            Slug = slug;
            Description = description;
            Cnpj = cnpj;
            Email = email;
            CreatedOn = createdOn;
            LatestUpdatedOn = latestUpdatedOn;
            IsActive = isActive;
            IsDeleted = isDeleted;
            _users = new List<User>();
        }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string? Name { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string? Slug { get; private set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(100)]
        public string? Description { get; private set; }

        public Cnpj Cnpj { get; private set; }

        
        public string? Email { get; private set; }

        public DateTimeOffset? CreatedOn { get; private set; }

        public DateTimeOffset? LatestUpdatedOn { get; private set; }

        public bool? IsActive { get; private set; }

        public bool? IsDeleted { get; private set; }

        private readonly List<User> _users;

        public IReadOnlyCollection<User> Users => _users.AsReadOnly();
        public User User { get; private set; }

        public Guid UserId { get; private set; }
    }
}