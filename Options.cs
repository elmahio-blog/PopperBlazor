using Microsoft.JSInterop;
using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace PopperBlazor
{
    public class Options
    {
        [JsonConverter(typeof(EnumDescriptionConverter<Placement>))]
        [JsonPropertyName("placement")]
        public Placement Placement { get; set; }

        [JsonIgnore]
        public Action<State> OnFirstUpdate { get; set; }

        [JSInvokable("CallOnFirstUpdate")]
        public void CallOnFirstUpdate(State state) => OnFirstUpdate?.Invoke(state);
    }

    public class State
    {
        [JsonConverter(typeof(EnumDescriptionConverter<Placement>))]
        [JsonPropertyName("placement")]
        public Placement Placement { get; set; }
    }

    public enum Placement
    {
        [Description("auto")] Auto,
        [Description("auto-start")] AutoStart,
        [Description("auto-end")] AutoEnd,
        [Description("top")] Top,
        [Description("top-start")] TopStart,
        [Description("top-end")] TopEnd,
        [Description("bottom")] Bottom,
        [Description("bottom-start")] BottomStart,
        [Description("bottom-end")] BottomEnd,
        [Description("right")] Right,
        [Description("right-start")] RightStart,
        [Description("right-end")] RightEnd,
        [Description("left")] Left,
        [Description("left-start")] LeftStart,
        [Description("left-end")] LeftEnd
    }
}
