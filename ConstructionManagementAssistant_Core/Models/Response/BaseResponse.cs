using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConstructionManagementAssistant_Core.Models.Response
{
    public class BaseResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? Errors { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public T? Data { get; set; }

        public BaseResponse(T? data, string message, List<string>? errors = null, bool success = true)
        {
            Data = data;
            Message = message;
            Errors = errors;
            Success = success;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }

}
