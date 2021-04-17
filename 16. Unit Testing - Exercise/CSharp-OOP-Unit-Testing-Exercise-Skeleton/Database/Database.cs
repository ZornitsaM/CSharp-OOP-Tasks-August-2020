using System;

namespace Database
{
    public class Database
    {
        private int[] data;

        private int count;

        //OK
        public Database(params int[] data)
        {
            this.data = new int[16];

            for (int i = 0; i < data.Length; i++)
            {
                this.Add(data[i]);
            }

            this.count = data.Length;
        }

        //OK
        public int Count
        {
            get { return count; }
        }


        public void Add(int element)
        {
            //OK
            if (this.count == 16)
            {
                throw new InvalidOperationException("Array's capacity must be exactly 16 integers!");
            }

            //OK
            this.data[this.count] = element;
            this.count++;
        }

        public void Remove()
        {
            //OK
            if (this.count == 0)
            {
                throw new InvalidOperationException("The collection is empty!");
            }
            //OK
            this.count--;
            this.data[this.count] = 0;
        }

        public int[] Fetch()
        {
            //OK
            int[] coppyArray = new int[this.count];

            for (int i = 0; i < this.count; i++)
            {
                coppyArray[i] = this.data[i];
            }

            return coppyArray;
        }
    }
}
