using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BinarySerializer
{
    /// <summary>
    /// Introduces methods for serializing and deserializing collections into the data streams
    /// </summary>
    public static class CollectionSerializer
    {
        /// <summary>
        /// Serialize this collection to the specified data stream
        /// </summary>
        /// <typeparam name="T">Item Type in Collection</typeparam>
        /// <param name="collection"></param>
        /// <param name="stream"></param>
        public static void WriteToFile<T>(this ICollection<T> collection, Stream stream)
        {
            var binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(stream, collection);
        }
        /// <summary>
        /// Serialize data from the specified stream to a collection with the specified data type for items
        /// </summary>
        /// <typeparam name="T">Item Type in Collection</typeparam>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static ICollection<T> ReadFromFile<T>(Stream stream)
        {
            var binaryFormatter = new BinaryFormatter();
            return binaryFormatter.Deserialize(stream) as ICollection<T>;
        }
    }
}