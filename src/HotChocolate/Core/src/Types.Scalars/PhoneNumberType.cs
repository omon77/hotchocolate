using System.Text.RegularExpressions;
using HotChocolate.Language;

namespace HotChocolate.Types.Scalars
{
    /// <summary>
    /// The `PhoneNumber` scalar type scalar type represents a value that conforms to the standard
    /// E.164 format. <a href="https://en.wikipedia.org/wiki/E.164">See More</a>.
    /// </summary>
    public class PhoneNumberType : RegexType
    {
        /// <summary>
        /// Regex that validates the standard E.164 format
        /// </summary>
        private const string _validationPattern = "^\\+[1-9]\\d{1,14}$";

        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumberType"/>
        /// </summary>
        public PhoneNumberType()
            : base(
                WellKnownScalarTypes.PhoneNumber,
                _validationPattern,
                ScalarResources.PhoneNumberType_Description,
                RegexOptions.Compiled | RegexOptions.IgnoreCase)
        {
        }

        /// <inheritdoc />
        protected override SerializationException CreateParseLiteralError(IValueNode valueSyntax)
        {
            return ThrowHelper.PhoneNumber_ParseLiteral_IsInvalid(this);
        }

        /// <inheritdoc />
        protected override SerializationException CreateParseValueError(object runtimeValue)
        {
            return ThrowHelper.PhoneNumber_ParseValue_IsInvalid(this);
        }
    }
}
