using HunterPie.Core.Architecture;
using Newtonsoft.Json;
using System;

namespace HunterPie.Core.Converters;

internal class ObservableConverter : JsonConverter
{
    public override bool CanConvert(Type objectType) => objectType == typeof(Observable<object>);

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        Type T = objectType.GetGenericArguments()[0];
        object value;
        if (T.IsEnum)
        {
            if (Enum.TryParse(T, reader.Value.ToString(), out object enumValue))
            {
                value = enumValue;
            }
            else
            {
                value = null;
            }
        }
        else
        {
            value = reader.Value != null ? Convert.ChangeType(reader.Value, T) : null;
        }
        object observable = Activator.CreateInstance(objectType, value);

        if (value is null)
            return observable;

        objectType.GetProperty(nameof(Observable<object>.Value))
            .SetValue(existingValue, value);

        return existingValue;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        object prop = value.GetType()
                    .GetProperty(nameof(Observable<object>.Value))
                    .GetValue(value);

        serializer.Serialize(writer, prop);
    }
}