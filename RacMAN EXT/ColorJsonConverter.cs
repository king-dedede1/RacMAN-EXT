using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace RacMAN;
public class ColorJsonConverter : JsonConverter<Color>
{
    public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => ColorTranslator.FromHtml(reader.GetString());

    public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options) => writer.WriteStringValue("#" + value.R.ToString("X2") + value.G.ToString("X2") + value.B.ToString("X2").ToLower());
}