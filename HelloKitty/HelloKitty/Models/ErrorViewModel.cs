using System;

namespace HelloKitty.Models{
    public class ErrorViewModel{
        public string RequestId{ get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}