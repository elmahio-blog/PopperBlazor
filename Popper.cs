using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace PopperBlazor
{
    public class Popper
    {
        private readonly IJSRuntime jSRuntime;

        public Popper(IJSRuntime jSRuntime)
        {
            this.jSRuntime = jSRuntime;
        }

        public async Task<Instance> CreatePopperAsync(ElementReference reference, ElementReference popper, Options options)
        {
            var objRef = DotNetObjectReference.Create(options);
            var popperWrapper = await jSRuntime.InvokeAsync<IJSInProcessObjectReference>("import", "./js/PopperWrapper.js");
            var jSInstance = await popperWrapper.InvokeAsync<IJSObjectReference>("createPopper", reference, popper, options, objRef);
            return new(jSInstance, objRef, popperWrapper);
        }
    }
}
