namespace ITGuru.FourWheels.Service
{
    /// <summary>
    /// A generic mapping tool that can map properties between <typeparamref name="TFrom"/> and <typeparamref name="TTo"/>
    /// </summary>
    /// <typeparam name="TFrom">The type to map <strong>from</strong></typeparam>
    /// <typeparam name="TTo">The type to map <strong>to</strong></typeparam>
    internal class Mapper<TFrom, TTo> where TTo : new()
    {
        /// <summary>
        /// Begin mapping and define the protocol that should be used to map properties of <typeparamref name="TFrom"/> and <typeparamref name="TTo"/>
        /// </summary>
        /// <param name="mapping">The mapping protocol that defines where properties should map to</param>
        /// <returns>A prepared <see cref="Mapper{TFrom, TTo}"/> that can map properties between <typeparamref name="TFrom"/> and <typeparamref name="TTo"/></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Mapper(Func<TTo, TFrom, TTo> mapping)
        {
            _mapping = mapping ?? throw new ArgumentNullException(nameof(mapping), "Mapping protocol can't be null");
        }

        /// <summary>
        /// The mapping protocol to follow
        /// </summary>
        private readonly Func<TTo, TFrom, TTo> _mapping;

        /// <summary>
        /// Maps <paramref name="from"/> to a <see langword="new"/> instance of <typeparamref name="TTo"/>
        /// </summary>
        /// <param name="from"></param>
        /// <returns>The <strong>mapped</strong> instance of <typeparamref name="TTo"/></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual TTo FromSingle(TFrom from)
        {
            TFrom mapFrom = from ?? throw new ArgumentNullException(nameof(mapFrom), "Source can't be null");

            return _mapping(new TTo(), mapFrom);
        }

        /// <summary>
        /// Maps <paramref name="from"/> to a collection of <typeparamref name="TTo"/>
        /// </summary>
        /// <param name="from">The collection of <typeparamref name="TFrom"/> to map</param>
        /// <returns>The <strong>mapped</strong> <see cref="IEnumerable{T}"/> of type <typeparamref name="TTo"/></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual IEnumerable<TTo> FromCollection(IEnumerable<TFrom> from)
        {
            IEnumerable<TFrom> mappedCollection = from ?? throw new ArgumentNullException(nameof(from), "Source can't be null");

            return mappedCollection.Select(from => _mapping(new TTo(), from));
        }
    }
}
