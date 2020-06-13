using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer
// Some developers also implement the IEquatable interface on the Entity class, like this:
// public abstract class Entity_BaseClass : IEquatable<Entity_BaseClass>
//      public override bool Equals(object obj)
//      {
//          var other = obj as Entity_BaseClass;
//          return Equals(other);
//      }
// You can see that the Equals method just converts the object parameter to the entity type and calls the new method. 
// I tend not to do that, because this interface was designed for the use in value types, structs in other words, 
// and doesn't provide an additional value in classes. Therefore, its usage here violates the YAGNI principle. 
// You might have noticed that we don't set the ID property anywhere in this class. We will talk about it when we'll 
// be discussing persistence for our domain model in the context of object-relational mappers. 
{
    public abstract class Entity
    {
        public long Id { get; private set; } // comment définir ce Id ????

        // don't accept null
        public override bool Equals(object obj)
        {
            // cast ***********************************
            var other = obj as Entity;

            if (ReferenceEquals(other, null))
                return false;
            //*****************************************


            // compare references *********************
            if (ReferenceEquals(this, other))
                return true;
            //*****************************************

            if (GetType() != other.GetType())
                return false;

            // if Ids already set *********************
            if (Id == 0 || other.Id == 0)
                return false;
            //*****************************************

            return Id == other.Id;
        }

        // can accept nulls
        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }


    }
}
