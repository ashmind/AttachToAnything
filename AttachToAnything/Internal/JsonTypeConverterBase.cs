using System;
using System.ComponentModel;
using System.Globalization;
using Newtonsoft.Json;

namespace AttachToAnything.Internal {
    public abstract class JsonTypeConverterBase<T> : TypeConverter {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) {
            var json = value as string;
            if (json == null)
                return base.ConvertFrom(context, culture, value);

            return JsonConvert.DeserializeObject<T>(json);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) {
            return destinationType == typeof(string);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) {
            return JsonConvert.SerializeObject((T)value);
        }
    }
}