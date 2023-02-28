using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabBook_WF_EF.Dto
{
    public class UserDto
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Permission { get; set; }
        public string Identifier { get; set; }
        public bool Active { get; set; }

        public UserDto(long id, string login, string permission, string identifier, bool active)
        {
            Id = id;
            Login = login;
            Permission = permission;
            Identifier = identifier;
            Active = active;
        }

        public override bool Equals(object obj)
        {
            return obj is UserDto dto &&
                   Id == dto.Id &&
                   Login == dto.Login &&
                   Permission == dto.Permission &&
                   Identifier == dto.Identifier &&
                   Active == dto.Active;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Login, Permission, Identifier, Active);
        }
    }
}
