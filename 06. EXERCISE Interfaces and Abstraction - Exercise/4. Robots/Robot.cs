using System;
using System.Collections.Generic;
using System.Text;

namespace PO5
{
    public class Robot : IName, IId
    {
        public Robot(string name, string id)
            
        {
            this.Name = name;
            this.Id = id;
        }

        public string Name { get; set; }
        public string Id { get; set; }
    }
}
