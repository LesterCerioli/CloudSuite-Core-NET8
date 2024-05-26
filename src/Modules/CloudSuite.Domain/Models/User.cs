using CloudSuite.Domain.ValueObjects;
using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CloudSuite.Domain.Models
{
    public class User : Entity, IAggregateRoot
    {
        private readonly List<Vendor> _vendors;

        

        public User() { }

        public User(string? fullName, Cpf cpf, string? email, bool? isDeleted, DateTimeOffset? createdOn, DateTimeOffset? latestUpdatedOn, string? refreshTokenHash, string? culture)
        {
            FullName = fullName;
            Cpf = cpf;
            Email = email;
            IsDeleted = isDeleted;
            CreatedOn = createdOn;
            LatestUpdatedOn = latestUpdatedOn;
            RefreshTokenHash = refreshTokenHash;
            Culture = culture;
        }

        public User(string? fullName, Cpf cpf, string? email, Telephone telephone, bool? isDeleted, DateTimeOffset? createdOn, DateTimeOffset? latestUpdatedOn, string? refreshTokenHash, string? culture)
        {
            FullName = fullName;
            Cpf = cpf;
            Email = email;
            Telephone = telephone;
            IsDeleted = isDeleted;
            CreatedOn = createdOn;
            LatestUpdatedOn = latestUpdatedOn;
            RefreshTokenHash = refreshTokenHash;
            Culture = culture;
            _vendors = new List<Vendor>();
        }

        [Required(ErrorMessage ="The {0} field is required.")]
        public string? FullName { get; private set; }

        public Cpf Cpf { get; private set; }

        public string? Email { get; private set; }

        public Telephone Telephone { get; private set; }
        
        public bool? IsDeleted { get; private set; }

        public DateTimeOffset? CreatedOn { get; private set; }

        public DateTimeOffset? LatestUpdatedOn { get; private set; }

        [StringLength(50)]
        public string? RefreshTokenHash { get; private set; }

        public string? Culture {  get; private set; }
                        
        

        
    }
}