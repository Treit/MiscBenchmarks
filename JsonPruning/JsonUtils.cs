namespace Test
{
    using System.Buffers;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Text.Json;
    using System.Text.Json.Nodes;

    public static class JsonUtils
    {
        public static string SerializeAndPrune<T>(T obj, ICollection<string> nodeNamesToPrune)
        {
            using var memoryStream = new MemoryStream();
            using var writer = new Utf8JsonWriter(memoryStream);

            ProcessElement(
                JsonSerializer.SerializeToDocument(obj).RootElement,
                writer,
                nodeNamesToPrune);

            writer.Flush();

            memoryStream.Position = 0;
            var length = (int)memoryStream.Length;

            var buffer = ArrayPool<byte>.Shared.Rent(length);

            try
            {
                memoryStream.Read(buffer, 0, length);

                return Encoding.UTF8.GetString(buffer, 0, length);
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }

        private static int ProcessElement(
            JsonElement element,
            Utf8JsonWriter writer,
            ICollection<string> nodesToFilterOut)
        {
            var removedCount = 0;

            switch (element.ValueKind)
            {
                case JsonValueKind.Object:
                    writer.WriteStartObject();
                    foreach (JsonProperty property in element.EnumerateObject())
                    {
                        if (nodesToFilterOut.Contains(property.Name))
                        {
                            removedCount++;
                            continue;
                        }

                        writer.WritePropertyName(property.Name);
                        removedCount += ProcessElement(property.Value, writer, nodesToFilterOut);
                    }
                    writer.WriteEndObject();
                    break;
                case JsonValueKind.Array:
                    writer.WriteStartArray();
                    foreach (JsonElement arrayElement in element.EnumerateArray())
                    {
                        removedCount += ProcessElement(arrayElement, writer, nodesToFilterOut);
                    }
                    writer.WriteEndArray();
                    break;

                case JsonValueKind.String:
                    writer.WriteStringValue(element.GetString());
                    break;

                case JsonValueKind.Number:
                    if (element.TryGetInt64(out long intValue))
                    {
                        writer.WriteNumberValue(intValue);
                    }
                    else
                    {
                        writer.WriteNumberValue(element.GetDouble());
                    }
                    break;

                case JsonValueKind.True:
                    writer.WriteBooleanValue(true);
                    break;

                case JsonValueKind.False:
                    writer.WriteBooleanValue(false);
                    break;
                case JsonValueKind.Null:
                    writer.WriteNullValue();
                    break;
                case JsonValueKind.Undefined:
                    break;
                default:
                    break;
            }

            return removedCount;
        }

        public static string RemoveAllByName<T>(T inputObj, ICollection<string> nodeNamesToPrune)
        {
            using var memoryStream = new MemoryStream();
            var rootNode = JsonSerializer.SerializeToNode(inputObj);

            var stack = new Stack<JsonNode>();
            stack.Push(rootNode);

            while (stack.TryPop(out var node))
            {
                if (node is JsonObject obj)
                {
                    foreach (var propName in nodeNamesToPrune)
                    {
                        obj.Remove(propName);
                    }

                    foreach (var child in obj)
                    {
                        if (child.Value is not null)
                            stack.Push(child.Value);
                    }
                }
                else if (node is JsonArray arr)
                {
                    foreach (var child in arr)
                    {
                        if (child is not null)
                            stack.Push(child);
                    }
                }
            }

            return JsonSerializer.Serialize(rootNode);
        }
    }
}
