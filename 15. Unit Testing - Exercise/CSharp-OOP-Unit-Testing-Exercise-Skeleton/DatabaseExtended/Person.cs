using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace ExtendedDatabase
{
    public class Person
    {
        private long id;
        private string userName;

        public Person(long id, string userName)
        {
            this.Id = id;
            this.UserName = userName;
        }

        public string UserName
        {
            get { return userName; }
            private set { userName = value; }
        }

        public long Id
        {
            get { return id; }
            private set { id = value; }
        }

        //public int CompareTo(Person other)
        //{
        //    if (ReferenceEquals(this, other)) return 0;
        //    if (ReferenceEquals(null, other)) return 1;
        //    var idComparison = id.CompareTo(other.id);
        //    if (idComparison != 0) return idComparison;
        //    return string.Compare(userName, other.userName, StringComparison.Ordinal);
        //}
    }
}
