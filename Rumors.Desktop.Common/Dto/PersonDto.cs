using System;

namespace Rumors.Desktop.Common.Dto
{
    public class PersonDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid? ProjectId { get; set; }
    }
}
