using System;
using System.Collections.Generic;
using System.Text;
using Convice.Core.Entities.Abstract;

namespace Convice.Entities
{
    public class Platform : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ApiLink { get; set; }
        public string BaseLink { get; set; }
    }
}
