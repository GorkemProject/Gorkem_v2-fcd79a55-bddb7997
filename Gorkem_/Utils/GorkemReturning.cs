using System.Reflection;

namespace GorkemPagingAndFiltering.Extension
{
    public static class GorkemReturning
    {
        public static Dictionary<string, List<object>> GetUniqueValues<T>(this IQueryable<T> dataSet, params string[] excludeColumns)
        {
            // Sonuçları tutacak sözlük. Anahtar property adı, değer o property'sinin tekil değerler listesi
            var uniqueValues = new Dictionary<string, List<object>>();

            // T türündeki tüm public property'leri alıyoruz
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {

                if (excludeColumns.Contains(property.Name)){
                    var distinctValues = dataSet
                    .Select(x => property.GetValue(x))
                    .ToList();

                // Sonuçları property adıyla birlikte sözlüğe ekliyoruz
                uniqueValues[property.Name] = distinctValues.Distinct().ToList();    
                }
                // Her property için tekil değerleri alıyoruz
                
            }

            return uniqueValues;
        }
    }
}
 
