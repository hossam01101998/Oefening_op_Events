using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefening_op_Events
{
    internal class Stapel<T>
    {
        private List<T> stapel = new List<T>();

        public event Action<T, WijzigingType> InhoudGewijzigd;

        public void Toevoegen(T item)
        {

            stapel.Add(item);
            OnInhoudGewijzigd(item, WijzigingType.Toevoeging);
        }

        public T Verwijderen()
        {
            if (stapel.Count > 0)
            {

                T verwijderdItem = stapel[stapel.Count - 1];
                stapel.RemoveAt(stapel.Count - 1);
                OnInhoudGewijzigd(verwijderdItem, WijzigingType.Verwijdering);
                return verwijderdItem;
            }
            else
            {
                throw new InvalidOperationException("De stapel is leeg, kan geen items verwijderen.");
            }
        }

        public void Leegmaken()
        {
            stapel.Clear();

            OnInhoudGewijzigd(default(T), WijzigingType.Leegmaking);
        }

        protected virtual void OnInhoudGewijzigd(T item, WijzigingType wijziging)
        {
            InhoudGewijzigd?.Invoke(item, wijziging);
        }
    }

    // de drie opties
    enum WijzigingType
    {
        Toevoeging,
        Verwijdering,
        Leegmaking
    }

}
