using AutoMapper;
using HashidsNet;

namespace CorneliusCup.Golf.API.Mappings.ValueConverters
{
    public class HashIdsEncodeValueConverter : IValueConverter<int, string>
    {
        private readonly IHashids _hashids;

        public HashIdsEncodeValueConverter(IHashids hashids)
        {
            this._hashids = hashids;
        }

        public string Convert(int sourceMember, ResolutionContext context)
        {
            return _hashids.Encode(sourceMember);
        }

    }
}
