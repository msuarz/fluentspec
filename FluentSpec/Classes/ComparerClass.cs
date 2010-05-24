using System.Collections;

namespace FluentSpec.Classes {

    public class ComparerClass : Comparer {

        public bool AreEqual(object[] Ones, object[] Others) {
            if (Ones == Others) return true;
            if (Ones == null || Others == null) return false;
            if (Ones.Length != Others.Length) return false;

            for (var i = 0; i < Ones.Length; i++)
                if (!AreEqual(Ones[i], Others[i]))
                    return false;

            return true;
        }

        public bool AreEqual(object One, object Other) {
            if (One == Other) return true;
            if (One == null || Other == null) return false;
            if (One.GetType() != Other.GetType()) return false;

            if (One is ICollection) return AreEqual(
                One as ICollection, Other as ICollection
            );

            return One.Equals(Other);
        }

        public bool AreEqual(ICollection Ones, ICollection Others) { return
            AreEqual(ArrayWith(Ones), ArrayWith(Others))
        ;}

        public object[] ArrayWith(ICollection Objects) {
            var ObjectsArray = new object[Objects.Count];
            Objects.CopyTo(ObjectsArray, 0);
            return ObjectsArray;
        }

    }
}