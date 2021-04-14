using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
   public class Robot:Citizen
    {
        private string model;
        private string id;

        public Robot(string model, string id)
            :base(model,id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

       
    }
}
